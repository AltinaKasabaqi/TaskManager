using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

public class HomeController : Controller
{
    private readonly IUserStoryService _userStoryService;
    private readonly ITaskService _taskService;

    public HomeController(IUserStoryService listService, ITaskService taskService)
    {
        _userStoryService = listService;
        _taskService = taskService;
    }

    public async Task<IActionResult> Index()
    {
        var userStories = await _userStoryService.GetUserStories();

        var userStoriesWithTasks = new List<UserStoryWithTasksModel>();

        foreach (var story in userStories)
        {
            var tasks = await _taskService.GetTasksByStoryId(story.StoryId);
            userStoriesWithTasks.Add(new UserStoryWithTasksModel
            {
                Story = story,
                Tasks = (IEnumerable<CreateTaskModel>)tasks
            });
        }

        return View(userStoriesWithTasks);
    }
}
