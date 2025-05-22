# Razor Pages Filmes - Um CRUD com ASP.NET MVC#

Este projeto é um CRUD de filmes utilizando ASP.NET MVC e páginas Razor, fazendo parte do meu aprendizado em C# e ASP.NET e ASP.NET MVC. Este projeto é uma versão levemente diferente do RazorFilmes2025 (https://github.com/WesllenWorld/crud-filmes-asp.net).

Foram utilizados:
- ASP.NET MVC com .NET 8 SDK;
- Razor;
- EntityFrameworkCore.Design;
- SQL Server Express ou LocalDB;
- Um pouco de JavaScript e HTML.

## ▶️ Como Usar

1. Clone o repositório:
   ```bash
   git clone https://github.com/WesllenWorld/crud-filmes-asp-net-mvc.git
   ```
2. Restaure os pacotes:
   ```bash
   dotnet restore
   ```
3. Configure a connection string:
   O projeto está usando o SQL Server LocalDB por padrão. A string está em appsettings.json. No caso de usar outra instância do SQL Server, ajuste a propriedade Server.
   
4. Crie o banco com o Entity Framework Core:
    ```bash
   dotnet ef database update
   ```
5. Rode a aplicação
    ```bash
   dotnet run
   ```
