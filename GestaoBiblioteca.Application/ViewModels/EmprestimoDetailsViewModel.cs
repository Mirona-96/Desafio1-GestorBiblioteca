using GestaoBiblioteca.Core.Enums;

namespace GestaoBiblioteca.Application.ViewModels
{
    public class EmprestimoDetailsViewModel
    {
       /* public EmprestimoViewModel(int idEmprestimo, int idLivro, string tituloLivro, int idUsuario, string nomeUsuario, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            IdEmprestimo = idEmprestimo;
            IdLivro = idLivro;
            TituloLivro = tituloLivro;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }*/
        public int IdEmprestimo { get; set; }
        public int IdLivro { get; set; }
        public string TituloLivro { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public EmprestimoStatusEnum Status { get; set; }

    }
}