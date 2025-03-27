
#region Metodos
using GestaoBiblioteca;
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

void ApresentarConsulta()
{
    Console.WriteLine("a. Editar        b.Eliminar");
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

#region programa
Gerenciador gerenciador = new Gerenciador();

while (true)
{
    ApresentarMenuInicial();
    Console.WriteLine("Escolha uma opção:");
    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            ApresentarMenuLivro();
            Console.WriteLine("Escolha uma opção:");
            string opcaoLivro = Console.ReadLine();
            switch (opcaoLivro)
            {
                case "1":
                    var livro = CadastrarLivro();
                    gerenciador.AdicionarLivros(livro);
                    LimparTela();
                    break;
                case "2":
                    gerenciador.ConsultarLivros();
                    ApresentarConsulta();
                    Console.WriteLine("Escolha uma opção:");
                    string opcaoConsulta = Console.ReadLine();
                    LimparTela();
                    switch (opcaoConsulta)
                    {
                        case "a":
                            Console.WriteLine("Escolha o livro a Editar");
                            int index = int.Parse(Console.ReadLine());
                            gerenciador.ActualizarLivro(index);
                            break;
                        case "b":
                            Console.WriteLine("Escolha o livro a eliminar:");
                            index = int.Parse(Console.ReadLine());
                            gerenciador.RemoverLivro(index);
                            Console.WriteLine("Eliminado");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("Insira o título ou autor do livro:");
                    string consulta = Console.ReadLine();
                    gerenciador.ConsultarUmLivro(consulta);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            break;
        case "2":
            break;
        case "3":
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
    LimparTela();
}
#endregion