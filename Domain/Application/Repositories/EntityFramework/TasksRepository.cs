using Task = api_dotnet.Domain.Enterprise.Entities.Task;
using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Infrastructure.Context;

namespace api_dotnet.Domain.Application.Repositories.EntityFramework;
public class TasksRepository : ITasksRepository
{
    private readonly TodoContext _context;

    public TasksRepository(TodoContext context)
    {
        _context = context;
    }

    public void Create(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void Delete(Task task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }

    public Task FindById(string id)
    {
        Task task = _context.Tasks.Find(id);

        return task;
    }

    public Task[] FindMany()
    {
        Task[] tasks = _context.Tasks.ToArray();

        return tasks;
    }

    public void Update(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }
}