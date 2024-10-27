using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.Repositories;
using Task = api_dotnet.Domain.Enterprise.Entities.Task;

namespace api_dotnet.Domain.Application.UseCases.Tasks;

public class CreateTaskUseCase
{
    private ITasksRepository TasksRepository { get; set; }

    public CreateTaskUseCase(ITasksRepository tasksRepository)
    {
        TasksRepository = tasksRepository;
    }

    public Task Execute(CreateTasksDTO data)
    {
        Task task = new()
        {
            Title = data.Title,
            ListId = data.ListId,
            Checked = false
        };

        TasksRepository.Create(task);

        return task;
    }
}
