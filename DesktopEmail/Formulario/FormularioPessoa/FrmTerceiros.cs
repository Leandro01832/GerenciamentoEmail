using business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmTerceiros : FrmCrud
    {
        public FrmTerceiros()
        {
            InitializeComponent();
        }

        // variavel para evitar bug
        bool condicao = false;

        public FrmTerceiros(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FrmTerceiros_Load(object sender, EventArgs e)
        {
            lstBoxEmpresa.DataSource = BaseModel.modelos.OfType<PessoaPJ>().ToList();
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
