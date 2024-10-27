using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Lists;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeFetchListsUseCase
{
    private readonly TodoContext _context;

    public MakeFetchListsUseCase(TodoContext context)
    {
        _context = context;
    }
    
    public FetchListsUseCase Factorie()
    {
        var listsRepository = new ListsRepository(_context);
        var fetchListsUseCase = new FetchListsUseCase(listsRepository);

        return fetchListsUseCase;
    }
}
