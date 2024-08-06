using TesteEscolaMVC.Models;
using TesteEscolaMVC.Repositories.Interfaces;
using TesteEscolaMVC.Services.Interfaces;

namespace TesteEscolaMVC.Services
{
    public class CursoService : ICursoService
    {
        private readonly IRepository<CursoModel> _cursoRepository;
        public CursoService(IRepository<CursoModel> cursoRepository) => _cursoRepository = cursoRepository;

        public async Task<IEnumerable<CursoModel>> GetAll()
        {
            return await _cursoRepository.GetAll();
        }

        public async Task<CursoModel> GetById(int id)
        {
            return await _cursoRepository.GetById(id);
        }

        public async Task Add(CursoModel curso)
        {
            await _cursoRepository.Add(curso);
        }

        public async Task Update(CursoModel curso)
        {
            await _cursoRepository.Update(curso);
        }

        public async Task Delete(int id)
        {
            await _cursoRepository.Delete(id);
        }
    }
}