using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Enterprise.Entities;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Lists;

[ApiController]
[Route("lists")]
[ApiExplorerSettings(GroupName = "Lists")]
public class CreateListController : ControllerBase
{
    private readonly TodoContext _context;

    public CreateListController(TodoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Handle(CreateListDTO list)
    {
        var createListUseCase = new MakeCreateListUseCase(_context).Factorie();
        List result = createListUseCase.Execute(list);

        return Created("lists", new { list = result });
    }
}
