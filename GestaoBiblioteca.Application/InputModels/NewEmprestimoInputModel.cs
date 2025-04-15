namespace GestaoBiblioteca.Application.InputModels
{
    public class NewEmprestimoInputModel
    {
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataEmprestimo { get; } = DateTime.Now;
        public DateTime DataDevolucao { get; set; }
    }
}