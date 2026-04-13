var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.AddNpgsqlDataSource("seasonDb");
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("seasonDb")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment() || builder.Environment.IsEnvironment("Test"))
    builder.Services.InitializeMartenWith<SeasonInitialData>();

builder.Services.AddMessageBroker("season-api", Assembly.GetExecutingAssembly());

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    builder.WithOrigins("https://localhost:6063")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("seasonDb")!);

builder.Services.AddCustomAuthentication(builder.Configuration);

builder.Services.AddKeycloakPolicies(ServiceName.SeasonService);

var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapCarter();

app.MapDefaultEndpoints();

app.MapHealthChecks("/healthz",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }).AllowAnonymous();

app.MapHealthChecks("/support/healthz",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }).RequireAuthorization(KeycloakPolicy.SupportSeasonPolicy);


app.Run();
