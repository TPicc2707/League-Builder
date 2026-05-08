using League.Builder.Web.Server.Services.Submissions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.Services.AddHttpContextAccessor()
                .AddTransient<AuthorizationHandler>();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

builder.Services.AddAWSService<IAmazonS3>();

var oidcScheme = "keycloak";

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = oidcScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddKeycloakOpenIdConnect("keycloak", realm: "LeagueRealm", oidcScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("KeycloakClient").Value;
    options.ClientSecret = builder.Configuration.GetSection("KeycloakSecret").Value;
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.RequireHttpsMetadata = false;
    options.Authority = builder.Configuration.GetSection("KeycloakAuthority").Value;
    options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;

    if (builder.Environment.IsEnvironment("Test"))
    {
        options.TokenValidationParameters.RoleClaimType = ClaimTypes.Role;
        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = context =>
            {
                Console.WriteLine("=== OnTokenValidated event triggered ===");
                var identity = (ClaimsIdentity)context.Principal!.Identity!;
                var accessTokenString = 
                    context.TokenEndpointResponse?.AccessToken ??
                    context.Properties.GetTokenValue("access_token");

                if(string.IsNullOrEmpty(accessTokenString))
                {
                    Console.WriteLine("No access token found in the context.");
                    return Task.CompletedTask;
                }

                Console.WriteLine("We have an access token.");

                var handler = new JwtSecurityTokenHandler();
                var accessToken = handler.ReadJwtToken(accessTokenString);

                Console.WriteLine("Token claims:");
                foreach (var c in accessToken.Claims)
                {
                    Console.WriteLine($"  {c.Type}: {c.Value}");
                }
                if (accessToken.Payload.TryGetValue("realm_access", out var realmAccessObj) &&
                    realmAccessObj is JsonElement realmAcess &&
                    realmAcess.TryGetProperty("roles", out var realmRoles) &&
                    realmRoles.ValueKind == JsonValueKind.Array)
                {
                    foreach (var role in realmRoles.EnumerateArray())
                    {
                        Console.WriteLine($"  Adding realm role: {role}");
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.GetString()!));
                    }
                }
                else
                {
                    Console.WriteLine("No realm_access.roles found.");
                }

                if(accessToken.Payload.TryGetValue("resource_access", out var resourceAccessObj) &&
                    resourceAccessObj is JsonElement resourceAccess &&
                    resourceAccess.TryGetProperty("league-builder-client", out var clientObj) &&
                    clientObj.TryGetProperty("roles", out var clientRoles) &&
                    clientRoles.ValueKind == JsonValueKind.Array)
                {
                    foreach(var role in clientRoles.EnumerateArray())
                    {
                        Console.WriteLine($"  Adding realm role: {role}");
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.GetString()!));
                    }
                }
                else
                {
                    Console.WriteLine("No resource_access.league-builder-client.roles found.");
                }

                Console.WriteLine("Final role claims on identity:");
                foreach(var role in identity.Claims.Where(c => c.Type == ClaimTypes.Role))
                {
                    Console.WriteLine($"  {role.Value}");
                }

                Console.WriteLine("=== OnTokenValidated complete ===");
                return Task.CompletedTask;
            }
        };
    }

    options.SaveTokens = true;
    options.UseTokenLifetime = false;
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Scope.Add("offline_access");
});

builder.Services.Configure<CookieAuthenticationOptions>(
    CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        options.Events = new CookieAuthenticationEvents();
    });

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
}

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.AddRedisDistributedCache("cache");

if (builder.Environment.IsEnvironment("Test"))
{
    IConnectionMultiplexer? multiplexer = null;

    builder.Services.AddDataProtection()
        .PersistKeysToStackExchangeRedis
        (
            () => 
            {
                multiplexer ??= builder.Services.BuildServiceProvider().GetRequiredService<IConnectionMultiplexer>();

                return multiplexer.GetDatabase();
            },
            key: "DataProtection-Keys"
        );
}

builder.Services.AddScoped<KeycloakTokenService>();
builder.Services.AddScoped<ErrorState>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<StatsSubmissionService>();
builder.Services.AddScoped<IGameSimulatorService, GameSimulatorService>();
builder.Services.AddScoped<IAWSService, AWSService>();
builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<ILeagueLocalCacheService, LeagueLocalCacheService>();
builder.Services.AddScoped<ITeamLocalCacheService, TeamLocalCacheService>();
builder.Services.AddScoped<IPlayerLocalCacheService, PlayerLocalCacheService>();
builder.Services.AddScoped<ISeasonLocalCacheService, SeasonLocalCacheService>();
builder.Services.AddScoped<IStatsLocalCacheService, StatsLocalCacheService>();
builder.Services.AddScoped<IGameLocalCacheService, GameLocalCacheService>();
builder.Services.AddScoped<IStandingsLocalCacheService, StandingsLocalCacheService>();
builder.Services.AddScoped<IValidator<CreateLeagueModel>, CreateLeagueModelValidator>();
builder.Services.AddScoped<IValidator<CreateTeamModel>, CreateTeamModelValidator>();
builder.Services.AddScoped<IValidator<CreatePlayerModel>, CreatePlayerModelValidator>();
builder.Services.AddScoped<IValidator<CreateGameModel>, CreateGameModelValidator>();
builder.Services.AddScoped<IValidator<CreateSeasonModel>, CreateSeasonModelValidator>();
builder.Services.AddScoped<IValidator<UpdateLeagueModel>, UpdateLeagueModelValidator>();
builder.Services.AddScoped<IValidator<UpdateTeamModel>, UpdateTeamModelValidator>();
builder.Services.AddScoped<IValidator<UpdatePlayerModel>, UpdatePlayerModelValidator>();
builder.Services.AddScoped<IValidator<UpdateGameModel>, UpdateGameModelValidator>();
builder.Services.AddScoped<IValidator<UpdateSeasonModel>, UpdateSeasonModelValidator>();
builder.Services.AddScoped<IValidator<UpdateLeagueSettingsModel>, UpdateLeagueSettingsModelValidator>();

string serverApiBaseAddress = builder.Environment.IsDevelopment()
    ? "https://localhost:6068/"
    : "https://app.myleaguebuilder.com/";

builder.Services.AddHttpClient("ServerAPI", client =>
{
    client.BaseAddress = new Uri(serverApiBaseAddress);
});

string gatewayBaseAddress = builder.Environment.IsDevelopment()
    ? "https+http://league-builder-apigateway"
    : "https://gateway.myleaguebuilder.com";

builder.Services.AddRefitClient<ILeagueService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);

}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<ITeamService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IPlayerService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IStatsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IStandingsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<ISeasonService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IGameService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri(gatewayBaseAddress);
}).AddHttpMessageHandler<AuthorizationHandler>();

// Register Ollama-based chat & embedding
builder.AddOllamaApiClient("ollama-llama3-2").AddChatClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsEnvironment("Test"))
{
    var forwardedHeadersOptions = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    };

    // Allow ALB forwarded headers
    forwardedHeadersOptions.KnownIPNetworks.Clear();
    forwardedHeadersOptions.KnownProxies.Clear();

    app.UseForwardedHeaders(forwardedHeadersOptions);
}

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

app.MapControllers();

app.MapDefaultEndpoints();

app.MapLoginAndLogout();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(c => c.DisableWebSocketCompression = true);

app.MapGet("/healthz", () => Results.Ok("Healthy")).AllowAnonymous();

app.MapGet("/debug/token", async (HttpContext ctx) =>
{
    var token = await ctx.GetTokenAsync("access_token");
    return Results.Ok(token);
}).RequireAuthorization();

app.MapGet("/debug/roles", (ClaimsPrincipal user) =>
{
    return user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
}).RequireAuthorization();

app.MapGet("/debug/env", () => builder.Environment.EnvironmentName);

app.Run();
