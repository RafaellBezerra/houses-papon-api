# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HousesPapon/src/HousesPapon.API/HousesPapon.API.csproj", "HousesPapon/src/HousesPapon.API/"]
COPY ["HousesPapon/src/HousesPapon.Application/HousesPapon.Application.csproj", "HousesPapon/src/HousesPapon.Application/"]
COPY ["HousesPapon/src/HousesPapon.Communication/HousesPapon.Communication.csproj", "HousesPapon/src/HousesPapon.Communication/"]
COPY ["HousesPapon/src/HousesPapon.Domain/HousesPapon.Domain.csproj", "HousesPapon/src/HousesPapon.Domain/"]
COPY ["HousesPapon/src/HousesPapon.Exception/HousesPapon.Exception.csproj", "HousesPapon/src/HousesPapon.Exception/"]
COPY ["HousesPapon/src/HousesPapon.Infrastructure/HousesPapon.Infrastructure.csproj", "HousesPapon/src/HousesPapon.Infrastructure/"]
RUN dotnet restore "./HousesPapon/src/HousesPapon.API/HousesPapon.API.csproj"
COPY . .
WORKDIR "/src/HousesPapon/src/HousesPapon.API"
RUN dotnet build "./HousesPapon.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HousesPapon.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HousesPapon.API.dll"]