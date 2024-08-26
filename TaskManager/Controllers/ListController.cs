using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Entities;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ListController : Controller
    {
        private readonly IListService _listService;

        public ListController(IListService listservice)
        {
            _listService = listservice;
        }



        [HttpPost(Name = "CreateList")]
        public async Task<IActionResult> CreateList([FromBody] List list)
        {
            if (list == null)
            {
                return BadRequest("List object is null");
            }
            var newListId = await _listService.CreateList(list);
            return CreatedAtAction(nameof(_listService.GetListById), new { id = newListId }, list);
        }


        [HttpGet("{id}", Name = "GetListById")]
        public async Task<IActionResult> GetListById(int id)
        {
            var list = await _listService.GetListById(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet(Name = "GetLists")]
        public async Task<IActionResult> GetLists()
        {
            var lists = await _listService.GetLists();
            return Ok(lists);
        }

        [HttpPut("{id}", Name = "UpdateList")]
        public async Task<IActionResult> UpdateList(int id, [FromBody] List list)
        {
            if (list == null || list.ListId != id)
            {
                return BadRequest("Invalid list object");
            }
            await _listService.UpdateList(id, list);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteList")]
        public async Task<IActionResult> DeleteList(int id)
        {
            await _listService.DeleteList(id);
            return NoContent();
        }
    }
}
