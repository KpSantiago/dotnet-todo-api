#nullable enable

using Task = api_dotnet.Domain.Enterprise.Entities.Task;

namespace api_dotnet.Domain.Application.Repositories;
public interface ITasksRepository
{
    public void Create(Task task);
    public void Update(Task task);
    public Task? FindById(string id);
    public Task[] FindMany();
    public void Delete(Task task);
}