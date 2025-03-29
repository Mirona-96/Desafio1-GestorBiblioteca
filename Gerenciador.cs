using GestaoBiblioteca.Controller;
using GestaoBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    class Gerenciador
    {
        public List<Livro> livros { get; } = new List<Livro>();
        public List<Usuario> usuarios { get; } = new List<Usuario>();
        public List<Emprestimo> emprestimos { get; } = new List<Emprestimo>();

        // LivroController livroController = new LivroController();

        #region Livro
        public void AdicionarLivros(Livro livro)
        {
            try
            {
                livro.ValidarDados();
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: Dado invalido: {erro.Message}");
                return;
            }
            livros.Add(livro);
        }

        public void ConsultarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }
            else
            {
                int index = 1;
                Console.WriteLine("Lista de Livros");
                Console.WriteLine(new string('-', 80));
                foreach (var livro in livros)
                {
                    Console.WriteLine($" Livro #{index++}\n" +
                        $"{"Codigo de Registo:",-20} {livro.IdLivro}\n" +
                        $"{"Autor:",-20} {livro.Autor}\n" +
                        $"{"Título:",-20}   {livro.Titulo}\n" +
                        $"{"ISBN:",-20}   {livro.ISBN}\n" +
                        $"{"Ano de Publicação:",-20}  {livro.AnoPublicacao}. ");
                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        public void ConsultarUmLivro()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }
            else
            {
                Console.WriteLine("Insira o título ou autor do livro:");
                string consulta = Console.ReadLine();
                int index = 1;

                var livrosEncontrados = livros.
                Where(lv =>
                lv.Titulo.Contains(consulta, StringComparison.OrdinalIgnoreCase) ||
                lv.Autor.Contains(consulta, StringComparison.OrdinalIgnoreCase)).ToList();

                if (livrosEncontrados.Count == 0)
                {
                    Console.WriteLine("Livro não encontrado.");
                    return;
                }
                else
                {
                    Console.WriteLine("Livro(s) encontrado(s):");
                    Console.WriteLine(new string('-', 80));
                    foreach (var livro in livrosEncontrados)
                    {
                        Console.WriteLine($" Livro #{index++}\n" +
                            $"{"Codigo de Registo:",-20} {livro.IdLivro}\n" +
                            $"{"Autor:",-20} {livro.Autor}\n" +
                            $"{"Título:",-20}   {livro.Titulo}\n" +
                            $"{"ISBN:",-20}   {livro.ISBN}\n" +
                            $"{"Ano de Publicação:",-20}  {livro.AnoPublicacao}. ");
                        Console.WriteLine(new string('-', 60));
                    }
                }
            }
        }

        public void ActualizarLivro(int index)
        {
            if (index >= 0 && index < livros.Count)
            {
                var livro = livros[index];

                Console.WriteLine($"{"Codigo de Registo:",-20} {livro.IdLivro}\n" +
                $"{"Título:",-20}   {livro.Titulo}\n" +
                $"{"ISBN:",-20}   {livro.ISBN}\n" +
                $"{"Ano de Publicação:",-20}  {livro.AnoPublicacao}.");

                Console.WriteLine("Escolha o dado a ser actualizado:\n" +
                    "1. Autor\n" +
                    "2. Título\n" +
                    "3. ISBN\n" +
                    "4. Ano de Publicação\n");

                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira o Autor do livro");
                        livro.Autor = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Insira o título do livro");
                        livro.Titulo = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Insira o ISBN do livro");
                        livro.ISBN = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Insira o ano de publicação do livro");
                        livro.AnoPublicacao = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }


        public void RemoverLivro(int index)
        {
            if (index >= 0 && index < livros.Count)
            {
                livros.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        #endregion

        #region Usuario
        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }



        public void ConsultarUsuarios()
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }
            else
            {
                int index = 1;
                Console.WriteLine("Lista de Usuários");
                Console.WriteLine(new string('-', 80));
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($" Usuário #{index++}\n" +
                        $"{"Codigo de Registo:",-20} {usuario.IdUsuario}\n" +
                        $"{"Nome:",-20} {usuario.Nome}\n" +
                        $"{"Email:",-20}   {usuario.Email}");
                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        public void ActualizarUsuario(int index)
        {
            if (index >= 0 && (index < usuarios.Count))
            {
                var usuario = usuarios[index];
                Console.WriteLine($"{"Codigo de Registo:",-20} {usuario.IdUsuario}\n" +
                $"{"Nome:",-20}   {usuario.Nome}\n" +
                $"{"Email:",-20}   {usuario.Email}.");
                Console.WriteLine("Escolha o dado a ser actualizado:\n" +
                    "1. Nome\n" +
                    "2. Email\n");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira o Nome do usuário");
                        usuario.Nome = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Insira o Email do usuário");
                        usuario.Email = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        public void RemoverUsuario(int index)
        {
            if (index >= 0 && index < usuarios.Count)
            {
                usuarios.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        #endregion


        #region Emprestimo
        public void CadastrarEmprestimo(Emprestimo emprestimo, Livro livro, Usuario usuario)
        {
            emprestimo.AtribuirLivro(livro);
            emprestimo.AtribuirUsuario(usuario);
            emprestimos.Add(emprestimo);
        }



        public void ConsultarEmprestimos()
        {
            int index = 1;
            Console.WriteLine("Lista de Emprestimos");
            Console.WriteLine("-", 50);
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($" Empréstimo #{index++}\n" +
                    $"{"Codigo de Empréstimo:",-20} {emprestimo.IdEmprestimo}\n" +
                    $"{"Livro:",-20}   {emprestimo.ConsultarNomeLivro}\n" +
                    $"{"Usuario:",-20}   {emprestimo.ConsultarNomeUsuario}\n" +
                    $"{"Data do Empréstimo:",-20}  {emprestimo.DataEmprestimo}\n" +
                    $"{"Data da Devolução: ",-20} {emprestimo.DataDevolucao}");
            }
        }

        public void DevolverLivro(DateTime data, Emprestimo emprestimo)
        {
            if (data > emprestimo.DataDevolucao)
            {
                int diasAtraso = (data - emprestimo.DataDevolucao).Days;
                Console.WriteLine($"Devolução em atraso com {diasAtraso} dias.");
            }
            else
            {
                Console.WriteLine("Devolução dentro do prazo");
            }
        }
        #endregion
    }
}
