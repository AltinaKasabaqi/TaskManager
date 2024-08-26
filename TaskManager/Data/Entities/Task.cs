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
        public TaskStatus TaskStatus { get; set;}
        public string? AssignedTo { get; set; }
     
        [ForeignKey("StoryId")]
        public int StoryId { get; set; }
        public UserStory Story { get; set; }
      
    }
}
