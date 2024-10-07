using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskedTag
    {
        public int Id { get; set; }

        public int TaskedId { get; set; }
        public Tasked Tasked { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
