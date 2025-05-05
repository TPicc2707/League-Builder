var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRefitClient<ILeagueService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<ITeamService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<IPlayerService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<IStatsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<IStandingsService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<ISeasonService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

builder.Services.AddRefitClient<IGameService>().ConfigureHttpClient(x =>
{
    x.BaseAddress = new Uri("https+http://league-builder-apigateway");
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(c => c.DisableWebSocketCompression = true);

app.Run();
