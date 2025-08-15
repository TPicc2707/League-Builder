using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.Services.AddHttpContextAccessor()
                .AddTransient<AuthorizationHandler>();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

builder.Services.AddAWSService<IAmazonS3>();

var oidcScheme = OpenIdConnectDefaults.AuthenticationScheme;

builder.Services.AddAuthentication(oidcScheme)
                .AddKeycloakOpenIdConnect("keycloak", realm: "LeagueRealm", oidcScheme, options =>
                {
                    options.ClientId = builder.Configuration.GetSection("KeycloakClient").Value;
                    options.ClientSecret = builder.Configuration.GetSection("KeycloakSecret").Value;
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
                    options.SaveTokens = true;
                    options.UseTokenLifetime = true;
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IAWSService, AWSService>();
builder.Services.AddScoped<ISupportService, SupportService>();

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

app.MapDefaultEndpoints();

app.MapLoginAndLogout();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(c => c.DisableWebSocketCompression = true);

app.Run();
