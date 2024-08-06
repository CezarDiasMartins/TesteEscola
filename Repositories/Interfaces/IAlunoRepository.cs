using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<AlunoModel>> GetAll();
        Task<AlunoModel> GetById(int id);
        Task<IEnumerable<NotaModel>> GetAllNotasPorAluno(int id);
        Task<int> Add(AlunoModel aluno);
    }
}