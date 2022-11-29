using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

namespace trabalho_katia
{
    public class Conexao
    {
        public void Cmd (string parametro)
        {
            MySqlConnection Conectar = new MySqlConnection("server=localhost;User Id=root;database=bdcadastro;password=cursoads");
            MySqlCommand Comm = new MySqlCommand(parametro, Conectar);
            try
            {
                Conectar.Open();
                Comm.ExecuteNonQuery();
            }
            catch
            {
                Conectar.Close();
            }
        }

    }
}
