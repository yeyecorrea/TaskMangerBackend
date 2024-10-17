using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public class Tasked
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Relacion
        public int StateId { get; set; }
        public State State { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<TaskedTag> TaskedTags { get; set; } = new List<TaskedTag>();
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

        public DateTime CreationDate { get; set; }
        

    }
}
