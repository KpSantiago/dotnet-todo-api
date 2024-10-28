using api_dotnet.Domain.Application.Repositories;
using api_dotnet.Domain.Application.UseCases.Exceptions;

namespace api_dotnet.Domain.Application.UseCases.Tasks;

public class DeleteTaskUseCase
{
    private readonly ITasksRepository TasksRepository;

    public DeleteTaskUseCase(ITasksRepository tasksRepository)
    {
        TasksRepository = tasksRepository;
    }

    public void Execute(string id)
    {
        var task = TasksRepository.FindById(id);

        if (task == null)
        {
            throw new RegisterNotFoundException("A taska não foi encontrada.");
        }

        TasksRepository.Delete(task);
    }
}
