using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Entities;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
   
    public class UserStoryController : Controller
    {
        private readonly IUserStoryService _listService;

        public UserStoryController(IUserStoryService listService)
        {
            _listService = listService;
        }

        // GET: /List
        public async Task<IActionResult> Index()
        {
            var lists = await _listService.GetUserStories();
            return View(lists); 
        }

        // GET: /List/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var list = await _listService.GetUserStoryById(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list); 
        }

        // GET: /List/Create
        public IActionResult Create()
        {
            return View(); 
        }

        // POST: /List/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoryTitle", "StoryDescription", "Status")] AddOrUpdateStory storyDto)
        {
            if (ModelState.IsValid)
            {
                var newStoryId = await _listService.CreateUserStory(storyDto);
                return RedirectToAction("Index", "Home");
            }
            return View(storyDto);
        }

        // GET: /List/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var list = await _listService.GetUserStoryById(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list); 
        }

        // POST: /List/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListName")] AddOrUpdateStory listDto)
        {
            if (!ModelState.IsValid)
            {
                return View(listDto); 
            }

            try
            {
                await _listService.UpdateUserStoryStatus(id, listDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Details), new { id = id });
        }


        // GET: /List/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var list = await _listService.GetUserStoryById(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list); 
        }

        // POST: /List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _listService.DeleteUserStory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
