using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.DTOs
{
    public class TaskedDto
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo es maximo de 100 caracteres")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "El campo es maximo de 200 caracteres")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int TagId { get; set; }


    }
}
