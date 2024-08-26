using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Data.Entities;
using TaskManager.Models;

namespace TaskManager.Services.Interfaces
{
    public interface IListService
    {

        Task<int> CreateList(AddOrUpdateList list);
        Task<List> GetListById(int id);
        Task<List<List>> GetLists();
        System.Threading.Tasks.Task UpdateList(int id, AddOrUpdateList list);
        System.Threading.Tasks.Task DeleteList(int id);
    }
}
