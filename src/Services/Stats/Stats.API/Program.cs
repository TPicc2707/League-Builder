using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Messaging.MessageBus;
using Rebus.Bus;
using Rebus.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    builder.WithOrigins("https://localhost:6063")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddCustomAuthentication(builder.Configuration);

builder.Services.AddKeycloakPolicies(ServiceName.StatService);

var app = builder.Build();

var provider = app.Services;

var handlers = provider.GetServices<IHandleMessages<TeamCreationEvent>>();

Console.WriteLine($"Handlers found: {handlers.Count()}");

var bus = app.Services.GetRequiredService<IBus>();

await bus.SubscribeToHandledEvents(typeof(ApplicationAssemblyMarker).Assembly);

app.UseExceptionHandler(options => { });

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

// Configure the HTTP request pipeline.
app.UseApiServices();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Test"))
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
