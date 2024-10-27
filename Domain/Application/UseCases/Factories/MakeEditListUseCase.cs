using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Lists;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeEditListUseCase
{
    private readonly TodoContext _context;

    public MakeEditListUseCase(TodoContext context)
    {
        _context = context;
    }

    public EditListUseCase Factorie()
    {
        var listsRepository = new ListsRepository(_context);
        var editListUseCase = new EditListUseCase(listsRepository);

        return editListUseCase;
    }
}
