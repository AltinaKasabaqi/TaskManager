using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services
{
    public class UserStoryService : IUserStoryService
    {
        private readonly AppDbContext _context;

        public UserStoryService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<int> CreateUserStory(AddOrUpdateStory userStoryDto)
        {
            if (userStoryDto == null)
            {
                throw new ArgumentNullException(nameof(userStoryDto));
            }

            var userStory = new UserStory
            {
                StoryTitle = userStoryDto.StoryTitle,
                StoryDescription = userStoryDto.StoryDescription,
            };

            _context.Set<UserStory>().Add(userStory);
            await _context.SaveChangesAsync();

            return userStory.StoryId;
        }


        public async System.Threading.Tasks.Task DeleteUserStory(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id);
            if (userStory == null)
            {
                throw new ArgumentException("List not found", nameof(id));
            }

            _context.UserStories.Remove(userStory);
            await _context.SaveChangesAsync();
        }

        public async  Task<UserStory> GetUserStoryById(int id)
        {
            return await _context.UserStories.FindAsync(id);
        }

        public async Task<List<UserStory>> GetUserStories()
        {
            return await _context.UserStories.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateUserStory(int id, AddOrUpdateStory story)
        {
            var existingUserStory = await _context.UserStories.FirstOrDefaultAsync(x => x.StoryId == id);
            if (existingUserStory == null)
            {
                throw new ArgumentException("List not found", nameof(id));
            }

            existingUserStory.StoryTitle = story.StoryTitle;
            await _context.SaveChangesAsync();
        }
    }
}
