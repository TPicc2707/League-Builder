using League.Builder.Web.Server.Common;
using League.Builder.Web.Server.Services.Submissions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

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

var oidcScheme = OpenIdConnectDefaults.AuthenticationScheme;

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
    options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
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

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.AddRedisDistributedCache("cache");

builder.Services.AddScoped<KeycloakTokenService>();
builder.Services.AddScoped<ErrorState>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<StatsSubmissionService>();
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

builder.Services.AddHttpClient("ServerAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:6068/");
});

builder.Services.AddRefitClient<ILeagueService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");

}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<ITeamService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IPlayerService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IStatsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IStandingsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<ISeasonService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

builder.Services.AddRefitClient<IGameService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
}).AddHttpMessageHandler<AuthorizationHandler>();

// Register Ollama-based chat & embedding
builder.AddOllamaApiClient("ollama-llama3-2").AddChatClient();

var app = builder.Build();

app.UseHttpsRedirection();

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

app.Run();
