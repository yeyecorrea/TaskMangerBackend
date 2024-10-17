using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.DTOs
{
    public class CommentDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Contenido")]
        [StringLength(100)]
        public string? Content { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Tarea")]
        public int TaskedId { get; set; }
    }
}
