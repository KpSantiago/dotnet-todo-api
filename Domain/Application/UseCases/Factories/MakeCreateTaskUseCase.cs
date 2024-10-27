using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Tasks;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeCreateTaskUseCase
{
    private readonly TodoContext _context;

    public MakeCreateTaskUseCase(TodoContext context)
    {
        _context = context;
    }
    public CreateTaskUseCase Factorie()
    {
        var tasksRepository = new TasksRepository(_context);
        var createTaskUseCase = new CreateTaskUseCase(tasksRepository);

        return createTaskUseCase;
    }
}
