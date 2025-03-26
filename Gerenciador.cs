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
        public List<Livro> livros { get; } = [];
        public List<Usuario> usuarios { get; } = [];
        public List<Emprestimo> emprestimos { get; } = [];

        // LivroController livroController = new LivroController();

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
            int index = 1;
            Console.WriteLine("Lista de Livros");
            Console.WriteLine("-", 50);
            foreach (var livro in livros)
            {
                Console.WriteLine($" Livro #{index}\n" +
                    $"{"Codigo de Registo:",-20} {livro.IdLivro}\n" +
                    $"{"Título:",-20}   {livro.Titulo}\n" +
                    $"{"ISBN:",-20}   {livro.ISBN}\n" +
                    $"{"Ano de Publicação:",-20}  {livro.AnoPublicacao}. ");
            }
        }

        public void ConsultarUmLivro(string consulta)
        {
            foreach (var livro in livros)
            {
                if (livro.Titulo.Contains(consulta, StringComparison.OrdinalIgnoreCase) ||
                    livro.Autor.Contains(consulta, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{"Codigo de Registo:",-20} {livro.IdLivro}\n" +
                    $"{"Título:",-20}   {livro.Titulo}\n" +
                    $"{"ISBN:",-20}   {livro.ISBN}\n" +
                    $"{"Ano de Publicação:",-20}  {livro.AnoPublicacao}.");
                }
            }
        }

        public void RemoverLivro(int index)
        {
            livros.RemoveAt(index);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void CadastrarEmprestimo (Emprestimo emprestimo, Livro livro, Usuario usuario)
        {
            emprestimo.AtribuirLivro(livro);
            emprestimo.AtribuirUsuario(usuario);
            emprestimos.Add(emprestimo);
        }

        public void ConsultarEmprestimos ()
        {
            int index = 1;
            Console.WriteLine("Lista de Emprestimos");
            Console.WriteLine("-", 50);
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($" Empréstimo #{index}\n" +
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
    }
}
