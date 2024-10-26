using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.UseCases;

public class CreateListDTO
{
    public string Title;
}

public class CreateListUseCaseResponse
{
    public List List { get; }

    public CreateListUseCaseResponse(List list)
    {
        List = list;
    }
}

public class CreateListUseCase
{
    private IListsRepository ListsRepository { get; set; }
    public CreateListUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }
    public CreateListUseCaseResponse Execute(CreateListDTO data)
    {
        List list = new()
        {
            Title = data.Title
        };

        ListsRepository.Create(list);

        return new CreateListUseCaseResponse(list);
    }
}
