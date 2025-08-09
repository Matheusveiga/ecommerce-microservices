#!/bin/sh

# Espera até o rabbitmq estar disponível na porta 5672

set -e

host="rabbitmq"
port=5672

echo "Aguardando RabbitMQ em $host:$port..."

while ! nc -z $host $port; do
  echo "RabbitMQ não disponível ainda - aguardando..."
  sleep 2
done

echo "RabbitMQ está disponível! Iniciando o serviço..."

exec "$@"
