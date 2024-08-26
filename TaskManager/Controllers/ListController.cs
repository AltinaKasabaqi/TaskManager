using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Entities;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
   
    public class ListController : Controller
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        // GET: /List
        public async Task<IActionResult> Index()
        {
            var lists = await _listService.GetLists();
            return View(lists); 
        }

        // GET: /List/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var list = await _listService.GetListById(id);
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
        public async Task<IActionResult> Create([Bind("ListName")] AddOrUpdateList listDto)
        {
            if (ModelState.IsValid)
            {
                var newListId = await _listService.CreateList(listDto);
                return RedirectToAction(nameof(Details), new { id = newListId });
            }
            return View(listDto); 
        }

        // GET: /List/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var list = await _listService.GetListById(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list); 
        }

        // POST: /List/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListName")] AddOrUpdateList listDto)
        {
            if (!ModelState.IsValid)
            {
                return View(listDto); 
            }

            try
            {
                await _listService.UpdateList(id, listDto);
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
            var list = await _listService.GetListById(id);
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
            await _listService.DeleteList(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
