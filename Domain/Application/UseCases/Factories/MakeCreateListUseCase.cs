using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Lists;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeCreateListUseCase
{
    private readonly TodoContext _context;

    public MakeCreateListUseCase(TodoContext context)
    {
        _context = context;
    }
    public CreateListUseCase Factorie()
    {
        var listsRepository = new ListsRepository(_context);
        var createListUseCase = new CreateListUseCase(listsRepository);

        return createListUseCase;
    }
}
