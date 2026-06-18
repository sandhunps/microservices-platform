FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY MicroservicesPlatform.sln .
COPY src/NotificationService/NotificationService.API/NotificationService.API.csproj src/NotificationService/NotificationService.API/
COPY src/NotificationService/NotificationService.Domain/NotificationService.Domain.csproj src/NotificationService/NotificationService.Domain/

RUN dotnet restore src/NotificationService/NotificationService.API/NotificationService.API.csproj

COPY src/NotificationService/ src/NotificationService/

RUN dotnet publish src/NotificationService/NotificationService.API/NotificationService.API.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "NotificationService.API.dll"]
