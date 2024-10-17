using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacion
        public List<Tasked> taskeds { get; set; } = new List<Tasked>();
    }
}
