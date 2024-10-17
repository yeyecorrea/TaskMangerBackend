using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.DTOs
{
    public class TagDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
    }
}
