using business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmClientePF : FrmCrud
    {
        public FrmClientePF() : base()
        {
            InitializeComponent();
        }
        // variavel para evitar bug
        bool condicao = false;
        

        private void FrmClientePF_Load(object sender, EventArgs e)
        {
            lstBoxEmpresa.DataSource = BaseModel.modelos.OfType<PessoaPJ>().ToList();
            if(BaseModel.modelos.OfType<PessoaPJ>().ToList().Count > 0)
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
            LoadForm();
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

        private void txtCpf_TextChanged(object sender, EventArgs e)
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
