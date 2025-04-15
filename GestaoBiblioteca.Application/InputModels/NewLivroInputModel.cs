namespace GestaoBiblioteca.Application.InputModels
{
    public class NewLivroInputModel
    {
        private string titulo1;
        private string titulo2;

        public NewLivroInputModel(int id, string titulo1, string titulo2, string iSBN, int anoPublicacao)
        {
            Id = id;
            this.titulo1 = titulo1;
            this.titulo2 = titulo2;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}