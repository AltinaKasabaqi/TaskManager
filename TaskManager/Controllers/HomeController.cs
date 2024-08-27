using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IUserStoryService _userStoryService;
    private readonly ITaskService _taskService;

    public HomeController(IUserStoryService userStoryService, ITaskService taskService)
    {
        _userStoryService = userStoryService;
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
                Tasks = tasks
            });
        }

        return View(userStoriesWithTasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskModel model)
    {
        if (ModelState.IsValid)
        {
            // Assuming you have a method in ITaskService to add a task
            await _taskService.AddTask(model);
            return RedirectToAction("Index");
        }

        // If the model is invalid, return to the Index view with the current data
        var userStories = await _userStoryService.GetUserStories();

        var userStoriesWithTasks = new List<UserStoryWithTasksModel>();

        foreach (var story in userStories)
        {
            var tasks = await _taskService.GetTasksByStoryId(story.StoryId);

            userStoriesWithTasks.Add(new UserStoryWithTasksModel
            {
                Story = story,
                Tasks = tasks
            });
        }

        return View("Index", userStoriesWithTasks);
    }
}
