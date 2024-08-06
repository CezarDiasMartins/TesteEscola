using TesteEscolaMVC.Models;
using TesteEscolaMVC.Repositories.Interfaces;
using TesteEscolaMVC.Services.Interfaces;
using TesteEscolaMVC.ViewModels;

namespace TesteEscolaMVC.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IRepository<AlunoModel> _alunoRepository;
        private readonly IRepository<CursoModel> _cursoRepository;
        private readonly IRepository<NotaModel> _notaRepository;
        private readonly IAlunoRepository _iAlunoRepository;

        public AlunoService(IRepository<AlunoModel> alunoRepository, IRepository<CursoModel> cursoRepository, IAlunoRepository iAlunoRepository, IRepository<NotaModel> notaRepository)
        {
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;
            _iAlunoRepository = iAlunoRepository;
            _notaRepository = notaRepository;
        }

        public async Task<IEnumerable<AlunoModel>> GetAll()
        {
            return await _iAlunoRepository.GetAll();
        }

        public async Task<AlunoModel> GetById(int id)
        {
            return await _iAlunoRepository.GetById(id);
        }

        public async Task Add(AlunoModel aluno, IdCursosSelecionadosIdNotasInseridasViewModel idCursosSelecionadosIdNotasInseridas)
        {
            aluno.Cursos = new List<CursoModel>();
            var idCursos = new List<int>();

            for (int i = 0; i < idCursosSelecionadosIdNotasInseridas.IdCurso.Count(); i++)
            {
                var curso = await _cursoRepository.GetById(idCursosSelecionadosIdNotasInseridas.IdCurso[i]);
                if (curso != null) 
                {
                    idCursos.Add(curso.Id); 
                    aluno.Cursos.Add(curso); 
                }
            }

            int idAluno = await _iAlunoRepository.Add(aluno);

            for (int i = 0; i < idCursosSelecionadosIdNotasInseridas.IdCurso.Count(); i++)
            {
                var nota = new NotaModel
                {
                    AlunoId = idAluno,
                    CursoId = idCursos[i],
                    Nota = idCursosSelecionadosIdNotasInseridas.ValorNota[i]
                };
                await _notaRepository.Add(nota);
            }
        }

        public async Task Update(AlunoModel aluno, IdCursosSelecionadosIdNotasInseridasViewModel idCursosSelecionadosIdNotasInseridas)
        {
            var alunoModel = await _iAlunoRepository.GetById(aluno.Id);
            if (alunoModel == null) return;

            alunoModel.Nome = aluno.Nome;
            alunoModel.Sobrenome = aluno.Sobrenome;
            alunoModel.Serie = aluno.Serie;
            alunoModel.Cursos.Clear();
            alunoModel.Notas.Clear();

            for (int i = 0; i < idCursosSelecionadosIdNotasInseridas.IdCurso.Count; i++)
            {
                var cursoId = idCursosSelecionadosIdNotasInseridas.IdCurso[i];
                var notaValor = idCursosSelecionadosIdNotasInseridas.ValorNota[i];

                var curso = await _cursoRepository.GetById(cursoId);
                if (curso != null)
                {
                    alunoModel.Cursos.Add(curso);
                    alunoModel.Notas.Add(new NotaModel
                    {
                        AlunoId = aluno.Id,
                        CursoId = cursoId,
                        Nota = notaValor
                    });
                }
            }

            await _alunoRepository.Update(alunoModel);
        }

        public async Task Delete(int id)
        {
            await _alunoRepository.Delete(id);
        }

        public async Task<IEnumerable<NotaModel>> GetAllNotasPorAluno(int id)
        {
            return await _iAlunoRepository.GetAllNotasPorAluno(id);
        }
    }
}