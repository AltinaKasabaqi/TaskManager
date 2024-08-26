using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services
{
    public class ListService : IListService
    {
        private readonly AppDbContext _context;

        public ListService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       

        public async Task<int> CreateList(List list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            _context.Set<List>().Add(list);
            await _context.SaveChangesAsync();

            return list.ListId;
        }

        public async System.Threading.Tasks.Task DeleteList(int id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                throw new ArgumentException("List not found", nameof(id));
            }

            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async  Task<List> GetListById(int id)
        {
            return await _context.Lists.FindAsync(id);
        }

        public async Task<List<List>> GetLists()
        {
            return await _context.Lists.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateList(int id, List list)
        {
            var existingList = await _context.Lists.FirstOrDefaultAsync(x => x.ListId == id);
            if (existingList == null)
            {
                throw new ArgumentException("List not found", nameof(id));
            }

            existingList.ListName = list.ListName;
            await _context.SaveChangesAsync();
        }
    }
}
