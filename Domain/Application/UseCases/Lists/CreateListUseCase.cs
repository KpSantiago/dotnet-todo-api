using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.UseCases.Lists;

public class CreateListUseCase
{
    private IListsRepository ListsRepository { get; set; }

    public CreateListUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }

    public List Execute(CreateListDTO data)
    {
        List list = new()
        {
            Title = data.Title
        };

        ListsRepository.Create(list);

        return list;
    }
}
