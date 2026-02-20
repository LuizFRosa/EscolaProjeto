using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtótipoGerenciamentoEscola
{
    public partial class TelaProfessor : Form
    {
        public int? DisciplinaId { get; private set; }

        public TelaProfessor()
        {
            InitializeComponent();
            Load += TelaProfessor_Load;
        }

        private void TelaProfessor_Load(object sender, EventArgs e)
        {
            var disciplinas = CarregarDisciplinas();
            cbDisciplina.DataSource = disciplinas;
            cbDisciplina.DisplayMember = "Nome";
            cbDisciplina.ValueMember = "Id";
            cbDisciplina.SelectedIndex = -1;  // deixa sem seleção inicial
        }

        private void btnFichaCadastral_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaAluno = new TelaPrincipal();
            telaAluno.ShowDialog();
            // Vai para a tela de ficha cadastral que seria a mesma tela de cadastro de aluno
        }

        private void btnTurmas_Click(object sender, EventArgs e)
        {
            TelaTurma telaTurma = new TelaTurma();
            telaTurma.ShowDialog();
            // Vai para a tela de cadastro de turmas
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                // Criar objeto Professor e preencher com dados do formulário
                Professor prof = new Professor()
                {
                    NomeCompleto = txtNome.Text,
                    Cpf = mtxtCPF.Text,
                    DataNascimento = dtpDataNascimento.Value,
                    DisciplinaId = cbDisciplina.SelectedIndex >= 0 ? (int?)cbDisciplina.SelectedValue : null,
                };

                // Criar objeto Endereco e preencher com dados do formulário
                Endereco end = new Endereco()
                {
                    Cep = mtxtCEP.Text,
                    Rua = txtRua.Text,
                    Numero = txtNumeroCasa.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstadoSigla.Text,
                    Complemento = txtComplemento.Text
                };

                // Criar objeto Contato e preencher com dados do formulário
                Contato cont = new Contato()
                {
                    TelefoneCelular = mtxtTelResidencia.Text,
                    TelefoneResidencial = mtxtTelCelular.Text,
                    Email = txtEmail.Text
                };

                // Validar e-mail antes de cadastrar (exemplo simples)
                if (!Professor.verificarEmail(cont.Email))
                {
                    MessageBox.Show("E-mail inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Instanciar a classe Professor para chamar o método
                var professor = new Professor();

                // Tentar cadastrar
                bool sucesso = professor.CadastrarProfessor(prof, end, cont);

                if (sucesso)
                    MessageBox.Show("Professor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Falha ao cadastrar professor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DisciplinaId = cbDisciplina.SelectedIndex >= 0
              ? (int?)cbDisciplina.SelectedValue
              : null;
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ClearControls(this);
        }

        private List<Disciplina> CarregarDisciplinas()
        {
            var lista = new List<Disciplina>();
            try
            {
                using var conn = new ConexaoBD().Conectar();
                using var cmd = new MySql.Data.MySqlClient.MySqlCommand(
                    "SELECT id_disciplina, nome FROM Disciplina ORDER BY nome", conn);
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Disciplina
                    {
                        Id = rdr.GetInt32("id_disciplina"),
                        Nome = rdr.GetString("nome")
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar disciplinas:\n{ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        private void ClearControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tb:
                        tb.Clear();
                        break;
                    case MaskedTextBox mtb:
                        mtb.Clear();
                        break;
                    case ComboBox cb:
                        cb.SelectedIndex = -1;
                        break;
                    case DateTimePicker dtp:
                        dtp.Value = DateTime.Today;
                        break;
                        // se tiver algum NumericUpDown, CheckedListBox etc., trate aqui também
                }

                // Se o controle tiver filhos (e.g. Panel, GroupBox), limpa recursivamente:
                if (ctrl.HasChildren)
                    ClearControls(ctrl);
            }
        }

    }
}
