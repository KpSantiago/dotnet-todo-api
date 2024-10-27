using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Application.UseCases.Errors;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.UseCases.Lists;

public class EditListUseCase
{
    private readonly IListsRepository ListsRepository;

    public EditListUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }

    public List Execute(EditListDTO data, string id)
    {
        var list = ListsRepository.FindById(id);

        if(list == null)
        {
            throw new RegisterNotFoundException("A lista não foi encontrada.");
        }

        list.Title = data.Title;

        ListsRepository.Update(list);

        return list;
    }
}
