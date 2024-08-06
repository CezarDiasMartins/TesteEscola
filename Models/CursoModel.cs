using System.ComponentModel.DataAnnotations;

namespace TesteEscolaMVC.Models
{
    public class CursoModel
    {
        public CursoModel()
        {
            Alunos = new List<AlunoModel>();
            Notas = new List<NotaModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        public List<AlunoModel> Alunos { get; set; }
        public List<NotaModel> Notas { get; set; }
    }
}
