FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Collector/Watchdog.Collector.API/Watchdog.Collector.API.csproj", "Watchdog.Collector/Watchdog.Collector.API/"]
COPY ["Watchdog.Collector/Watchdog.Collector.BLL/Watchdog.Collector.BLL.csproj", "Watchdog.Collector/Watchdog.Collector.BLL/"]
COPY ["Watchdog.Collector/Watchdog.Collector.Common/Watchdog.Collector.Common.csproj", "Watchdog.Collector/Watchdog.Collector.Common/"]
COPY ["Watchdog.RabbitMQ.Shared/Watchdog.RabbitMQ.Shared.csproj", "Watchdog.RabbitMQ.Shared/"]

RUN dotnet restore "Watchdog.Collector/Watchdog.Collector.API/Watchdog.Collector.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Collector/Watchdog.Collector.API"
RUN dotnet build "Watchdog.Collector.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Collector.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Collector.API.dll"]