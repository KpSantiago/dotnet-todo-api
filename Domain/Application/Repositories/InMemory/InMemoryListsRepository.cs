using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.Repositories.InMemory;

public class InMemoryListsRepository : IListsRepository
{
    public List<List> items = new();
    public void Create(List list)
    {
        items.Add(list);
    }

    public void Delete(List list)
    {
        throw new NotImplementedException();
    }


    public List FindById(string id)
    {
        throw new NotImplementedException();
    }


    public List[] FindMany()
    {
        throw new NotImplementedException();
    }

    public void Update(List list)
    {
        throw new NotImplementedException();
    }
}
