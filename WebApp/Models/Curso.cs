using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Curso
    {
        [Key]
        public int CodCurso { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomeCurso { get; set; }
    }
}