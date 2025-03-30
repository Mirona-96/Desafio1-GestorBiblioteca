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

        public string ConsultarNomeLivro(List<Livro> livros)
        {
            //metodo que com base no id do livro, pega o nome do livro
            var livro = livros.FirstOrDefault(x => x.IdLivro == IdLivro);
            return livro!= null? livro.Titulo: "livro não encontrado.";
        }

        public string ConsultarNomeUsuario(List<Usuario> usuarios)
        {
            var usuario = usuarios.FirstOrDefault(x => x.IdUsuario == IdUsuario);
            return usuario != null ? usuario.Nome : "usuario não encontrado.";
        }

        public void ValidarDadosEmprestimo()
        {
            if (DataDevolucao < DataEmprestimo)
            {
                throw new Exception("Data invalida.");
            }
        }
    }
}