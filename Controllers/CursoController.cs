using Microsoft.AspNetCore.Mvc;
using TesteEscolaMVC.Models;
using TesteEscolaMVC.Services.Interfaces;

namespace TesteEscolaMVC.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService) => _cursoService = cursoService;

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CursoModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _cursoService.Add(curso);
                    TempData["MenssagemSucesso"] = "Curso cadastrado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                return View(curso);
            }
            catch (Exception)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos cadastrar o curso. Tente novamente!";
                return View(curso);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var curso = await _cursoService.GetById(id);

            if (curso == null) return NotFound();

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CursoModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _cursoService.Update(curso);
                    TempData["MenssagemSucesso"] = "Curso editado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                return View(curso);
            }
            catch (Exception)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos editar o curso. Tente novamente!";
                return View(curso);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cursoService.Delete(id);
                TempData["MenssagemSucesso"] = "Curso excluído com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos excluir o curso. Tente novamente!";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}