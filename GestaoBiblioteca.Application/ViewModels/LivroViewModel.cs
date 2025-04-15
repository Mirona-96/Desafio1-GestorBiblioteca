namespace GestaoBiblioteca.Application.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor)
        {
            id = id;
            Titulo = titulo;
            Autor = autor;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
    }
}