#nullable enable

using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Application.UseCases.Errors;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.UseCases.Lists;

public class GetListUseCase
{
    private readonly IListsRepository ListsRepository;

    public GetListUseCase(IListsRepository listsRepository)
    {
        ListsRepository = listsRepository;
    }

    public List Execute(string id)
    {
        var list = ListsRepository.FindById(id);

         if(list == null)
        {
            throw new RegisterNotFoundException("A lista não foi encontrada.");
        }

        return new List() {
            Id = list.Id,
            Title = list.Title,
            CreatedAt = list.CreatedAt,
            Tasks = list.Tasks.ToArray()
        };
    }
}