
#region Metodos
using GestaoBiblioteca.Controller;
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

        void ApresentarMenuConsulta()
        {
            Console.WriteLine("a. Editar        b.Eliminar          c.Retornar");
        }

        Livro CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRAR NOVO LIVRO ===");
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


        #region Usuarios

        void ApresentarMenuUsuario()
        {
            Console.Clear();
            Console.WriteLine(
                "1. Cadastrar Usuario\n" +
                "2. Consultar Usuarios\n");
        }

        Usuario CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRAR NOVO USUÁRIO ===");
            Console.WriteLine("Insira o Nome do Usuário");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o Email do Usuário");
            string email = Console.ReadLine();
            return new Usuario
            {
                Nome = nome,
                Email = email
            };
        }

        #endregion


        #region Emprestimos
        void ApresentarMenuEmprestimo()
        {
            Console.Clear();
            Console.WriteLine(
                "1. Cadastrar Emprestimo\n" +
                "2. Registar Devolução\n" +
                "3. Consultar Empréstimos\n");
        }

        Emprestimo CadastrarEmprestimo(LivroController lc, UsuarioController uc)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRAR NOVO EMPRÉSTIMO ===");
            Console.WriteLine("Usuários cadastrados:");
            uc.ConsultarUsuarios();
            Console.WriteLine("Selecciona o usuario:");
            int indexUsuario = int.Parse(Console.ReadLine()) - 1;

            if(indexUsuario < 0 || indexUsuario >= uc.usuarios.Count)
            {
                Console.WriteLine("Usuário inválido.");
                return null;
            }

            Console.WriteLine("\nLivros cadastrados:");
            lc.ConsultarLivros();
            Console.WriteLine("Selecciona o livro:");
            int indexLivro = int.Parse(Console.ReadLine()) - 1;

            if (indexLivro < 0 || indexLivro >= lc.livros.Count)
            {
                Console.WriteLine("Livro inválido.");
                return null;
            }


            Console.WriteLine("Insira a Data de Devolução");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

            var emprestimo = new Emprestimo();
            emprestimo.AtribuirUsuario(uc.usuarios[indexUsuario]);
            emprestimo.AtribuirLivro(lc.livros[indexLivro]);
            emprestimo.DataDevolucao = dataDevolucao;

            return  emprestimo;
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
        LivroController livroController = new LivroController();
        UsuarioController usuarioController = new UsuarioController();
        EmprestimoController emprestimoController = new EmprestimoController();

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
                            livroController.AdicionarLivros(livro);
                            LimparTela();
                            break;
                        case "2":
                            livroController.ConsultarLivros();
                            ApresentarMenuConsulta();
                            Console.WriteLine("Escolha uma opção:");
                            string opcaoConsulta = Console.ReadLine();
                            Console.Clear();
                            switch (opcaoConsulta)
                            {
                                case "a":
                                    Console.WriteLine("Escolha o livro a Editar");
                                    int index = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    livroController.ActualizarLivro(index - 1);
                                    break;
                                case "b":
                                    Console.WriteLine("Escolha o livro a eliminar:");
                                    index = int.Parse(Console.ReadLine());

                                    livroController.RemoverLivro(index - 1);
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
                            livroController.ConsultarUmLivro();
                            LimparTela();
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                    break;
                case "2":
                    ApresentarMenuUsuario();
                    Console.WriteLine("Escolha uma opção:");
                    string opcaoUsuario = Console.ReadLine();
                    switch (opcaoUsuario)
                    {
                        case "1":
                            var Usuario = CadastrarUsuario();
                            usuarioController.CadastrarUsuario(Usuario);
                            LimparTela();
                            break;

                        case "2":
                            usuarioController.ConsultarUsuarios();
                            ApresentarMenuConsulta();
                            Console.WriteLine("Escolha uma opção:");
                            string opcaoConsulta = Console.ReadLine();
                            Console.Clear();
                            switch (opcaoConsulta)
                            {
                                case "a":
                                    Console.WriteLine("Escolha o Usuário a Editar");
                                    int index = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    usuarioController.ActualizarUsuario(index - 1);
                                    break;
                                case "b":
                                    Console.WriteLine("Escolha o Usuário a eliminar:");
                                    index = int.Parse(Console.ReadLine());
                                    usuarioController.RemoverUsuario(index - 1);
                                    LimparTela();
                                    break;
                                case "c":
                                    return;
                                default:
                                    Console.WriteLine("Opção inválida.");
                                    break;
                            }
                            break;
                    } break;
                case "3":
                    ApresentarMenuEmprestimo();
                    Console.WriteLine("Escolha uma opção:");
                    string opcaoEmprestimo = Console.ReadLine();
                    switch (opcaoEmprestimo)
                    {
                        case "1":
                            Emprestimo emprestimo = CadastrarEmprestimo(livroController,usuarioController);
                            if (emprestimo != null)
                            {
                                emprestimoController.CadastrarEmprestimo(emprestimo);
                            }
                            LimparTela();
                            break;
                        case "2":
                            emprestimoController.DevolverLivro(livroController.livros, usuarioController.usuarios);
                            LimparTela();
                            break;
                        case "3":
                            emprestimoController.ConsultarEmprestimos(livroController.livros, usuarioController.usuarios); //chama a lista dos livros e dos usuarios
                            ApresentarMenuConsulta();
                            Console.WriteLine("Escolha uma opção:");
                            string opcaoConsulta = Console.ReadLine();
                            Console.Clear();
                            switch (opcaoConsulta)
                            {
                                case "a":
                                    Console.WriteLine("Escolha o empréstimo a Editar");
                                    int index = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    emprestimoController.ActualizarEmprestimo(index - 1);
                                    break;
                                case "b":
                                    Console.WriteLine("Escolha o empréstimo a eliminar:");
                                    index = int.Parse(Console.ReadLine());
                                    emprestimoController.RemoverEmprestimo(index - 1);
                                    LimparTela();
                                    break;
                                case "c":
                                    return;
                                default:
                                    Console.WriteLine("Opção inválida.");
                                    break;
                            }
                            LimparTela();
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
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
