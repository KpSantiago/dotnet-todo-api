#nullable enable

using api_dotnet.Domain.Enterprise.Entities;

namespace api_dotnet.Domain.Application.Repositories;

public interface IListsRepository
{
    public void Create(List list);
    public List[] FindMany();
    public List? FindById(string id);
    public void Update(List list);
    public void Delete(List list);
}
