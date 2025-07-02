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
    public partial class TelaEndereco : Form
    {
        public TelaEndereco()
        {
            InitializeComponent();
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
