# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG PASSWORD_ENV_SEEDED=some.long.password.fllkwefiwejf23049uwlekjf.sEFWEFGR98^&$
RUN mkdir -p /https
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p $PASSWORD_ENV_SEEDED
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiGateways/League.Builder.ApiGateway/League.Builder.ApiGateway.csproj", "ApiGateways/League.Builder.ApiGateway/"]
RUN dotnet restore "./ApiGateways/League.Builder.ApiGateway/League.Builder.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateways/League.Builder.ApiGateway"
RUN dotnet build "./League.Builder.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./League.Builder.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
COPY --chmod=0755 --from=build /https/* /https/
COPY --chmod=0755 --from=build /https/* /usr/share/ca-certifcates/
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "League.Builder.ApiGateway.dll"]