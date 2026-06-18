FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY MicroservicesPlatform.sln .
COPY src/BookingService/BookingService.API/BookingService.API.csproj src/BookingService/BookingService.API/
COPY src/BookingService/BookingService.Domain/BookingService.Domain.csproj src/BookingService/BookingService.Domain/

RUN dotnet restore src/BookingService/BookingService.API/BookingService.API.csproj

COPY src/BookingService/ src/BookingService/

RUN dotnet publish src/BookingService/BookingService.API/BookingService.API.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "BookingService.API.dll"]
