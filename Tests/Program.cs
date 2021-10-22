using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            BuscaEmail("pop.gmail.com", 995, "leandro91luis@gmail.com", "Gasparzinho2020");

            Console.WriteLine("OK!");
            Console.Read();
        }

        static void BuscaEmail(string nome_servidor_pop, int porta, string email, string senha)
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

                // Faz a leitura de todos os emails mais recentes da caixa de entrada,
                // iniciando a partir do último email recebido.
                for (int i = 0; i < numero_emails; i++)
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
                        

                        // Imprime as informações do email
                        Console.WriteLine("Id: " + Id);
                        Console.WriteLine("De: " + emailDe);
                        Console.WriteLine("Para: " + emailPara);
                        Console.WriteLine("Assunto: " + assunto);
                        Console.WriteLine("Data de Envio: " + data_envio);
                        Console.WriteLine("Conteudo Html: " + mailHtml);
                        Console.WriteLine("Conteudo Texto: " + mailText);
                        Console.WriteLine("".PadLeft(30, '-'));

                        // Decrementa o número de emails
                        numero_emails--;
                    }
                }
            }
        }
    }
}
