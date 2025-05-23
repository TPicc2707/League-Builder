var builder = DistributedApplication.CreateBuilder(args);

//Create Services

var postgres = builder
        .AddPostgres("postgres", port: 5432)
        .WithPgAdmin()
        .WithDataVolume()
        .WithLifetime(ContainerLifetime.Persistent);

var password = builder.AddParameter("SqlServerSaPassword", secret: true);

var sql = builder.AddSqlServer("sql", password)
          .WithDataVolume()
          .WithLifetime(ContainerLifetime.Persistent);

var rabbitmq = builder
      .AddRabbitMQ("rabbitmq")
      .WithManagementPlugin()
      .WithDataVolume()
      .WithLifetime(ContainerLifetime.Persistent);

var keycloak = builder
    .AddKeycloak("keycloak", 8080)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

//Postgress
var leagueDb = postgres.AddDatabase("leagueDb");
var seasonDb = postgres.AddDatabase("seasonDb");

//Sql
var teamDb = sql.AddDatabase("teamDb");
var playerDb = sql.AddDatabase("playerDb");
var statsDb = sql.AddDatabase("statsDb");
var standingsDb = sql.AddDatabase("standingsDb");
var gameDb = sql.AddDatabase("gameDb");

//Services
var league = builder
            .AddProject<Projects.League_API>("league-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6000)
            .WithHttpsEndpoint(port: 6060)
            .WithReference(leagueDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(leagueDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);


var team = builder
            .AddProject<Projects.Team_API>("team-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6001)
            .WithHttpsEndpoint(port: 6061)
            .WithReference(teamDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(teamDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);


var player = builder
            .AddProject<Projects.Player_API>("player-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6002)
            .WithHttpsEndpoint(port: 6062)
            .WithReference(playerDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(playerDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);


var stats = builder
            .AddProject<Projects.Stats_API>("stats-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6007)
            .WithHttpsEndpoint(port: 6067)
            .WithReference(statsDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(statsDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);


var standings = builder
                .AddProject<Projects.Standings_API>("standings-api",
                configure: static project =>
                {
                    project.ExcludeLaunchProfile = true;
                    project.ExcludeKestrelEndpoints = false;
                })
                .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
                .WithHttpEndpoint(port: 6005)
                .WithHttpsEndpoint(port: 6065)
                .WithReference(standingsDb)
                .WithReference(rabbitmq)
                .WithReference(keycloak)
                .WaitFor(standingsDb)
                .WaitFor(rabbitmq)
                .WaitFor(keycloak);


var season = builder
            .AddProject<Projects.Season_API>("season-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6004)
            .WithHttpsEndpoint(port: 6064)
            .WithReference(seasonDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(seasonDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);

var game = builder
            .AddProject<Projects.Game_API>("game-api",
            configure: static project =>
            {
                project.ExcludeLaunchProfile = true;
                project.ExcludeKestrelEndpoints = false;
            })
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithHttpEndpoint(port: 6006)
            .WithHttpsEndpoint(port: 6066)
            .WithReference(gameDb)
            .WithReference(rabbitmq)
            .WithReference(keycloak)
            .WaitFor(gameDb)
            .WaitFor(rabbitmq)
            .WaitFor(keycloak);


var apiGateway = builder
                .AddProject<Projects.League_Builder_ApiGateway>("league-builder-apigateway",
                configure: static project =>
                {
                    project.ExcludeLaunchProfile = true;
                    project.ExcludeKestrelEndpoints = false;
                })
                .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
                .WithHttpEndpoint(port: 6003)
                .WithHttpsEndpoint(port: 6063)
                .WithReference(league)
                .WithReference(team)
                .WithReference(player)
                .WithReference(stats)
                .WithReference(game)
                .WithReference(standings)
                .WithReference(season)
                .WithReference(keycloak)
                .WaitFor(league)
                .WaitFor(team)
                .WaitFor(stats)
                .WaitFor(game)
                .WaitFor(standings)
                .WaitFor(season)
                .WithReference(keycloak);


builder.AddProject<Projects.League_Builder_Web_Server>("league-builder-web-server",
                 configure: static project =>
                 {
                     project.ExcludeLaunchProfile = true;
                     project.ExcludeKestrelEndpoints = false;
                 })
                .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
                .WithHttpEndpoint(port: 6008)
                .WithHttpsEndpoint(port: 6068)
                .WithExternalHttpEndpoints()
                .WithReference(apiGateway)
                .WithReference(keycloak)
                .WaitFor(apiGateway)
                .WaitFor(keycloak);


builder.Build().Run();
