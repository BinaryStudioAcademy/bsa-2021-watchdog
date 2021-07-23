FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Collector.API/Watchdog.Collector.API.csproj", "Watchdog.Collector.API/"]
COPY ["Watchdog.Collector.BLL/Watchdog.Collector.BLL.csproj", "Watchdog.Collector.BLL/"]

RUN dotnet restore "Watchdog.Collector.API/Watchdog.Collector.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Collector.API"
RUN dotnet build "Watchdog.Collector.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Collector.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Collector.API.dll"]