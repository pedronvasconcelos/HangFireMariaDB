English version:

# POC: MariaDB + Hangfire with .NET 6

This is a Proof of Concept (POC) project demonstrating the integration of MariaDB and Hangfire in a .NET 6 application. The purpose of this POC is to show how to use MariaDB as the data storage for Hangfire to manage background tasks in a .NET 6 application.

## Prerequisites

- .NET 6 SDK
- MariaDB server

## Getting Started

1. Clone the repository.
2. Update the `appsettings.json` file with your MariaDB connection string.
3. Run the `createtable.sql` script in the `sql` folder to create the necessary table.
4. Run `dotnet restore` to install the required NuGet packages.
5. Run `dotnet run` to start the application.
6. Access the Hangfire Dashboard at http://localhost:5000/hangfire.

## Docker

You can also run this project using Docker. To do so, simply follow these steps:

1. Clone the repository.
2. Update the `appsettings.json` file with your MariaDB connection string.
3. Run the `createtable.sql` script in the `sql` folder to create the necessary table.
4. Build the Docker image using the `Dockerfile` provided.
5. Run the Docker container using the image built in the previous step.
6. Access the Hangfire Dashboard at http://localhost:5000/hangfire.

## Features

- MariaDB integration for data storage.
- Hangfire for managing background tasks.
- .NET 6 application.



PT-BR

# POC: MariaDB + Hangfire com .NET 6

Este é um projeto de Prova de Conceito (POC) que demonstra a integração do MariaDB e Hangfire em uma aplicação .NET 6. O objetivo desta POC é mostrar como usar o MariaDB como armazenamento de dados para o Hangfire gerenciar tarefas em segundo plano em uma aplicação .NET 6.

## Pré-requisitos

- SDK .NET 6
- Servidor MariaDB

## Iniciando

1. Clone o repositório.
2. Atualize o arquivo `appsettings.json` com sua connection string do MariaDB.
3. Execute o script `createtable.sql` na pasta `sql` para criar a tabela necessária.
4. Execute `dotnet restore` para instalar os pacotes NuGet necessários.
5. Execute `dotnet run` para iniciar a aplicação.
6. Acesse o Hangfire Dashboard em `http://localhost:5000/hangfire`.

## Docker

Você também pode executar este projeto usando o Docker. Para fazer isso, siga estas etapas:

1. Clone o repositório.
2. Atualize o arquivo `appsettings.json` com sua connection string do MariaDB.
3. Execute o script `createtable.sql` na pasta `sql` para criar a tabela necessária.
4. Crie a imagem Docker usando o `Dockerfile` fornecido.
5. Execute o container Docker usando a imagem criada no passo anterior.
6. Acesse o Hangfire Dashboard em `http://localhost:5000/hangfire`.

## Funcionalidades

- Integração com MariaDB para armazenamento de dados.
- Hangfire para gerenciamento de tarefas em segundo plano.
- Aplicação .NET 6.
