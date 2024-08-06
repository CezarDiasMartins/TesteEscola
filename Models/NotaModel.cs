namespace TesteEscolaMVC.Models
{
    public class NotaModel
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public decimal Nota { get; set; }

        public AlunoModel Aluno { get; set; }
        public CursoModel Curso { get; set; }
    }
}