using System.ComponentModel.DataAnnotations;
using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.ViewModels
{
    public class AlunoCursosViewModels
    {
        public AlunoCursosViewModels()
        {
            Aluno = new AlunoModel();
            CursosNotasDisponiveis = new CursosNotasDisponiveisViewModel();
            IdCursosSelecionadosIdNotasInseridas = new IdCursosSelecionadosIdNotasInseridasViewModel();
        }

        public AlunoModel Aluno { get; set; }
        public CursosNotasDisponiveisViewModel CursosNotasDisponiveis { get; set; }
        public IdCursosSelecionadosIdNotasInseridasViewModel IdCursosSelecionadosIdNotasInseridas { get; set; }
    }

    public class CursosNotasDisponiveisViewModel
    {
        public CursosNotasDisponiveisViewModel()
        {
            Cursos = new List<CursoModel>();
            Notas = new List<NotaModel>();
        }

        public List<CursoModel> Cursos { get; set; }
        public List<NotaModel> Notas { get; set; }
    }

    public class IdCursosSelecionadosIdNotasInseridasViewModel
    {
        public IdCursosSelecionadosIdNotasInseridasViewModel()
        {
            IdCurso = new List<int>();
            IdNota = new List<int>();
            ValorNota = new List<decimal>();
        }

        public List<int> IdCurso { get; set; }
        public List<int> IdNota { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10!")]
        [RegularExpression(@"^\d{1,2}(\.\d{1,2})?$", ErrorMessage = "A nota deve possuir até duas casas decimais!")]
        public List<decimal> ValorNota { get; set; }
    }
}