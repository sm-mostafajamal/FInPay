FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY FinApp.sln .
COPY FinApp.API/FinApp.API.csproj FinApp.API/
COPY FinApp.Application/FinApp.Application.csproj FinApp.Application/
COPY FinApp.Contracts/FinApp.Contracts.csproj FinApp.Contracts/
COPY FinApp.Domain/FinApp.Domain.csproj FinApp.Domain/
COPY FinApp.Infrastructure/FinApp.Infrastructure.csproj FinApp.Infrastructure/

RUN dotnet restore FinApp.sln

COPY . .

# ---- Release publish (for production) ----
RUN dotnet publish FinApp.API/FinApp.API.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ---- Debug publish (unoptimized, full PDBs) ----
RUN dotnet publish FinApp.API/FinApp.API.csproj \
    -c Debug \
    -o /app/publish-debug \
    --no-restore \
    -p:DebugType=portable \
    -p:Optimize=false

# ---- Debug tools stage (only built when targeted) ----
FROM build AS debugtools
RUN apt-get update && apt-get install -y curl unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg \
    && rm -rf /var/lib/apt/lists/*

# ---- Production runtime (default, no debugger) ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FinApp.API.dll"]

# ---- Debug runtime (used only in docker-compose for local dev) ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS debug
WORKDIR /app
COPY --from=build /app/publish-debug .
COPY --from=debugtools /vsdbg /vsdbg
EXPOSE 8080
ENTRYPOINT ["dotnet", "FinApp.API.dll"]