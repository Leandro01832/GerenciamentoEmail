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

            lstCategoria.DataSource = BaseModel.modelos
            .OfType<Permissao>().Where(p => p.Id > 9).ToList();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            var verificacao = BaseModel.modelos.OfType<Pessoa>().FirstOrDefault(p => p.Email == txtEmail.Text);
            if(verificacao != null && FormPadrao.ativar && BaseModel.modelos
            .OfType<Permissao>().Where(em => em.Id > 9).ToList().Count > 0 ||
               verificacao != null &&
               FormPadrao.funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "EnviarEmail") != null &&
               BaseModel.modelos.OfType<Permissao>().Where(em => em.Id > 13).ToList().Count > 0)
            {
                var valor = email.Body.Html;

                MailMessage mail = new MailMessage(FormPadrao.Email, txtEmail.Text);

                mail.Subject = txtAssunto.Text;
                mail.Body = valor;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mail.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential(FormPadrao.Email, FormPadrao.SenhaEmail);
                cliente.EnableSsl = true;

                await cliente.SendMailAsync(mail);

                var pessoa = BaseModel.modelos.OfType<Pessoa>().FirstOrDefault(p => p.Email == txtEmail.Text);

                email.Enviado = true;
                var categoria = (Categoria)lstCategoria.SelectedItem;
                email.Categoria.Permissao.Nome = categoria.Permissao.Nome;
                email.Categoria.Id = categoria.Id;
                email.Alterar();
                MessageBox.Show("Email enviado com sucesso!!!");
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

        private void lstCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            email = (EmailAdvocacia)lstEmail.SelectedItem;
            var categoria = (Permissao)lstCategoria.SelectedItem;
            if(email != null)
            email.CategoriaId = categoria.Id;
        }
    }
}
