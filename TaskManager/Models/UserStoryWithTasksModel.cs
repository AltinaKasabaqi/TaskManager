using TaskManager.Data.Entities;

namespace TaskManager.Models
{
    public class UserStoryWithTasksModel
    {
        public UserStory Story { get; set; }
        public IEnumerable<CreateTaskModel> Tasks { get; set; }
    }
}
