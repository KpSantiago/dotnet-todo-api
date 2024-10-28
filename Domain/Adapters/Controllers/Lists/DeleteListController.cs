using api_dotnet.Domain.Application.UseCases.Exceptions;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Lists;

[ApiController]
[Route("lists/{id}/delete")]
[ApiExplorerSettings(GroupName = "Lists")]
public class DeleteListController : ControllerBase
{
    private readonly TodoContext _context;

    public DeleteListController(TodoContext context)
    {
        _context = context;
    }

    [HttpDelete]
    public IActionResult Handle(string id)
    {
        try
        {
            var deleteListUseCase = new MakeDeleteListUseCase(_context).Factorie();
            deleteListUseCase.Execute(id);

            return NoContent();
        }
        catch (RegisterNotFoundException ex)
        {
            return NotFound(new { message = ex.Message, statudCode = 404, error = "Not Found" });
        }
    }
}
