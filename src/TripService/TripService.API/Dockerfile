FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY MicroservicesPlatform.sln .
COPY src/TripService/TripService.API/TripService.API.csproj src/TripService/TripService.API/
COPY src/TripService/TripService.Domain/TripService.Domain.csproj src/TripService/TripService.Domain/

RUN dotnet restore src/TripService/TripService.API/TripService.API.csproj

COPY src/TripService/ src/TripService/

RUN dotnet publish src/TripService/TripService.API/TripService.API.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
RUN apt-get update && apt-get install -y --no-install-recommends curl && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TripService.API.dll"]
