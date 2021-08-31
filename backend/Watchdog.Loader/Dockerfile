FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Loader/Watchdog.Loader.API/Watchdog.Loader.API.csproj", "Watchdog.Loader/Watchdog.Loader.API/"]
COPY ["Watchdog.Loader/Watchdog.Loader.BLL/Watchdog.Loader.BLL.csproj", "Watchdog.Loader/Watchdog.Loader.BLL/"]
COPY ["Watchdog.Loader/Watchdog.Loader.Common/Watchdog.Loader.Common.csproj", "Watchdog.Loader/Watchdog.Loader.Common/"]
COPY ["Watchdog.RabbitMQ.Shared/Watchdog.RabbitMQ.Shared.csproj", "Watchdog.RabbitMQ.Shared/"]
COPY ["Watchdog.Models.Shared/Watchdog.Models.Shared.csproj", "Watchdog.Models.Shared/"]

RUN dotnet restore "Watchdog.Loader/Watchdog.Loader.API/Watchdog.Loader.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Loader/Watchdog.Loader.API"
RUN dotnet build "Watchdog.Loader.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Loader.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Loader.API.dll"]