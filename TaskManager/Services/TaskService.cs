using Microsoft.Win32;
using TaskManager.Data;
using TaskManager.Services.Interfaces;
using TaskManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    { 

        private readonly AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


       
        public async Task<bool> AddTask(Data.Entities.Task task)
        {
             _dbContext.Add(new Data.Entities.Task
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                EndDate = task.EndDate,
                TaskStatus = task.TaskStatus,
                AssignedTo = task.AssignedTo,
                ListID = task.ListID,

            });

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var taskToDelete = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (taskToDelete != null)
            {
                _dbContext.Remove(taskToDelete);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<Data.Entities.Task>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Data.Entities.Task> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);
        }

        public async Task<bool> UpdateTask(int id, Data.Entities.Task task)
        {
            var taskToUpdate = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (taskToUpdate != null)
            {
                taskToUpdate.TaskName = task.TaskName;
                taskToUpdate.TaskDescription = task.TaskDescription;
                taskToUpdate.EndDate = task.EndDate;
                taskToUpdate.TaskStatus = task.TaskStatus;
                taskToUpdate.AssignedTo = task.AssignedTo;
                taskToUpdate.ListID = task.ListID;

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
