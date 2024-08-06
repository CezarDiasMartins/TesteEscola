using Microsoft.AspNetCore.Mvc;
using TesteEscolaMVC.Services.Interfaces;
using TesteEscolaMVC.ViewModels;

namespace TesteEscolaMVC.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;
        private readonly INotaService _notaService;

        public RelatorioController(IAlunoService alunoService, ICursoService cursoService, INotaService notaService)
        {
            _alunoService = alunoService;
            _cursoService = cursoService;
            _notaService = notaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(new AlunosCursosViewModels
            (
                (await _alunoService.GetAll()).ToList(),
                (await _cursoService.GetAll()).ToList())
                {
                    Notas = (await _notaService.GetAll()).ToList()
                }
            );
        }
    }
}