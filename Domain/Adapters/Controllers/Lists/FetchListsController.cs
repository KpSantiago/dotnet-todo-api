using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Enterprise.Entities;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Lists;

[ApiController]
[Route("lists")]
[ApiExplorerSettings(GroupName = "Lists")]
public class FetchListsController : ControllerBase
{
    private readonly TodoContext _context;

    public FetchListsController(TodoContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Handle()
    {
        var fetchListsUseCase = new MakeFetchListsUseCase(_context).Factorie();
        List[] lists = fetchListsUseCase.Execute();

        return Ok(new { lists });
    }
}
