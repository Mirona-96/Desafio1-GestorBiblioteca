
#region Metodos
using GestaoBiblioteca.Model;

void ApresentarMenuInicial()
{
    Console.WriteLine("*", 50);
    Console.WriteLine("GESTOR DE BIBLIOTECA");
    Console.WriteLine("*", 50);

    Console.WriteLine("1. Livros\n" +
        "2. Usuários\n" +
        "3. Empréstimos");
}

void ApresentarMenuLivro()
{
    Console.WriteLine("1 - Cadastrar Livro\n" +
        "2. Consultar Livros\n" +
        "3. Consultar um Livro.");
}

Livro CadastrarLivro()
{
    Console.WriteLine("Insira o Título do livro");
    string titulo = Console.ReadLine();
    Console.WriteLine("Insira o Autor do livro");
    string autor = Console.ReadLine();
    Console.WriteLine("Insira o ISBN do livro");
    string isbn = Console.ReadLine();
    Console.WriteLine("Insira o ano de publicação do livro");
    int anoPublicacao = int.Parse(Console.ReadLine());

    return new Livro
    {
        Titulo = titulo,
        Autor = autor,
        ISBN = isbn,
        AnoPublicacao = anoPublicacao
    };
}

void LimparTela()
{
    Console.WriteLine("Pressiona qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}
#endregion