FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Core.API/Watchdog.Core.API.csproj", "Watchdog.Core.API/"]
COPY ["Watchdog.Core.BLL/Watchdog.Core.BLL.csproj", "Watchdog.Core.BLL/"]
COPY ["Watchdog.Core.DAL/Watchdog.Core.DAL.csproj", "Watchdog.Core.DAL/"]
COPY ["Watchdog.Core.Common/Watchdog.Core.Common.csproj", "Watchdog.Core.Common/"]

RUN dotnet restore "Watchdog.Core.API/Watchdog.Core.API.csproj"
COPY . .
WORKDIR "/src/Watchdog.Core.API"
RUN dotnet build "Watchdog.Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Core.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchdog.Core.API.dll"]