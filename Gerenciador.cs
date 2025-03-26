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
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void AdicionarEmprestimo(Emprestimo emprestimo, Livro livro, Usuario usuario)
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
                Console.WriteLine($" Empréstimo #{index}\n" +
                    $"{"Codigo de Empréstimo:",-20} {emprestimo.IdEmprestimo}\n" +
                    $"{"Livro:",-20}   {emprestimo.Consultarlivro}\n" +
                    $"{"Usuario:",-20}   {emprestimo.ConsultarUsuario}\n" +
                    $"{"Data do Empréstimo:",-20}  {emprestimo.DataEmprestimo}\n" +
                    $"{"Data da Devolução: ",-20} {emprestimo.DataDevolucao}");
            }
        }
    }
}
