using api_dotnet.Domain.Application.UseCases.Exceptions;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Enterprise.Entities;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Lists;

[ApiController]
[Route("lists/{id}")]
[ApiExplorerSettings(GroupName = "Lists")]
public class GetListsController : ControllerBase
{
    private readonly TodoContext _context;

    public GetListsController(TodoContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Handle(string id)
    {
        try
        {
            var getListUseCase = new MakeGetListUseCase(_context).Factorie();
            var lists = getListUseCase.Execute(id);

            return Ok(new { lists });
        }
        catch (RegisterNotFoundException ex)
        {

            return NotFound(new { message = ex.Message, statudCode = 404, error = "Not Found" });
        }
    }
}
