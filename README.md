# ToDoList Web API

A ToDoList Web API é uma aplicação simples que permite a criação, leitura e atualização de tarefas em um banco de dados SQL Server usando o Dapper como ORM.

## Pré-requisitos

Antes de executar a aplicação, verifique se você possui o seguinte instalado:

- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Configuração

1. Clone este repositório em sua máquina local:

2. Edite o arquivo appsettings.json para configurar a conexão com o banco de dados SQL Server:

"ConnectionStrings": {
    "DefaultConnection": "sua-string-de-conexao-aqui"
}

3. Execute a query contida na pasta CriarBanco em seu sql server

4. Agora basta apenas executar a aplicação, pode testa-la usando swagger ou postman
