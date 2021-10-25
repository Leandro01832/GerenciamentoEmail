using business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmClientePF : FrmCrud
    {
        public FrmClientePF()
        {
            InitializeComponent();
        }
        // variavel para evitar bug
        bool condicao = false;

        public FrmClientePF(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FrmClientePF_Load(object sender, EventArgs e)
        {
            lstBoxEmpresa.DataSource = BaseModel.modelos.OfType<PessoaPJ>().ToList();
            lstBoxEmpresa.SetSelected(0, false);

            var PessoaPF = (PessoaPF)Modelo;
            if (PessoaPF.Id != 0)
            {
                txtEmail.Text = PessoaPF.Email;
                txtNome.Text = PessoaPF.Nome;
                txtCpf.Text = PessoaPF.Cpf;

                if(PessoaPF.PessoaPJId != null)
                 lstBoxEmpresa.SelectedIndex = (int) PessoaPF.PessoaPJId;
            }

            condicao = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var PessoaPF = (PessoaPF)Modelo;
            PessoaPF.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var PessoaPF = (PessoaPF)Modelo;
            PessoaPF.Email = txtEmail.Text;
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            var PessoaPF = (PessoaPF)Modelo;
            PessoaPF.Cpf = txtCpf.Text;
        }

        private void lstBoxEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            var PessoaPF = (PessoaPF)Modelo;
            try
            {
                if (condicao)
                {
                    var valor = (PessoaPJ)lstBoxEmpresa.SelectedItem;
                    PessoaPF.PessoaPJId = valor.Id; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }
    }
}
