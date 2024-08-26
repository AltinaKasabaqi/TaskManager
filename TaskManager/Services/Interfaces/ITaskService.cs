namespace TaskManager.Services.Interfaces
{
    public interface ITaskService
    {
        Task <List<Data.Entities.Task>> GetAllTasks();
        Task <Data.Entities.Task> GetTaskById(int id);
        Task <bool> AddTask(Data.Entities.Task task);
        Task <bool> UpdateTask(int id, Data.Entities.Task task);
        Task <bool> DeleteTask(int id);
    }
}
