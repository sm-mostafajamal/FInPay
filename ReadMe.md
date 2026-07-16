## Build Only Image
docker build -f docker/Dockerfile -t finapp-api src/backend

## Rebuild the image (if required) and start the containers
docker compose -f docker/docker-compose.yml up -d --build 

docker compose -f docker/docker-compose.yml -f docker/docker-compose.debug.yml build --no-cache finapp-api

## For Hot Reload Local
docker compose -f docker/docker-compose.yml up -d db &&
cd src/backend &&
dotnet watch run --project FinApp.API/FinApp.API.csproj --urls http://localhost:8080

