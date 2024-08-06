using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.ViewModels
{
    public class AlunosCursosViewModels
    {
        public AlunosCursosViewModels(List<AlunoModel> alunos, List<CursoModel> cursos)
        {
            Alunos = alunos;
            Cursos = cursos;
        }

        public List<AlunoModel> Alunos { get; set; }
        public List<CursoModel> Cursos { get; set; }
        public List<NotaModel> Notas { get; set; }
    }
}
