using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppConsoleBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = dbEXEMPLO; user id = root; Password =12345678");
            conexao.Open();
            string strSelecionaUsu = "select * from tbUsuario;";

            MySqlCommand comando = new MySqlCommand(strSelecionaUsu,conexao);
            MySqlDataReader leitor = comando.ExecuteReader();
            
            while (leitor.Read())
            {
                Console.WriteLine("Código: {0},  Nome: {1}, Cargo:{2},  Data de Nascimento: {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Nasc"]);
            }

            Console.WriteLine("Conectado!");
            Console.ReadLine();        
        
        }
    }
}
