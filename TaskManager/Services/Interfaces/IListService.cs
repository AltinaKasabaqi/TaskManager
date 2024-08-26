using System.Collections.Generic;
using TaskManager.Data.Entities;

namespace TaskManager.Services.Interfaces
{
    public interface IListService
    {

        Task<int> CreateList(List list);
        Task<List> GetListById(int id);
        Task<List<List>> GetLists();
        System.Threading.Tasks.Task UpdateList(int id, List list);
        System.Threading.Tasks.Task DeleteList(int id);
    }
}
