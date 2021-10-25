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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }

        public static string PrimeiroAdminEmail = "leandroleanleo@gmail.com";
        public static string PrimeiroAdminSenha = "sistema123";
        public static bool ativar = false;

        public static Funcionario funcionario;

        private async void FormPadrao_Load(object sender, EventArgs e)
        {
            BaseModel.Desktop = true;

            FrmAutenticacao form = new FrmAutenticacao();
            form.Show();
            await Task.Run(() => BaseModel.Recuperar());

            if (BaseModel.modelos.OfType<Permissao>().FirstOrDefault() == null)
            {
                var arr = new string[]
                {
                    "EnviarEmail", "LerEmail", "AtualizarEmail", "DeletarEmail", "CadastrarBody",
                    "CadastrarPessoa", "AtulizarPessoa", "BuscarPessoa", "DeletarPessoa",
                    "Admin", "AdminEmail", "AdminPessoa", "Permissao"
                };

                foreach (var item in arr)
                {
                    var permissao = new Permissao { Nome = item };
                    permissao.Salvar();
                }
            }

            await Task.Run(() => BuscaEmail("pop.gmail.com", 995, EmailAdvocacia.EndEmailAdvocacia, EmailAdvocacia.SenhaAdvocacia));


        }

        private void gerenciamentoDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ativar ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "EnviarEmail")    != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "LerEmail")       != null || 
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "DeletarEmail")   != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AtualizarEmail") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AdminEmail") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "Admin")          != null )
            {
                MDIEmail form = new MDIEmail();
                form.Show();
            }
            else
            {
                MessageBox.Show("Você precisa de se autenticar para possuir suas permissões");
                FrmAutenticacao form = new FrmAutenticacao();
                form.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void gerenciamentoDeFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ativar ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "Admin") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AdminPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AtulizarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "BuscarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "DeletarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "Permissao") != null )
            {
                MDIFormulario form = new MDIFormulario();
                form.Show();
            }
            else
            {
                MessageBox.Show("Você precisa de se autenticar para possuir suas permissões");
                FrmAutenticacao form = new FrmAutenticacao();
                form.Show();
            }
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

                        if (BaseModel.modelos.OfType<EmailCliente>().FirstOrDefault(e => e.MensagemId == Id) == null)
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
    }
}
