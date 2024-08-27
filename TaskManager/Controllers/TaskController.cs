using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: /Task/
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasks();
            return View(tasks);
        }

        // GET: /Task/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // GET: /Task/Detailss/5
        public async Task<IActionResult> Detailss(int id)
        {
            var tasks = await _taskService.GetTasksByStoryId(id);
            if (tasks == null || !tasks.Any())
            {
                return NotFound();
            }
            return View(tasks);
        }

        // GET: /Task/Create/5
        public async Task<IActionResult> Create(int storyId)
        {
            var storyExists = await _taskService.DoesStoryExist(storyId);
            if (!storyExists)
            {
                return NotFound(); // Or handle as needed
            }

            var model = new CreateTaskModel { StoryId = storyId };
            return View("TaskForm", model);
        }

        // POST: /Task/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TaskName,TaskDescription,StartDate,EndDate,TaskStatus,AssignedTo,StoryId")] CreateTaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View("TaskForm", task);
            }

            var storyExists = await _taskService.DoesStoryExist(task.StoryId);
            if (!storyExists)
            {
                ModelState.AddModelError("", "The specified story does not exist.");
                return View("TaskForm", task);
            }

            await _taskService.AddTask(task);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Task/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Task/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,TaskDescription,StartDate,EndDate,TaskStatus,AssignedTo,StoryId")] CreateTaskModel task)
        {
            

            if (!ModelState.IsValid)
            {
                return View(task);
            }

            var storyExists = await _taskService.DoesStoryExist(task.StoryId);
            if (!storyExists)
            {
                ModelState.AddModelError("", "The specified story does not exist.");
                return View(task);
            }

            var result = await _taskService.UpdateTask(id, task);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        // GET: /Task/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _taskService.DeleteTask(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
