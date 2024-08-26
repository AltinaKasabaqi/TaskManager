using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data.Entities
{
    public class UserStory
    {
        [Key]
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set;}
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
