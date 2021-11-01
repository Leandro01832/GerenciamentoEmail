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
    public partial class FrmAtendente : FrmCrud
    {
        public FrmAtendente() : base()
        {
            InitializeComponent();
        }
        

        // variavel para evitar bug
        bool condicao = false;

        private void FrmAtendente_Load(object sender, EventArgs e)
        {
            var Atendente = (Atendente)Modelo;
            lstPermissoes.DataSource = BaseModel.modelos.OfType<Permissao>().ToList();
            lstPermissoes.SetSelected(0, false);

            if (Atendente.Id != 0)
            {
                txtEmail.Text = Atendente.Email;
                txtNome.Text = Atendente.Nome;
                txtSenha.Text = Atendente.Senha;
                foreach (var item in Atendente.Permissao)
                {
                    var indice = lstPermissoes.Items.IndexOf(item.Permissao);
                    lstPermissoes.SetSelected(indice, true);
                }
            }
            else
                Atendente.Permissao = new List<PermissaoFuncionario>();

            condicao = true;
            LoadForm();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)Modelo;
            Atendente.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)Modelo;
            Atendente.Email = txtEmail.Text;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)Modelo;
            Atendente.Senha = txtSenha.Text;
        }

        private void lstPermissoes_SelectedValueChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)Modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstPermissoes.SelectedItems;
                    var objetos = valor.OfType<Permissao>().ToList();
                    Atendente.Permissao = new List<PermissaoFuncionario>();
                    foreach (var item in objetos)
                        Atendente.Permissao.Add(new PermissaoFuncionario { PermissaoId = item.Id }); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu. " + ex.Message);
            }
        }

       
    }
}
