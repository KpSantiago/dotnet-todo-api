using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Application.UseCases.Exceptions;

namespace api_dotnet.Domain.Application.UseCases.Lists;

public class DeleteListUseCase
{
    private readonly IListsRepository ListsRepository;

    public DeleteListUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }

    public void Execute(string id)
    {
        var list = ListsRepository.FindById(id);

        if (list == null)
        {
            throw new RegisterNotFoundException("A lista não foi encontrada.");
        }

        ListsRepository.Delete(list);
    }
}
