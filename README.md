# BSA 2021 | Watchdog

Binary Studio Academy | 2021 | .NET Watchdog platform for analyzing applications. It is an analog of Sentry, Raygun, Gatling.

[DEMO](https://imgur.com/a/5qD8VCp)

## Production:
- [bsa-watchdog.westeurope.cloudapp.azure.com](https://bsa-watchdog.westeurope.cloudapp.azure.com)
- [Docker Images](https://hub.docker.com/repositories/vobilyk)

## Building sources
By default, apps run on the following ports:

| Application | Port |
|-|-|
| Watchdog.**Core** | 5050 |
| Watchdog.**Notifier** | 5070 |
| Watchdog.**Collector** | 5090 |
| Watchdog.**Angular** | 80 or 4200 |
| RabbitMQ | 5672 |
| Elasticsearch | 9200 |
| Kibana | 5601 |

#### Docker:
1. Make sure you have [Docker](https://www.docker.com) and [Docker Compose](https://docs.docker.com/compose/install).
2. Pull this repo to your machine.
3. You can build and run all application containers via `docker-compose -f docker-compose.apps.yml up -d` command.
4. You can pull and run all 3rd-party services (Vault,ELK,RabbitMQ) via `docker-compose -f docker-compose.services.yml up -d` command.
5. Happy coding! :sunglasses:

## Environment variables
This is a list of the required environment variables:

#### RabbitMQ:
**RABBIT_MQ_USERNAME** - for username,
**RABBIT_MQ_PASSWORD** - for user password
