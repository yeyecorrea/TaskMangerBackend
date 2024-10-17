using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class HistoryChange
    {
        public int Id { get; set; }
        public string PreviousDescription { get; set; }
        public string DescriptionNew { get; set;}
        public DateTime DateChange { get; set; }

        // Realciones
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int TaskedId { get; set; }
        public Tasked Tasked { get; set; }
    }
}
