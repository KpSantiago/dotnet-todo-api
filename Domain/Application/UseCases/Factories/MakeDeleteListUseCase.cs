using api_dotnet.Domain.Application.Repositories.EntityFramework;
using api_dotnet.Domain.Application.UseCases.Lists;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.UseCases.Factories;

public class MakeDeleteListUseCase
{
    private readonly TodoContext _context;

    public MakeDeleteListUseCase(TodoContext context)
    {
        _context = context;
    }
    public DeleteListUseCase Factorie()
    {
        var listsRepository = new ListsRepository(_context);
        var deleteListUseCase = new DeleteListUseCase(listsRepository);

        return deleteListUseCase;
    }
}
