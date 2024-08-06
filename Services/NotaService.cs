using TesteEscolaMVC.Models;
using TesteEscolaMVC.Repositories.Interfaces;
using TesteEscolaMVC.Services.Interfaces;

namespace TesteEscolaMVC.Services
{
    public class NotaService : INotaService
    {
        private readonly IRepository<NotaModel> _notaRepository;
        public NotaService(IRepository<NotaModel> notaRepository) => _notaRepository = notaRepository;

        public async Task<IEnumerable<NotaModel>> GetAll()
        {
            return await _notaRepository.GetAll();
        }
    }
}
