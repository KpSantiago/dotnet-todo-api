using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Tasks;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeFetchTasksUseCase
{
    private readonly TodoContext _context;

    public MakeFetchTasksUseCase(TodoContext context)
    {
        _context = context;
    }
    
    public FetchTasksUseCase Factorie()
    {
        var tasksRepository = new TasksRepository(_context);
        var fetchTasksUseCase = new FetchTasksUseCase(tasksRepository);

        return fetchTasksUseCase;
    }
}
