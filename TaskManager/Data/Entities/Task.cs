using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }    
        public string? TaskStatus { get; set;}
        public string? AssignedTo { get; set; }
     
        [ForeignKey("ListID")]
        public int ListID { get; set; }
        public List list { get; set; }
      
    }
}
