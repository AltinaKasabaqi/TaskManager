using Microsoft.AspNetCore.Mvc;
using TaskManager.Services.Interfaces;
using TaskManager.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasks();
            return View(tasks);
        }

      
        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        
        public async Task<IActionResult> Create(Data.Entities.Task task)
        {
            if (ModelState.IsValid)
            {
                await _taskService.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

      
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        
        [HttpPost]
       
        public async Task<IActionResult> Edit(int id, Data.Entities.Task task)
        {
            if (ModelState.IsValid)
            {
                var result = await _taskService.UpdateTask(id, task);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(task);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        
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
