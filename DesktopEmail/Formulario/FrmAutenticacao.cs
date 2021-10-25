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
    public partial class FrmAutenticacao : Form
    {
        public FrmAutenticacao()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(FormPadrao.PrimeiroAdminEmail == txtEmail.Text && FormPadrao.PrimeiroAdminSenha == txtSenha.Text)
            {
                FormPadrao.ativar = true;
                this.Dispose();
            }
            else
            if(BaseModel.modelos.OfType<Funcionario>()
            .FirstOrDefault(m => m.Senha == txtSenha.Text &&
            m.Email == txtEmail.Text) != null)
            {
                FormPadrao.funcionario = BaseModel.modelos.OfType<Funcionario>()
                .First(m => m.Senha == txtSenha.Text &&
                m.Email == txtEmail.Text);
                this.Dispose();
            }
        }
    }
}
