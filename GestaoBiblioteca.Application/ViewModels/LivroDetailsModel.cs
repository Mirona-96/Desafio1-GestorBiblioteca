namespace GestaoBiblioteca.Application.ViewModels
{
    public class LivroDetailsModel
    {
        public int IdLivro { get; set; }  
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}