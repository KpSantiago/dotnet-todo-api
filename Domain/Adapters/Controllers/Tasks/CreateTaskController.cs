using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.UseCases.Factories;
using Task = api_dotnet.Domain.Enterprise.Entities.Task;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Tasks;

[ApiController]
[Route("tasks")]
[ApiExplorerSettings(GroupName = "Tasks")]
public class CreateTasksController : ControllerBase
{
    private readonly TodoContext _context;

    public CreateTasksController(TodoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Handle(CreateTasksDTO tasks)
    {
        var createTasksUseCase = new MakeCreateTaskUseCase(_context).Factorie();
        Task result = createTasksUseCase.Execute(tasks);

        return Created("tasks", new { tasks = result });
    }
}
