
using TaskManager.Models;

namespace TaskManager.Services.Interfaces
{
    public interface ITaskService
    {
        Task <List<CreateTaskModel>> GetAllTasks();
        Task <CreateTaskModel> GetTaskById(int id);
        Task <bool> AddTask(CreateTaskModel task);
        Task <bool> UpdateTask(int id, CreateTaskModel task);
        Task <bool> DeleteTask(int id);
        Task<IEnumerable<CreateTaskModel>> GetTasksByStoryId(int id);

        Task<IEnumerable<UserStoryWithTasksModel>> GetUserStoriesWithTasks();

        Task<bool> DoesStoryExist(int storyId);
    }
}
