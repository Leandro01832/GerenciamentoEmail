using business;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        private async void FrmOpenEmail_Load(object sender, EventArgs e)
        {
            ListaEmail = BaseModel.modelos.OfType<EmailCliente>().OrderByDescending(em => em.Data).ToList();

            foreach (var item in ListaEmail)
                lstBoxEmail.Items.Add(item);

          await Task.Run(() =>  BuscaEmail("pop.gmail.com", 995, EmailAdvocacia.EndEmailAdvocacia, EmailAdvocacia.SenhaAdvocacia));

        }

        public void BuscaEmail(string nome_servidor_pop, int porta, string email, string senha)
        {
            // A instrução using faz a desconexão do servidor de email
            // e libera corretamente o objeto
            using (Pop3Client cliente_pop = new Pop3Client())
            {
                // Faz a conexão com o servidor
                cliente_pop.Connect(nome_servidor_pop, porta, true);

                // Faz a autenticação no servidor
                cliente_pop.Authenticate(email, senha);

                // Obtêm o número total de emails da caixa de entrada
                int numero_emails = cliente_pop.GetMessageCount();

                // Faz a leitura dos 10 emails mais recentes da caixa de entrada,
                // iniciando a partir do último email recebido.

                int numero = numero_emails;

                for (int i = 0; i < numero; i++)
                {
                    var popEmail = cliente_pop.GetMessage(numero_emails);
                    // Cabeçalho da mensagem
                    MessageHeader headers = cliente_pop.GetMessageHeaders(numero_emails);

                    var Id = headers.MessageId;

                    // Email De:
                    RfcMailAddress emailDe = headers.From;

                    // Email Para:
                    // Faz a leitura de todos os emails Para, mas exibe somente o primeiro.
                    List<RfcMailAddress> emailParaList = headers.To;
                    string emailPara = string.Empty;
                    if (emailParaList != null && emailParaList.Count() > 0)
                    {
                        emailPara = emailParaList.First().Address;
                    }

                    // Assunto
                    string assunto = headers.Subject;

                    // Data de envio
                    DateTime data_envio = headers.DateSent;

                    var popText = popEmail.FindFirstPlainTextVersion();
                    var popHtml = popEmail.FindFirstHtmlVersion();

                    string mailText = string.Empty;
                    string mailHtml = string.Empty;
                    if (popText != null)
                        mailText = popText.GetBodyAsText();
                    if (popHtml != null)
                        mailHtml = popHtml.GetBodyAsText();

                    // Verifica se o endereço de email De é válido
                    if (emailDe.HasValidMailAddress)
                    {

                        var em = new EmailCliente
                        {
                            Assunto = assunto,
                            Body = mailHtml,
                            ConteudoTexto = mailText,
                            Data = data_envio,
                            MensagemId = Id,
                            Remetente = emailDe.Address                                   
                        };
                        
                        if(BaseModel.modelos.OfType<EmailCliente>().FirstOrDefault(e => e.MensagemId == Id) == null)
                            {
                                em.Salvar();
                                BaseModel.modelos.Add(em);
                            }
                        

                        // Decrementa o número de emails
                        numero_emails--;
                    }
                }
            }
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
