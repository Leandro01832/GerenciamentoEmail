using business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmOpenEmail : Form
    {
        public FrmOpenEmail()
        {
            InitializeComponent();
        }

        List<EmailCliente> ListaEmail;

        EmailCliente selecionado;

        private void FrmOpenEmail_Load(object sender, EventArgs e)
        {
            ListaEmail = BaseModel.modelos.OfType<EmailCliente>().OrderByDescending(em => em.Data).ToList();

            foreach (var item in ListaEmail)
                lstBoxEmail.Items.Add(item);          

        }

        

        private void lstBoxEmail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBoxEmail_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                selecionado = (EmailCliente) lstBoxEmail.SelectedItem;

                txtDe.Text = selecionado.Remetente;

                web.DocumentText = selecionado.Body;

                txtData.Text = selecionado.Data.ToString("dd/MM/yyyy");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }
    }
}
