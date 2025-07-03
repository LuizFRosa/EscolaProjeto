namespace ProtótipoGerenciamentoEscola
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }


        private void pbFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTelaAluno_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaAluno = new TelaPrincipal();
            telaAluno.ShowDialog();
            // Vai para a tela de cadastro de aluno
        }

        private void btnTelaResponsaveis_Click(object sender, EventArgs e)
        {
            TelaResponsavel telaResponsavel = new TelaResponsavel();
            telaResponsavel.ShowDialog();
            // Vai para a tela de cadastro de responsável
        }

        private void btnTelaEndContato_Click(object sender, EventArgs e)
        {
            TelaEndereco telaEndereco = new TelaEndereco();
            telaEndereco.ShowDialog();
            // Vai para a tela de cadastro de endereço e contato
        }

        private void btnTurmas_Click(object sender, EventArgs e)
        {
            TelaTurma telaTurma = new TelaTurma();
            telaTurma.ShowDialog();
            // Vai para a tela de cadastro de turmas
        }

        private void btnFichaCadastral_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaAluno = new TelaPrincipal();
            telaAluno.ShowDialog();
            // Vai para a tela de ficha cadastral que seria a mesma tela de cadastro de aluno
        }
    }
}
