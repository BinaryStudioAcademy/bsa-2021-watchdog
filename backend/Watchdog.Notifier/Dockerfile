#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Notifier.API/Watchdog.Notifier.API.csproj", "Watchdog.Notifier.API/"]
COPY ["Watchdog.Notifier.BLL/Watchdog.Notifier.BLL.csproj", "Watchdog.Notifier.BLL/"]
COPY ["Watchdog.Notifier.Common/Watchdog.Notifier.Common.csproj", "Watchdog.Notifier.Common/"]
RUN dotnet restore "Watchdog.Notifier.API/Watchdog.Notifier.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Notifier.API"
RUN dotnet build "Watchdog.Notifier.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Notifier.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Notifier.API.dll"]