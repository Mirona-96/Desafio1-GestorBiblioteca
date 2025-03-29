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
