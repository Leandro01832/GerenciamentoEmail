using business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmEnviaEmail : Form
    {
        public FrmEnviaEmail()
        {
            InitializeComponent();
        }

        EmailAdvocacia email;

        private void FrmEnviaEmail_Load(object sender, EventArgs e)
        {
            lstEmail.DataSource = BaseModel.modelos
            .OfType<EmailAdvocacia>().Where(em => !em.Enviado).ToList();
             email = (EmailAdvocacia) lstEmail.SelectedItem;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            var verificacao = BaseModel.modelos.OfType<Pessoa>().FirstOrDefault(p => p.Email == txtEmail.Text);
            if(verificacao != null)
            {
                var valor = email.Body.Html;

                MailMessage mail = new MailMessage(EmailAdvocacia.EndEmailAdvocacia, txtEmail.Text);

                mail.Subject = txtAssunto.Text;
                mail.Body = valor;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mail.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential(EmailAdvocacia.EndEmailAdvocacia, "Gasparzinho2020");
                cliente.EnableSsl = true;

                await cliente.SendMailAsync(mail);

                var pessoa = BaseModel.modelos.OfType<Pessoa>().FirstOrDefault(p => p.Email == txtEmail.Text);

                EmailAdvocacia emai = new EmailAdvocacia();
                emai.Assunto = txtAssunto.Text;
                emai.Data = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                emai.MensagemId = "";
                emai.PessoaId = pessoa.Id;
                emai.Body = new Body();
                emai.Body.Html = valor;
                emai.Salvar();


            }
            else
            {
                MessageBox.Show("Este e-mail não esta cadastrado");
            }
                btnEnviar.Enabled = true;
        }

        private void lstEmail_SelectedValueChanged(object sender, EventArgs e)
        {
            email = (EmailAdvocacia)lstEmail.SelectedItem;
            txtAssunto.Text = email.Assunto;
            txtEmail.Text = email.Pessoa.Email;
            wbHtml.DocumentText = email.Body.Html;
        }
    }
}
