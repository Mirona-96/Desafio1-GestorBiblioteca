using GestaoBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Controller
{
    class UsuarioController
    {
        public List <Usuario> usuarios { get; } = new List<Usuario>();

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
                    Console.WriteLine(
                        $" Usuário #{index++}\n" +
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
                Console.WriteLine(
                $"{"Codigo de Registo:",-20} {usuario.IdUsuario}\n" +
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
                Console.WriteLine("Usuário eliminado");
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }
        #endregion
    }
}
