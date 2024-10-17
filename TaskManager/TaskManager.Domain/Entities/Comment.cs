using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        // Realciones
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
        public int TaskedId { get; set; }
        public Tasked Tasked { get; set; }

    }
}
