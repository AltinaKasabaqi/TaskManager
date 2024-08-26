

namespace TaskManager.Models
{
    public class CreateTaskModel
    {
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TaskStatus { get; set; }
        public string? AssignedTo { get; set; }
        public int StoryId { get; set; }
    }
}
