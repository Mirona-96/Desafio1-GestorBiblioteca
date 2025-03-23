namespace GestaoBiblioteca.Model
{
    public class Livro
    {
        public Guid IdLivro { get; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }

        public void ValidarDados()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("introduza o título do livro válido.");
            }

            if (string.IsNullOrEmpty(Autor))
            {
                throw new Exception("introduza o autor do livro");
            }

            if (AnoPublicacao > DateTime.Now.Year)
            {
                throw new Exception("Ano de Publicação inválido.");
            }
        }

    }
}