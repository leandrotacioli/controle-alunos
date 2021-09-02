using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.Include("Curso").OrderBy(a => a.NomeAluno).ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include("Curso")
                .FirstOrDefaultAsync(m => m.CodAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            var alunoModel = new AlunoViewModel
            {
                ListaCursos = new SelectList(_context.Cursos.ToList(), "CodCurso", "NomeCurso", 0).ToList()
            };

            return View(alunoModel);
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAluno,NomeAluno,DataNascimento,Curso")] AlunoViewModel alunoViewModel)
        {
            alunoViewModel.Curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.CodCurso == alunoViewModel.Curso.CodCurso);

            ModelState.Clear();

            TryValidateModel(alunoViewModel);

            if (ModelState.IsValid)
            {
                Aluno aluno = new Aluno
                {
                    NomeAluno = alunoViewModel.NomeAluno,
                    DataNascimento = alunoViewModel.DataNascimento,
                    Curso = alunoViewModel.Curso
                };
            
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(alunoViewModel);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            var alunoModel = new AlunoViewModel
            {
                CodAluno = aluno.CodAluno,
                NomeAluno = aluno.NomeAluno,
                DataNascimento = aluno.DataNascimento,
                ListaCursos = new SelectList(_context.Cursos.ToList(), "CodCurso", "NomeCurso", aluno.Curso.CodCurso).ToList()
            };

            return View(alunoModel);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAluno,NomeAluno,DataNascimento,Curso")] AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.CodAluno)
            {
                return NotFound();
            }

            alunoViewModel.Curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.CodCurso == alunoViewModel.Curso.CodCurso);

            ModelState.Clear();

            TryValidateModel(alunoViewModel);

            if (ModelState.IsValid)
            {
                Aluno aluno = new Aluno
                {
                    CodAluno = alunoViewModel.CodAluno,
                    NomeAluno = alunoViewModel.NomeAluno,
                    DataNascimento = alunoViewModel.DataNascimento,
                    Curso = alunoViewModel.Curso
                };

                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.CodAluno))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(alunoViewModel);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include("Curso")
                .FirstOrDefaultAsync(m => m.CodAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.CodAluno == id);
        }
    }
}
