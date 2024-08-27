using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Data.Entities;
using TaskManager.Models;

namespace TaskManager.Services.Interfaces
{
    public interface IUserStoryService
    {

        Task<int> CreateUserStory(AddOrUpdateStory userStoryDto);
        Task<UserStory> GetUserStoryById(int id);
        Task<List<UserStory>> GetUserStories();
        System.Threading.Tasks.Task UpdateUserStoryStatus(int id, AddOrUpdateStory list);
        System.Threading.Tasks.Task DeleteUserStory(int id);
    }
}
