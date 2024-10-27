using api_dotnet.Domain.Application.UseCases.Errors;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Tasks;

[ApiController]
[Route("tasks/{id}/delete")]
[ApiExplorerSettings(GroupName = "Tasks")]
public class DeleteTaskController : ControllerBase
{
    private readonly TodoContext _context;

    public DeleteTaskController(TodoContext context)
    {
        _context = context;
    }

    [HttpDelete]
    public IActionResult Handle(string id)
    {
        try
        {
            var deleteTaskUseCase = new MakeDeleteTaskUseCase(_context).Factorie();
            deleteTaskUseCase.Execute(id);

            return NoContent();
        }
        catch (RegisterNotFoundException ex)
        {
            return NotFound(new { message = ex.Message, statudCode = 404, error = "Not Found" });
        }
    }
}
