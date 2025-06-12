# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS="http://+:8080"


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HousesPapon.API/HousesPapon.API.csproj", "src/HousesPapon.API/"]
COPY ["src/HousesPapon.Application/HousesPapon.Application.csproj", "src/HousesPapon.Application/"]
COPY ["src/HousesPapon.Communication/HousesPapon.Communication.csproj", "src/HousesPapon.Communication/"]
COPY ["src/HousesPapon.Domain/HousesPapon.Domain.csproj", "src/HousesPapon.Domain/"]
COPY ["src/HousesPapon.Exception/HousesPapon.Exception.csproj", "src/HousesPapon.Exception/"]
COPY ["src/HousesPapon.Infrastructure/HousesPapon.Infrastructure.csproj", "src/HousesPapon.Infrastructure/"]
RUN dotnet restore "src/HousesPapon.API/HousesPapon.API.csproj"
COPY . .
WORKDIR "/src/src/HousesPapon.API"
RUN dotnet build "HousesPapon.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HousesPapon.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HousesPapon.API.dll"]