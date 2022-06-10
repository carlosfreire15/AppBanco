using AppUsuarioDAO;
using Dominio;
using MySql.Data.MySqlClient;
using System;
namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = new Usuario();

            while (true)
            {
                Console.Clear();
                usuarioDAO.Menu();
                Console.ForegroundColor = ConsoleColor.Yellow;
                string opçao = Console.ReadLine();

                switch(opçao)
                {
                    case "0":
                        usuario = usuarioDAO.DadosUsuario();
                        usuarioDAO.Insert(usuario);
                        break;
                    case "1":
                        usuario = usuarioDAO.DadosUsuario();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Digite o ID:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        usuario.IdUsu = int.Parse(Console.ReadLine());
                        usuarioDAO.Update(usuario);
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Digite o ID:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        usuarioDAO.Delete(int.Parse(Console.ReadLine()));
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                if (opçao == "0" || opçao == "1" || opçao == "2" || opçao == "3")
                {

                    var ListaUsuarios = usuarioDAO.Select();

                    foreach (var usu in ListaUsuarios)
                    {
                        Console.WriteLine("Id = {0},  Nome = {1}, Cargo = {2}, Data de Nascimento = {3}",
                            usu.IdUsu, usu.NomeUsu, usu.Cargo, usu.DataNasc);
                    };
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Precione o enter para retornar ao menu");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Precione o enter e escolha uma das opções: 0, 1, 2, 3 ou 4");
                }
                Console.ReadLine();

            }

        }
    }
}
