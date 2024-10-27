using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Task = api_dotnet.Domain.Enterprise.Entities.Task;

namespace api_dotnet.Domain.Adapters.Controllers.Tasks;

[ApiController]
[Route("tasks")]
[ApiExplorerSettings(GroupName = "Tasks")]
public class FetchTasksController : ControllerBase
{
    private readonly TodoContext _context;

    public FetchTasksController(TodoContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Handle()
    {
        var fetchTasksUseCase = new MakeFetchTasksUseCase(_context).Factorie();
        Task[] tasks = fetchTasksUseCase.Execute();

        return Ok(new { tasks });
    }
}
