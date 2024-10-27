using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Tasks;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeEditTaskUseCase
{
    private readonly TodoContext _context;

    public MakeEditTaskUseCase(TodoContext context)
    {
        _context = context;
    }

    public EditTaskUseCase Factorie()
    {
        var tasksRepository = new TasksRepository(_context);
        var listsRepository = new ListsRepository(_context);
        var editTaskUseCase = new EditTaskUseCase(tasksRepository, listsRepository);

        return editTaskUseCase;
    }
}
