using TesteEscolaMVC.Models;
using TesteEscolaMVC.ViewModels;

namespace TesteEscolaMVC.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoModel>> GetAll();
        Task<AlunoModel> GetById(int id);
        Task Add(AlunoModel aluno, IdCursosSelecionadosIdNotasInseridasViewModel idCursosSelecionadosIdNotasInseridas);
        Task Update(AlunoModel aluno, IdCursosSelecionadosIdNotasInseridasViewModel idCursosSelecionadosIdNotasInseridas);
        Task Delete(int id);
        Task<IEnumerable<NotaModel>> GetAllNotasPorAluno(int id);
    }
}