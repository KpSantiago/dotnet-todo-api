using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Lists;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeGetListUseCase
{
    private readonly TodoContext _context;

    public MakeGetListUseCase(TodoContext context)
    {
        _context = context;
    }
    
    public GetListUseCase Factorie()
    {
        var listsRepository = new ListsRepository(_context);
        var getListsUseCase = new GetListUseCase(listsRepository);

        return getListsUseCase;
    }
}
