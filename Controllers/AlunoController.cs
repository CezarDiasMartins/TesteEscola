using Microsoft.AspNetCore.Mvc;
using TesteEscolaMVC.Models;
using TesteEscolaMVC.Services.Interfaces;
using TesteEscolaMVC.ViewModels;

namespace TesteEscolaMVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;

        public AlunoController(IAlunoService alunoService, ICursoService cursoService)
        {
            _alunoService = alunoService;
            _cursoService = cursoService;
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new AlunoCursosViewModels
            {
                CursosNotasDisponiveis = new CursosNotasDisponiveisViewModel
                {
                    Cursos = (await _cursoService.GetAll()).ToList()
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlunoCursosViewModels viewModel, IdCursosSelecionadosIdNotasInseridasViewModel idCursosSelecionadosIdNotasInseridas)
        {
            try
            {
                var aluno = new AlunoModel
                {
                    Nome = viewModel.Aluno.Nome,
                    Sobrenome = viewModel.Aluno.Sobrenome,
                    Serie = viewModel.Aluno.Serie
                };

                await _alunoService.Add(aluno, idCursosSelecionadosIdNotasInseridas);
                TempData["MenssagemSucesso"] = "Aluno cadastrado com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                viewModel = new AlunoCursosViewModels
                {
                    CursosNotasDisponiveis = new CursosNotasDisponiveisViewModel
                    {
                        Cursos = (await _cursoService.GetAll()).ToList()
                    }
                };

                TempData["MenssagemErro"] = $"Ops, não conseguimos cadastrar o aluno. Tente novamente!";
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _alunoService.GetById(id);
            if (aluno == null) return NotFound();

            var viewModel = new AlunoCursosViewModels
            {
                Aluno = aluno,
                CursosNotasDisponiveis = new CursosNotasDisponiveisViewModel
                {
                    Cursos = (await _cursoService.GetAll()).ToList(),
                    Notas = (await _alunoService.GetAllNotasPorAluno(id)).ToList()
                },
                IdCursosSelecionadosIdNotasInseridas = new IdCursosSelecionadosIdNotasInseridasViewModel
                {
                    IdCurso = aluno.Cursos.Select(c => c.Id).ToList(),
                    ValorNota = aluno.Notas.Select(n => n.Nota).ToList()
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AlunoCursosViewModels viewModel)
        {
            try
            {
                await _alunoService.Update(viewModel.Aluno, viewModel.IdCursosSelecionadosIdNotasInseridas);
                TempData["MenssagemSucesso"] = "Aluno editado com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                viewModel.CursosNotasDisponiveis.Cursos = (await _cursoService.GetAll()).ToList();
                viewModel.CursosNotasDisponiveis.Notas = (await _alunoService.GetAllNotasPorAluno(viewModel.Aluno.Id)).ToList();
                TempData["MenssagemErro"] = $"Ops, não conseguimos editar o aluno. Tente novamente!";
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alunoService.Delete(id);
                TempData["MenssagemSucesso"] = "Aluno excluído com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos excluir o aluno. Tente novamente!";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}