using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data.Entities
{
    public class List
    {
        [Key]
        public int ListId { get; set; }
        public string ListName { get; set; }
    }
}
