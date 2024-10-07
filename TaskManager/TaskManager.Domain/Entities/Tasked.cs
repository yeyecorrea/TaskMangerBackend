using Microsoft.AspNetCore.Identity;

namespace TaskManager.Domain.Entities
{
    public class Tasked
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Relacion
        public List<State> State { get; set; } = new List<State>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<TaskedTag> TaskedTags { get; set; } = new List<TaskedTag>();
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public DateTime CreationDate { get; set; }
        

    }
}
