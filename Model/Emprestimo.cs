namespace GestaoBiblioteca.Model
{
    class Emprestimo
    {
        public Guid IdEmprestimo { get; } = Guid.NewGuid();
        public Guid IdUsuario { get; private set; }
        public Guid IdLivro { get; private set; }
        public DateTime DataEmprestimo { get; } = DateTime.Now;
        public DateTime DataDevolucao { get; set; }

        public void AtribuirUsuario(Usuario usuario)
        {
            IdUsuario = usuario.IdUsuario;
        }

        public void AtribuirLivro(Livro livro)
        {
            IdLivro = livro.IdLivro; 
        }

        public string ConsultarNomeLivro(Livro livro)
        {
            //metodo que com base no id do livro, pega o nome do livro
            return livro.Titulo;
        }

        public string ConsultarNomeUsuario(Usuario usuario)
        {
            return usuario.Nome;
        }


    }
}