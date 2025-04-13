using GestaoBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Controller
{
    class EmprestimoController
    {


        public List<Emprestimo> emprestimos { get; } = new List<Emprestimo>();

        #region Emprestimo
        public void CadastrarEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimo.ValidarDadosEmprestimo();
            } catch (Exception erro)
            {
                Console.WriteLine($"Erro: Dado Invalido: {erro.Message}");
                return;
            }
            emprestimos.Add(emprestimo);
        }



        public void ConsultarEmprestimos(List<Livro>livros, List<Usuario>usuarios)
        {
            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo cadastrado.");
                return;
            }
            else
            {
                int index = 1;
                Console.WriteLine("Lista de Emprestimos");
                Console.WriteLine("-", 50);
                foreach (var emprestimo in emprestimos)
                {
                    Console.WriteLine(
                        $" Empréstimo #{index++}\n" +
                        $"{"Codigo de Empréstimo:",-20} {emprestimo.IdEmprestimo}\n" +
                        $"{"Livro:",-20}   {emprestimo.ConsultarNomeLivro(livros)}\n" +
                        $"{"Usuario:",-20}   {emprestimo.ConsultarNomeUsuario(usuarios)}\n" +
                        $"{"Data do Empréstimo:",-20}  {emprestimo.DataEmprestimo}\n" +
                        $"{"Data da Devolução: ",-20} {emprestimo.DataDevolucao}");
                    Console.WriteLine(new string('-', 50));

                }
            }
        }

        public void DevolverLivro(List<Livro> livros, List<Usuario> usuarios)
        {
            if(emprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo cadastrado.");
                return;
            } 
            else
            {
                ConsultarEmprestimos(livros,usuarios);
                Console.WriteLine("Escolha o empréstimo a devolver:");
                int index = int.Parse(Console.ReadLine()) - 1;
                var emprestimo = emprestimos[index];

                Console.WriteLine("Insira a data de devolução:");
                DateTime data = DateTime.Now;

                if (data > emprestimo.DataDevolucao)
                {
                    int diasAtraso = (data - emprestimo.DataDevolucao).Days;
                    Console.WriteLine($"Devolução em atraso com {diasAtraso} dias.");
                }
                else
                {
                    Console.WriteLine("Devolução dentro do prazo.");
                }
            }
        }

        public void ActualizarEmprestimo(int index, List<Livro>livros, List<Usuario>usuarios)
        {
            if(index >= 0 && (index < emprestimos.Count))
            {
                var emprestimo = emprestimos[index];
                Console.WriteLine(
                    $"{"Codigo de Empréstimo:",-20} {emprestimo.IdEmprestimo}\n" +
                    $"{"Livro:",-20}   {emprestimo.ConsultarNomeLivro(livros)}\n" +
                    $"{"Usuario:",-20}   {emprestimo.ConsultarNomeUsuario(usuarios)}\n" +
                    $"{"Data do Empréstimo:",-20}  {emprestimo.DataEmprestimo}\n" +
                    $"{"Data da Devolução: ",-20} {emprestimo.DataDevolucao}");
                Console.WriteLine("Escolha o dado a ser actualizado:\n" +
                    "1. Data de Devolução\n");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite a nova data de devolução:");
                        emprestimo.DataDevolucao = DateTime.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Emprestimo não encontrado.");
            }
        }

        public void RemoverEmprestimo(int index)
        {
            if(index >= 0 && (index < emprestimos.Count))
            {
                emprestimos.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Emprestimo não encontrado.");
            }
        }
        #endregion
    }
}
