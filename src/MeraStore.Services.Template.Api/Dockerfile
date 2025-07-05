# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MeraStore.Services.Template.Api/MeraStore.Services.Template.Api.csproj", "src/MeraStore.Services.Template.Api/"]
COPY ["src/MeraStore.Services.Template.Infrastructure/MeraStore.Services.Template.Infrastructure.csproj", "src/MeraStore.Services.Template.Infrastructure/"]
COPY ["src/MeraStore.Services.Template.Persistence/MeraStore.Services.Template.Persistence.csproj", "src/MeraStore.Services.Template.Persistence/"]
COPY ["src/MeraStore.Services.Template.Domain/MeraStore.Services.Template.Domain.csproj", "src/MeraStore.Services.Template.Domain/"]
COPY ["src/MeraStore.Services.Template.Common/MeraStore.Services.Template.Common.csproj", "src/MeraStore.Services.Template.Common/"]
RUN dotnet restore "./src/MeraStore.Services.Template.Api/MeraStore.Services.Template.Api.csproj"
COPY . .
WORKDIR "/src/src/MeraStore.Services.Template.Api"
RUN dotnet build "./MeraStore.Services.Template.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MeraStore.Services.Template.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeraStore.Services.Template.Api.dll"]