using TaskManager.Helpers.Enums;

namespace TaskManager.Models
{
    public class AddOrUpdateStory
    {
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set; }
        public StoryStatus Status { get; set; }
    }
}
