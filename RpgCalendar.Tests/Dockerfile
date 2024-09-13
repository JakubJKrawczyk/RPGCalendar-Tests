FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RpgCalendar.Tests/RpgCalendar.Tests.csproj", "RpgCalendar.Tests/"]
COPY ["RpgCalendar.WebService/RpgCalendar.WebService.csproj", "RpgCalendar.WebService/"]
COPY ["RpgCalendar.ApiClients/RpgCalendar.ApiClients.csproj", "RpgCalendar.ApiClients/"]
COPY ["RpgCalendar.Utilities/RpgCalendar.Utilities.csproj", "RpgCalendar.Utilities/"]
RUN dotnet restore "RpgCalendar.Tests/RpgCalendar.Tests.csproj"
COPY . .
WORKDIR "/src/RpgCalendar.Tests"
RUN dotnet build "RpgCalendar.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RpgCalendar.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet workload update

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "vstest", "RpgCalendar.Tests.dll", "--logger=\"apilogger\"", "--","NUnit.ShowInternalProperties=true"]
