using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DLL;
using Dominio;
using MySql.Data.MySqlClient;

namespace AppUsuarioDAO

{
   public class UsuarioDAO
    {
        private Banco db;
        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "insert into tbUsuario(NomeUsu,Cargo,DataNasc) values";
            strQuery += string.Format(" ('{0}','{1}',STR_TO_DATE('{2}','%d/%m/%Y %T'));",usuario.NomeUsu,usuario.Cargo,usuario.DataNasc);


            using (db=new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Update(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "update tbUsuario set ";
            strQuery += string.Format("NomeUsu = '{0}', Cargo = '{1}', DataNasc = STR_TO_DATE('{2}','%d/%m/%Y %T') where IdUsu = {3};", usuario.NomeUsu, usuario.Cargo, usuario.DataNasc, usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format(" delete from  tbusuario where IdUsu = {0};",id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Select()
        {
            using (db = new Banco())
            {
              string strQuery= "select * from tbUsuario;";        
              var leitor = db.RetornaComando(strQuery);

                return GeraListUsuario(leitor);
            }            
        }


        public List<Usuario> GeraListUsuario(MySqlDataReader leitor)
        {
            var usuarios = new List<Usuario>();
            
            while(leitor.Read())
            {
                var tempUsuario = new Usuario()
                {
                    IdUsu =int.Parse(leitor["IdUsu"].ToString()),
                    NomeUsu=leitor["NomeUsu"].ToString(),
                    Cargo=leitor["Cargo"].ToString(),
                    DataNasc=DateTime.Parse(leitor["DataNasc"].ToString())                    
                };
                usuarios.Add(tempUsuario);
            }
            leitor.Close();
            return usuarios;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("====================AppBanco====================");
            Console.WriteLine("=             0 - Cadastrar usuario            =");
            Console.WriteLine("=             1 - Editar usuario               =");
            Console.WriteLine("=             2 - Excluir usuario              =");
            Console.WriteLine("=             3 - Listar usuario               =");
            Console.WriteLine("=             4 - Sair                         =");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Qual opção você deseja?");
        }
        public Usuario DadosUsuario()
        {
            var usuario = new Usuario();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            usuario.NomeUsu = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o Cargo:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            usuario.Cargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite a Data:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            usuario.DataNasc = DateTime.Parse(Console.ReadLine());
            return usuario;
        }
        }
    }
