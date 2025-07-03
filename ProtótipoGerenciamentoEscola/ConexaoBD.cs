using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtótipoGerenciamentoEscola
{
    internal class ConexaoBD
    {
        private const string conexaoBanco = "Server=localhost;Database=agenda_escolar;Uid=root;Pwd=;";
        public MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(conexaoBanco);
            conexao.ConnectionString = conexaoBanco;
            conexao.Open();
            return conexao;
        }
    }
}
