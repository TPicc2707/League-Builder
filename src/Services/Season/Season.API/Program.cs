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

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<SeasonInitialData>();

builder.Services.AddMessageBroker(Assembly.GetExecutingAssembly());

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

builder.Services.AddCustomAuthentication();

builder.Services.AddKeycloakPolicies(ServiceName.SeasonService);

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseAuthentication();

app.UseAuthorization();

app.MapCarter();

app.UseCors();

app.UseExceptionHandler(options => { });

app.MapHealthChecks("/healthz",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }).RequireAuthorization(KeycloakPolicy.SupportSeasonPolicy);


app.Run();
