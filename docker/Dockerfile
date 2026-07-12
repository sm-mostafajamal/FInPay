FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy only solution and project files first
COPY FinApp.sln .

COPY FinApp.API/FinApp.API.csproj FinApp.API/
COPY FinApp.Application/FinApp.Application.csproj FinApp.Application/
COPY FinApp.Contracts/FinApp.Contracts.csproj FinApp.Contracts/
COPY FinApp.Domain/FinApp.Domain.csproj FinApp.Domain/
COPY FinApp.Infrastructure/FinApp.Infrastructure.csproj FinApp.Infrastructure/

# Restore dependencies
RUN dotnet restore FinApp.sln

# Copy the remaining source code
COPY . .

# Build and publish
RUN dotnet publish FinApp.API/FinApp.API.csproj \
    -c Release \
    -o /app/publish \
    --no-restore


# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "FinApp.API.dll"]