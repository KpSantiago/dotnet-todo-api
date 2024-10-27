using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Application.UseCases.Errors;
using Task = api_dotnet.Domain.Enterprise.Entities.Task;

namespace api_dotnet.Domain.Application.UseCases.Tasks;

public class EditTaskUseCase
{
    private readonly ITasksRepository TasksRepository;
    private readonly IListsRepository ListsRepository;

    public EditTaskUseCase(ITasksRepository tasksRepository, IListsRepository listsRepository)
    {
        TasksRepository = tasksRepository;
        ListsRepository = listsRepository;
    }

    public Task Execute(EditTaskDTO data, string id)
    {
        var list = ListsRepository.FindById(data.ListId);

        if (list == null)
        {
            throw new RegisterNotFoundException("A lista não foi encontrada.");
        }

        var task = TasksRepository.FindById(id);

        if (task == null)
        {
            throw new RegisterNotFoundException("A task não foi encontrada.");
        }

        task.Title = data.Title;

        TasksRepository.Update(task);

        return task;
    }
}
