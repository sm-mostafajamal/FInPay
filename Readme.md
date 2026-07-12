docker build --no-cache -f docker/Dockerfile -t finapp-api src/backend

docker compose -f docker/docker-compose.yml up --build -d