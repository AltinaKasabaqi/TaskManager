using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddTask(CreateTaskModel taskDto)
        {
            var task = _mapper.Map<Data.Entities.Task>(taskDto);

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var taskToDelete = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (taskToDelete != null)
            {
                _dbContext.Tasks.Remove(taskToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CreateTaskModel>> GetAllTasks()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return _mapper.Map<List<CreateTaskModel>>(tasks);
        }

        public async Task<CreateTaskModel> GetTaskById(int id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);
            return _mapper.Map<CreateTaskModel>(task);
        }

        public async Task<bool> UpdateTask(int id, CreateTaskModel taskDto)
        {
            var taskToUpdate = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);

            if (taskToUpdate != null)
            {
                _mapper.Map(taskDto, taskToUpdate);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<CreateTaskModel>> GetTasksByStoryId(int id)
        {
            var tasks = await _dbContext.Tasks
                .Where(x => x.StoryId == id)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CreateTaskModel>>(tasks);
        }


        public async Task<IEnumerable<UserStoryWithTasksModel>> GetUserStoriesWithTasks()
        {
            var userStories = await _dbContext.UserStories.ToListAsync();
            var userStoriesWithTasks = new List<UserStoryWithTasksModel>();

            foreach (var userStory in userStories)
            {
                var tasks = await GetTasksByStoryId(userStory.StoryId);
                var userStoryWithTasks = new UserStoryWithTasksModel
                {
                    Story = _mapper.Map<UserStory>(userStory),
                    Tasks = tasks
                };

                userStoriesWithTasks.Add(userStoryWithTasks);
            }

            return userStoriesWithTasks;
        }

        public async Task<bool> DoesStoryExist(int storyId)
        {
            return await _dbContext.UserStories.AnyAsync(us => us.StoryId == storyId);
        }


    }
}
