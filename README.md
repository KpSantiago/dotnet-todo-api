# API em .NET

**API(Application Programming Interfce):** é uma interface de programação responsável por realizar a comunicação entre aplicações, sendo um meio pelo qual os dados passam até chegar ao seu destino.

**Comandos:**
`dotnet new webapi`: cria um projeto de API web
`dotnet watch run`: incia a API.

- `watch` vai ser responsável por ficar vendo alterações e fazer o reload da API

**Arquivo root da API**

```csharp
// Program.cs

// Inicia a construação da API web, configurando-a como base nos argumentos passados.
var builder = WerbApplication.CreateBuilder(args);

// Adiciona o suporte aos constroller da API web
builder.Services.AddConstrollers();

// cónstroi a aplicação da API após realizar suas configuraçãoes
var app = builder.Build();

// Configura a API para transformar as requisições de HTTP para HTTPS
app.UseHttpsRedirection();

// Mapeia os controllers da aplicação, permitindo-a localizá-los e lider com as requisições
app.MapControllers();

// Inicia a aplicação
app.Run()
```

**Controller:**

```csharp
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController] // define a classe como um controlle
[Route("[controller]")] // define um rota para os  endpoints do controller
public class ApiController : ControllerBase
{
    [HttpGet("endpoint")] // define um endpoint para a aplicação, além do seu método
    // IActionResult: interface que vai implmentar um contrato para uma ação do controller
    public IActionResult Handle()
    {
        // Ok(): método que represeta o ststus 200 de uma resultado de API
        return Ok(new { message = "Hello World!!" });
    }
}
```

## Entity FrameWork

É um framwork ORM (Object-Realtional Mapping) criado para facilitar a integração com banco de dados no .NET, mapenado tabelas e gerando comandos SQL atomaticamente.

**Instalando pacotes:**
**`dotnet tool install --global dotnet-ef`**: `CLI` que utiliazamos para executar comandos do `Entity Framework` pelo terminal.
**`dotnet add package Microsoft.EntityFrameworkCore.Design`**
**`dotnet add package Microsoft.EntityFrameworkCore.SqlServer`**

### Entity Framework na prática

Para que sea possível para o Entity Framework criar uma tabelas no banco de dados é necessário criar entidades que farão referência a elas.

**Ex:**

```csharp
namespace api_dotnet.Entities;
public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public bool Ativo { get; set; }
}
```

**Context:** classe que centraliza todas as informações em determinado banco de dados.

```csharp
// Crianco context para o banco de dados
using api_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Context;

public class MyDBContext : DbContext
{
    // inicializando a configuração do banco de daodos
    public MyDBContext(DbContextOptions<MyDBContext> opitions) : base(options: options) {}

    public DbSet<Contato> Contatos { get; set; }
}
```

```json
// appsettings.Development.json
{
    "ConnectionStrings": {
        // url de conexão com o SQL Server
        "connection": "Server=localhost\\sqlexpress; Intial Catalog=Agenda; Integrated Security=True"
    },
    "Logging": {...}
}
```

```csharp
// Program.cs

// Adicionando o servbiço do DbContext do banco de dados
builder.Services.AddDbContext<MyDBContext>(
    options => options.UseSqlServer(
        // resgatando a url de conexão do arquivo appsettings.Development.json
        builder.Configuration.GetConnectionString("connection")
    )
);
```

**Utilizando a CLI do EF para criar migrations:**

**`dotnet-ef migrations add <migration-name>`**: adiciona uma nova mmigration
**`dotnet-ef database update`**: vai procurar mundanças ocorridas e aplicá-las ao banco de dados

### Persistência de dados

#### Create

```csharp
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class CreateRegisterController : ControllerBase
{
    private readonly MyDbContext _context;
    public CreateRegisterController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult handle(Contato contato)
    {
        _context.Add(contato);
        _context.SaveChanges();
        return Ok(new {
            message = "registro criado com sucesso",
            contato
        })
    }
}
```

