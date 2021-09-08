FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Watchdog.Emailer/Watchdog.Emailer.Service/Watchdog.Emailer.Service.csproj", "Watchdog.Emailer/Watchdog.Emailer.Service/"]
COPY ["Watchdog.Core/Watchdog.Core.Common/Watchdog.Core.Common.csproj", "Watchdog.Core/Watchdog.Core.Common/"]
COPY ["Watchdog.RabbitMQ.Shared/Watchdog.RabbitMQ.Shared.csproj", "Watchdog.RabbitMQ.Shared/"]
COPY ["Watchdog.Models.Shared/Watchdog.Models.Shared.csproj", "Watchdog.Models.Shared/"]

RUN dotnet restore "Watchdog.Emailer/Watchdog.Emailer.Service/Watchdog.Emailer.Service.csproj"
COPY . .
WORKDIR "/src/Watchdog.Emailer/Watchdog.Emailer.Service"
RUN dotnet build "Watchdog.Emailer.Service.csproj" -c Release -o /app/build

FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Watchdog.Emailer.Service.dll"]