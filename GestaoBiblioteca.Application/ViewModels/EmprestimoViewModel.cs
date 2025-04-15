namespace GestaoBiblioteca.Application.ViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int idEmprestimo, string tituloLivro, string nomeUsuario, DateTime dataEmprestimo)
        {
            IdEmprestimo = idEmprestimo;
            TituloLivro = tituloLivro;
            NomeUsuario = nomeUsuario;
            DataEmprestimo = dataEmprestimo;
        }

        public EmprestimoViewModel() { }
        public int IdEmprestimo { get; set; }
        //public int IdLivro { get; set; }
        public string TituloLivro { get; set; }
        //public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
    }
}