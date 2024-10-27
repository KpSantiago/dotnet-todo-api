using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("connection")
        )
);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Impede as referências dos ciclos de objetos
    /* libs:
    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
    dotnet add package Newtonsoft.Json
    */
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Todo-List API", Version = "v1" });

    // Configurando agrupamento de rotas
    s.TagActionsBy(api =>
    {
        return new List<string>()
        {
            api.GroupName
        };
    });

    s.DocInclusionPredicate((_, api) => true);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

