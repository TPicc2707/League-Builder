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

builder.Services.AddCustomAuthentication();

builder.Services.AddKeycloakPolicies(ServiceName.GameService);

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseAuthentication();

app.UseAuthorization();

// Configure the HTTP request pipeline.
app.UseApiServices();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
