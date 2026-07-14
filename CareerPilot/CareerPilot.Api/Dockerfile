FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["CareerPilot.Api/CareerPilot.Api.csproj", "CareerPilot.Api/"]
COPY ["CareerPilot.Application/CareerPilot.Application.csproj", "CareerPilot.Application/"]
COPY ["CareerPilot.Infrastructure/CareerPilot.Infrastructure.csproj", "CareerPilot.Infrastructure/"]
COPY ["CareerPilot.Domain/CareerPilot.Domain.csproj", "CareerPilot.Domain/"]
RUN dotnet restore "CareerPilot.Api/CareerPilot.Api.csproj"

COPY . .

WORKDIR "/src/CareerPilot.Api"
RUN dotnet build "./CareerPilot.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CareerPilot.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CareerPilot.Api.dll"]