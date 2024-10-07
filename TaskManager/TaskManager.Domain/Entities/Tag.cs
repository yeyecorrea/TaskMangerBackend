using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacion
        public List<TaskedTag> TaskedTags { get; set; } = new List<TaskedTag>();
    }
}
