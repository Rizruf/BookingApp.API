FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "BookingApp.API/BookingApp.API/BookingApp.API.csproj"
RUN dotnet build "BookingApp.API/BookingApp.API/BookingApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingApp.API/BookingApp.API/BookingApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingApp.API.dll"]