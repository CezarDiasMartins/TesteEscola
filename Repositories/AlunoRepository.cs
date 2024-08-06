using Microsoft.EntityFrameworkCore;
using TesteEscolaMVC.Data;
using TesteEscolaMVC.Models;
using TesteEscolaMVC.Repositories.Interfaces;

namespace TesteEscolaMVC.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Context _context;
        public AlunoRepository(Context context) => _context = context;

        public async Task<IEnumerable<AlunoModel>> GetAll()
        {
            return await _context.Alunos.Include(a => a.Cursos).Include(a => a.Notas).ToListAsync();
        }

        public async Task<AlunoModel> GetById(int id)
        {
            return await _context.Alunos.Include(a => a.Cursos).Include(a => a.Notas).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<NotaModel>> GetAllNotasPorAluno(int id)
        {
            return await _context.Notas.Where(n => n.AlunoId == id).ToListAsync();
        }

        public async Task<int> Add(AlunoModel aluno)
        {
            await _context.AddAsync(aluno);
            await _context.SaveChangesAsync();

            var id = aluno.Id;

            return id;
        }
    }
}