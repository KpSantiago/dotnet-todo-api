using api_dotnet.Domain.Application.Repositories;
using Task = api_dotnet.Domain.Enterprise.Entities.Task;

namespace api_dotnet.Domain.Application.UseCases.Tasks;

public class FetchTasksUseCase
{
    private readonly ITasksRepository TasksRepository;

    public FetchTasksUseCase(ITasksRepository tasksRepository)
    {
        TasksRepository = tasksRepository;
    }

    public Task[] Execute()
    {
        Task[] tasks = TasksRepository.FindMany();

        return tasks;
    }
}