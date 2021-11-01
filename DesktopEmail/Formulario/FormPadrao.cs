using business;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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

        public static string Email;
        public static string SenhaEmail;
        public static string PrimeiroAdminEmail = "leandro123";
        public static string PrimeiroAdminSenha = "sistema123";
        public static bool ativar = false;
        static bool condicao = true;

        public static Funcionario funcionario;
        Timer timer;
        static string path = Directory.GetCurrentDirectory();

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer($@"{path}\desperta.wav");
            simpleSound.Play();
        }

        private async void FormPadrao_Load(object sender, EventArgs e)
        {
          //  Process.Start("https://www.advocacia.somee.com");
            notifyIcon1.Icon = new Icon($@"{path}\favicon.ico");
            timer = new Timer();
            timer.Interval = 60000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            var appSettings = ConfigurationManager.AppSettings;
            Email = appSettings["Email"];
            SenhaEmail = appSettings["Senha"];
            BaseModel.Desktop = true;

            FrmAutenticacao form = new FrmAutenticacao();
            form.Show();
            await Task.Run(() => BaseModel.Recuperar());

            if (BaseModel.modelos.OfType<Permissao>().FirstOrDefault() == null)
            {
                var arr = new string[]
                {
                    "EnviarEmail", "LerEmail", "AtualizarEmail", "DeletarEmail", "CadastrarBody",
                    "CadastrarPessoa", "AtulizarPessoa", "BuscarPessoa", "DeletarPessoa"
                };

                foreach (var item in arr)
                {
                    var permissao = new Permissao { Nome = item };
                    permissao.Salvar();
                }
                await Task.Run(() => BaseModel.Recuperar());
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            int numero = 0;
            if(BaseModel.modelos.OfType<EmailCliente>().ToList().Count > 0)
            numero = BaseModel.modelos.OfType<EmailCliente>().OrderBy(em => em.Id).Last().Id;
            if (EmailCliente.BuscarUltimoId() < numero && condicao)
            {
                condicao = false;
                playSimpleSound();
                notifyIcon1.ShowBalloonTip(2000, "Info", "Uma nova mensagem apareceu!!!. ", ToolTipIcon.Info);
                await Task.Run(() => BuscaEmail("pop.gmail.com", 995, Email, SenhaEmail));
                condicao = true;
            }
            else
            {
                if (condicao)
                {
                    condicao = false;
                    await Task.Run(() => BuscaEmail("pop.gmail.com", 995, Email, SenhaEmail));
                    condicao = true; 
                }
            }
        }

        private void gerenciamentoDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ativar ||
                funcionario != null && funcionario is Admin||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "EnviarEmail")    != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "LerEmail")       != null || 
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "DeletarEmail")   != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarBody")   != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AtualizarEmail") != null)
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
                funcionario is Admin ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AtulizarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "BuscarPessoa") != null ||
                funcionario != null && funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "DeletarPessoa") != null )
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
