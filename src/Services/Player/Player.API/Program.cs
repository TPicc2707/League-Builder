using BuildingBlocks.Messaging.MessageBus;
using Rebus.Bus;

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

builder.Services.AddKeycloakPolicies(ServiceName.PlayerService);

var app = builder.Build();

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

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
