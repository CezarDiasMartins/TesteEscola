using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.Services.Interfaces
{
    public interface INotaService
    {
        Task<IEnumerable<NotaModel>> GetAll();
    }
}
