
#region Metodos
using GestaoBiblioteca;
using GestaoBiblioteca.Model;

class Program
{
    static void Main()
    {
        void ApresentarMenuInicial()
        {
            Console.Clear();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine("GESTOR DE BIBLIOTECA");
            Console.WriteLine(new string('*', 50));

            Console.WriteLine(
                "1. Livros\n" +
                "2. Usuários\n" +
                "3. Empréstimos\n" +
                "0. Sair");
        }
        #region Livros
        void ApresentarMenuLivro()
        {
            Console.Clear();
            Console.WriteLine(
                "1. Cadastrar Livro\n" +
                "2. Consultar Livros\n" +
                "3. Consultar um Livro.");
        }

        void ApresentarConsulta()
        {
            Console.WriteLine("a. Editar        b.Eliminar          c.Retornar");
        }

        Livro CadastrarLivro()
        {
            Console.Clear();
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
        #endregion

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
                            Console.Clear();
                            switch (opcaoConsulta)
                            {
                                case "a":
                                    Console.WriteLine("Escolha o livro a Editar");
                                    int index = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    gerenciador.ActualizarLivro(index - 1);
                                    break;
                                case "b":
                                    Console.WriteLine("Escolha o livro a eliminar:");
                                    index = int.Parse(Console.ReadLine());

                                    gerenciador.RemoverLivro(index - 1);
                                    Console.WriteLine("Livro eliminado");
                                    LimparTela();
                                    break;
                                case "c":
                                    return;

                                default:
                                    Console.WriteLine("Opção inválida.");
                                    break;
                            }
                            break;
                        case "3":
                            gerenciador.ConsultarUmLivro();
                            LimparTela();
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
                case "0":
                    Console.WriteLine("Fim de Execução.");
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        #endregion

    }
}
