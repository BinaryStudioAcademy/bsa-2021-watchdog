FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Notifier/Watchdog.Notifier.API/Watchdog.Notifier.API.csproj", "Watchdog.Notifier/Watchdog.Notifier.API/"]
COPY ["Watchdog.Notifier/Watchdog.Notifier.BLL/Watchdog.Notifier.BLL.csproj", "Watchdog.Notifier/Watchdog.Notifier.BLL/"]
COPY ["Watchdog.Notifier/Watchdog.Notifier.Common/Watchdog.Notifier.Common.csproj", "Watchdog.Notifier/Watchdog.Notifier.Common/"]
COPY ["Watchdog.RabbitMQ.Shared/Watchdog.RabbitMQ.Shared.csproj", "Watchdog.RabbitMQ.Shared/"]

RUN dotnet restore "Watchdog.Notifier/Watchdog.Notifier.API/Watchdog.Notifier.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Notifier/Watchdog.Notifier.API"
RUN dotnet build "Watchdog.Notifier.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Notifier.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Notifier.API.dll"]