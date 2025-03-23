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

        public void DevolverLivro(DateTime data)
        {
            if (data > DataDevolucao)
            {
                int diasAtraso = (data - DataDevolucao).Days;
                Console.WriteLine($"Devolução em atraso com {diasAtraso} dias.");
            }
            else
            {
                Console.WriteLine("Devolução dentro do prazo");
            }
        }
    }
}