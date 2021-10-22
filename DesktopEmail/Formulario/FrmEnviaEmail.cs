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
        
        

        private void FrmEnviaEmail_Load(object sender, EventArgs e)
        {
            var valor = mstHtmlEditor1.BodyHTML;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            var valor = mstHtmlEditor1.BodyOuterHtml;

            MailMessage mail = new MailMessage(EmailAdvocacia.EndEmailAdvocacia, txtEmail.Text);

            mail.Subject = "Advocacia";
            mail.Body = valor;
            mail.IsBodyHtml = true;
            mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mail.BodyEncoding = Encoding.GetEncoding("UTF-8");

            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new NetworkCredential(EmailAdvocacia.EndEmailAdvocacia, "Gasparzinho2020");
            cliente.EnableSsl = true;

            await cliente.SendMailAsync(mail);
            btnEnviar.Enabled = true;

        }
    }
}
