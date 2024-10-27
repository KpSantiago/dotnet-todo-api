using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.UseCases.Errors;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Tasks;

[ApiController]
[Route("tasks/{id}/update")]
[ApiExplorerSettings(GroupName = "Tasks")]
public class EditTaskController : ControllerBase
{
    private readonly TodoContext _context;

    public EditTaskController(TodoContext context)
    {
        _context = context;
    }

    [HttpPatch]
    public IActionResult Handle(EditTaskDTO data, string id)
    {
        try
        {
            var editTaskUseCase = new MakeEditTaskUseCase(_context).Factorie();
            var task = editTaskUseCase.Execute(data, id);

            return Ok(new { message = "Taska editada com sucesso.", task });
        }
        catch (RegisterNotFoundException ex)
        {
            return NotFound(new { message = ex.Message, statudCode = 404, error = "Not Found" });
        }
    }
}
