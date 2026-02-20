using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProtótipoGerenciamentoEscola
{
    internal class Professor
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? DisciplinaId { get; set; }
        public string? DisciplinaNome { get; set; }
        public int? EnderecoId { get; set; }
        public int? ContatoId { get; set; }
        public int? GetAge()
        {
            if (!DataNascimento.HasValue) return null;
            var t = DateTime.Today;
            var a = t.Year - DataNascimento.Value.Year;
            if (DataNascimento.Value.Date > t.AddYears(-a)) a--;
            return a;
        }
        

        public static bool verificarEmail(string email)
        {
            string emailValido = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailValido);
            return regex.IsMatch(email);
        }

        public bool CadastrarProfessor(Professor prof, Endereco end, Contato cont, ConexaoBD conexaoBD)
        {
            try
            {
                using MySqlConnection conn = conexaoBD.Conectar();
                using var tran = conn.BeginTransaction();

                // Substituir ExecuteScalar por um comando manual usando MySqlCommand
                // Endereço
                MySqlCommand enderecoCmd = new MySqlCommand(
                    @"INSERT INTO Endereco (cep, rua, numero, bairro, cidade, estado, complemento)
                      VALUES (@Cep,@Rua,@Numero,@Bairro,@Cidade,@Estado,@Complemento);
                      SELECT LAST_INSERT_ID();", conn, tran);
                enderecoCmd.Parameters.AddWithValue("@Cep", end.Cep);
                enderecoCmd.Parameters.AddWithValue("@Rua", end.Rua);
                enderecoCmd.Parameters.AddWithValue("@Numero", end.Numero);
                enderecoCmd.Parameters.AddWithValue("@Bairro", end.Bairro);
                enderecoCmd.Parameters.AddWithValue("@Cidade", end.Cidade);
                enderecoCmd.Parameters.AddWithValue("@Estado", end.Estado);
                enderecoCmd.Parameters.AddWithValue("@Complemento", end.Complemento);
                int enderecoId = Convert.ToInt32(enderecoCmd.ExecuteScalar());

                // Contato
                MySqlCommand contatoCmd = new MySqlCommand(
                    @"INSERT INTO Contato (telefone_celular, telefone_residencial, email)
                      VALUES (@TelefoneCelular,@TelefoneResidencial,@Email);
                      SELECT LAST_INSERT_ID();", conn, tran);
                contatoCmd.Parameters.AddWithValue("@TelefoneCelular", cont.TelefoneCelular);
                contatoCmd.Parameters.AddWithValue("@TelefoneResidencial", cont.TelefoneResidencial);
                contatoCmd.Parameters.AddWithValue("@Email", cont.Email);
                int contatoId = Convert.ToInt32(contatoCmd.ExecuteScalar());

                // Professor
                MySqlCommand professorCmd = new MySqlCommand(
                    @"INSERT INTO Professor
                      (nome_completo, cpf, data_nascimento, disciplina_id, id_endereco, id_contato)
                      VALUES (@NomeCompleto,@Cpf,@DataNascimento,@DisciplinaId,@EnderecoId,@ContatoId);", conn, tran);
                professorCmd.Parameters.AddWithValue("@NomeCompleto", prof.NomeCompleto);
                professorCmd.Parameters.AddWithValue("@Cpf", prof.Cpf);
                professorCmd.Parameters.AddWithValue("@DataNascimento", prof.DataNascimento);
                professorCmd.Parameters.AddWithValue("@DisciplinaId", prof.DisciplinaId);
                professorCmd.Parameters.AddWithValue("@EnderecoId", enderecoId);
                professorCmd.Parameters.AddWithValue("@ContatoId", contatoId);
                int result = professorCmd.ExecuteNonQuery();

                tran.Commit();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar professor: {ex.Message}");
                return false;
            }
        }

        internal bool CadastrarProfessor(Professor prof, Endereco end, Contato cont)
        {
            throw new NotImplementedException();
        }

        
    }
}
