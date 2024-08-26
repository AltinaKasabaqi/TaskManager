using System.ComponentModel.DataAnnotations;
using TaskManager.Helpers.Enums;

namespace TaskManager.Data.Entities
{
    public class UserStory
    {
        [Key]
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set;}
        public StoryStatus Status { get; set; } = StoryStatus.New;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
