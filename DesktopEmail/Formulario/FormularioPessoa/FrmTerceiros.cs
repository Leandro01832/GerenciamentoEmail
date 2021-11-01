using business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmTerceiros : FrmCrud
    {
        public FrmTerceiros() : base()
        {
            InitializeComponent();
        }

        // variavel para evitar bug
        bool condicao = false;
        

        private void FrmTerceiros_Load(object sender, EventArgs e)
        {
            lstBoxEmpresa.DataSource = BaseModel.modelos.OfType<PessoaPJ>().ToList();
            if (BaseModel.modelos.OfType<PessoaPJ>().ToList().Count > 0)
                lstBoxEmpresa.SetSelected(0, false);

            var PessoaPF = (PessoaPF)Modelo;
            if (PessoaPF.Id != 0)
            {
                txtEmail.Text = PessoaPF.Email;
                txtNome.Text = PessoaPF.Nome;

                if (PessoaPF.PessoaPJId != null)
                    lstBoxEmpresa.SelectedIndex = (int)PessoaPF.PessoaPJId;
            }

            condicao = true;
            LoadForm();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var Terceiros = (Terceiros)Modelo;
            Terceiros.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var Terceiros = (Terceiros)Modelo;
            Terceiros.Email = txtEmail.Text;
        }

        private void lstBoxEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            var terceiro = (Terceiros)Modelo;
            try
            {
                if (condicao)
                {
                    var valor = (PessoaPJ)lstBoxEmpresa.SelectedItem;
                    terceiro.PessoaPJId = valor.Id; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }
    }
}
