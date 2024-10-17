using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacion
        public List<Tasked> Taskeds { get; set;} = new List<Tasked>();
    }
}
