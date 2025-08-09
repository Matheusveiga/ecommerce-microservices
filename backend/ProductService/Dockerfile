FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

RUN apt-get update && apt-get install -y netcat-openbsd && rm -rf /var/lib/apt/lists/*

COPY wait-for-rabbitmq.sh .
RUN chmod +x wait-for-rabbitmq.sh

ENTRYPOINT ["./wait-for-rabbitmq.sh", "dotnet", "ProductService.dll"]
