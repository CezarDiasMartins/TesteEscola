using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoModel>> GetAll();
        Task<CursoModel> GetById(int id);
        Task Add(CursoModel curso);
        Task Update(CursoModel curso);
        Task Delete(int id);
    }
}