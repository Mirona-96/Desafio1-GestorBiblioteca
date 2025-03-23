namespace GestaoBiblioteca.Model
{
    class Usuario
    {
        public Guid IdUsuario { get; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}