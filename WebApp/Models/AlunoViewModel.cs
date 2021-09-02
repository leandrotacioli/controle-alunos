using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class AlunoViewModel : Aluno
    {
        public List<SelectListItem> ListaCursos { get; set; }
    }
}
