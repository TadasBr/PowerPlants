FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PowerPlants.API/PowerPlants.API.csproj", "PowerPlants.API/"]
COPY ["PowerPlants.Business/PowerPlants.Business.csproj", "PowerPlants.Business/"]
COPY ["PowerPlants.Persistence/PowerPlants.Persistence.csproj", "PowerPlants.Persistence/"]
RUN dotnet restore "PowerPlants.API/PowerPlants.API.csproj"
COPY . .
WORKDIR "/src/PowerPlants.API"
RUN dotnet build "PowerPlants.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerPlants.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerPlants.API.dll"]