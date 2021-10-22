using business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }

        public static string PrimeiroAdminEmail = "leandroleanleo@gmail.com";
        public static string PrimeiroAdminSenha = "sistema123";
        public static bool ativar = false;

        private void FormPadrao_Load(object sender, EventArgs e)
        {
            FrmAutenticacao form = new FrmAutenticacao();
            form.Show();
            Task.Run(() => BaseModel.Recuperar());
        }

        private void gerenciamentoDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ativar)
            {
                MDIEmail form = new MDIEmail();
                form.Show();
            }
            else
            {
                MessageBox.Show("Você precisa de se autenticar para possuir suas permissões");
                FrmAutenticacao form = new FrmAutenticacao();
                form.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void gerenciamentoDeFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ativar)
            {
                MDIFormulario form = new MDIFormulario();
                form.Show();
            }
            else
            {
                MessageBox.Show("Você precisa de se autenticar para possuir suas permissões");
                FrmAutenticacao form = new FrmAutenticacao();
                form.Show();
            }
        }
    }
}
