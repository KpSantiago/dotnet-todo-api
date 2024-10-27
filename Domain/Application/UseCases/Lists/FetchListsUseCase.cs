using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.UseCases.Lists;

public class FetchListsUseCase
{
    private readonly IListsRepository ListsRepository;

    public FetchListsUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }

    public List[] Execute()
    {
        List[] lists = ListsRepository.FindMany();

        return lists;
    }
}