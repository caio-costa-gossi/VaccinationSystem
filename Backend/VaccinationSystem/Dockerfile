# Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore src/VaccinationSystem.Api/VaccinationSystem.Api.csproj
RUN dotnet publish src/VaccinationSystem.Api/VaccinationSystem.Api.csproj -c Debug -o /app/publish

# Prepare execution
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS execute
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_ENVIRONMENT=Development

# Execute
ENTRYPOINT ["dotnet", "VaccinationSystem.Api.dll"]