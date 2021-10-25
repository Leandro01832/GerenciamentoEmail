using business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmClientePJ : FrmCrud
    {
        public FrmClientePJ()
        {
            InitializeComponent();
        }
        // variavel para evitar bug
        bool condicao = false;

        public FrmClientePJ(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FrmClientePJ_Load(object sender, EventArgs e)
        {
            lstBoxPessoa.DataSource = BaseModel.modelos.OfType<Pessoa>().ToList();
            lstBoxPessoa.SetSelected(0, false);

            var PessoaPJ = (PessoaPJ)Modelo;
            if (PessoaPJ.Id != 0)
            {
                txtEmail.Text = PessoaPJ.Email;
                txtNome.Text = PessoaPJ.Nome;
                txtCnpj.Text = PessoaPJ.Cnpj;

                foreach (var item in PessoaPJ.Clientes)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item);
                    lstBoxPessoa.SetSelected(indice, true);
                }
            }

            condicao = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var PessoaPJ = (PessoaPJ)Modelo;
            PessoaPJ.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var PessoaPJ = (PessoaPJ)Modelo;
            PessoaPJ.Email = txtEmail.Text;
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            var PessoaPJ = (PessoaPJ)Modelo;
            PessoaPJ.Cnpj = txtCnpj.Text;
        }

        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            var PessoaPJ = (PessoaPJ)Modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.OfType<Pessoa>().ToList();
                    PessoaPJ.Clientes = new List<Pessoa>();
                    foreach (var item in objetos)
                        PessoaPJ.Clientes.Add(item); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }
    }
}

