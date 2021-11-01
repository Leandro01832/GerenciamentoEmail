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
using static System.Windows.Forms.ListBox;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmAdmin : FrmCrud
    {
        public FrmAdmin() : base()
        {
            InitializeComponent();
        }
        
        

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            if(admin.Id != 0)
            {
                txtEmail.Text = admin.Email;
                txtNome.Text = admin.Nome;
                txtSenha.Text = admin.Senha;
            }
            else
            admin.Permissao = new List<PermissaoFuncionario>();
            LoadForm();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Email = txtEmail.Text;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Senha = txtSenha.Text;
        }
        
    }
}
