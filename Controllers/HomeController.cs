using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteEscolaMVC.Services.Interfaces;
using TesteEscolaMVC.ViewModels;

namespace TesteEscolaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;

        public HomeController(ILogger<HomeController> logger, IAlunoService alunoService, ICursoService cursoService)
        {
            _logger = logger;
            _alunoService = alunoService;
            _cursoService = cursoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(new AlunosCursosViewModels
            (
                (await _alunoService.GetAll()).ToList(), 
                (await _cursoService.GetAll()).ToList()
            ));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}