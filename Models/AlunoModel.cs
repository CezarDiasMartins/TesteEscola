using System.ComponentModel.DataAnnotations;

namespace TesteEscolaMVC.Models
{
    public class AlunoModel
    {
        public AlunoModel()
        {
            Cursos = new List<CursoModel>();
            Notas = new List<NotaModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A série é obrigatória!")]
        [Range(0, int.MaxValue, ErrorMessage = "Este campo aceita somente números positivos!")]
        public int Serie { get; set; }

        public List<CursoModel> Cursos { get; set; }
        public List<NotaModel> Notas { get; set; }
    }
}
