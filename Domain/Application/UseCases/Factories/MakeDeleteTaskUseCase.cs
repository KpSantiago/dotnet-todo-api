using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Tasks;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeDeleteTaskUseCase
{
    private readonly TodoContext _context;

    public MakeDeleteTaskUseCase(TodoContext context)
    {
        _context = context;
    }
    public DeleteTaskUseCase Factorie()
    {
        var tasksRepository = new TasksRepository(_context);
        var deleteTaskUseCase = new DeleteTaskUseCase(tasksRepository);

        return deleteTaskUseCase;
    }
}
