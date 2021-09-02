using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Aluno
    {
        [Key]
        public int CodAluno { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomeAluno { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [ForeignKey("CodCurso")]
        public virtual Curso Curso { get; set; }
    }
}