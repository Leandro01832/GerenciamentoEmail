using business;
using GerenciamentoEmail.Data;
using GerenciamentoEmail.Models;
using GerenciamentoEmail.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GerenciamentoEmail.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext Banco { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IConfiguration Configuration { get; }
        public IEmailSender EmailSender { get; }

        public HomeController(ApplicationDbContext banco, UserManager<IdentityUser> userManager,
            IConfiguration configuration, IEmailSender emailSender)
        {
            Banco = banco;
            UserManager = userManager;
            Configuration = configuration;
            EmailSender = emailSender;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CLienteEmail(EmailCliente email)
        {
            var usuario = await UserManager.GetUserAsync(this.User);

            MailMessage mail = new MailMessage(Configuration.GetConnectionString("From"),
                Configuration.GetConnectionString("To"));

            mail.Subject = email.Assunto;
            mail.Body = email.Body + " - " + usuario.UserName;

            try
            {
                await EmailSender.SendEmailAsync(
                            null,
                            mail.Subject,
                            mail.Body);
                
            }
            catch (Exception)
            {
                View("NaoEnviado");
            }

            ViewBag.message = "Seu email foi enviado com sucesso!!! Obrigado.";
            var e_mail = new EmailCliente();
            return View("Index", e_mail);
        }

        [Authorize]
        public async Task<IActionResult> Email()
        {
            var usuario = await UserManager.GetUserAsync(this.User);

            var user = Banco.Pessoa.OfType<Funcionario>()
                .Include(f => f.Permissao).ThenInclude(f => f.Permissao).FirstOrDefault(f => f.Email == usuario.Email);

            if (user == null ||
                user.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarBody") == null && user is Atendente)
                return View("NoPermission");

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.AddRange(Banco.PessoaPF.ToList());
            pessoas.AddRange(Banco.PessoaPJ.ToList());
            pessoas.AddRange(Banco.Terceiros.ToList());
            pessoas.AddRange(Banco.Admin.ToList());
            pessoas.AddRange(Banco.Atendente.ToList());
            ViewBag.PessoaId = new SelectList(pessoas, "Id", "Nome");
            EmailAdvocacia email = new EmailAdvocacia();
            email.Data = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            email.MensagemId = "";
            return View(email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Email(EmailAdvocacia email)
        {
            await Banco.EmailAdvocacia.AddAsync(email);
            await Banco.SaveChangesAsync();
            ViewBag.message = "Corpo de email cadastrado com sucesso.";

            Random rd = new Random();
            var mail = new EmailCliente();
            mail.MensagemId = "";
            mail.Data = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            mail.ConteudoTexto = "";
            sortear(rd, mail);
            return View("Index", mail);
        }

        public IActionResult Index()
        {
            Random rd = new Random();
            var email = new EmailCliente();
            email.MensagemId = "";
            email.Data = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            email.ConteudoTexto = "";
            sortear(rd, email);

            return View(email);
        }

        private void sortear(Random rd, EmailCliente email)
        {
            if(Banco.Atendente.ToList().Count > 0)
            email.AtendenteId = rd.Next(0, Banco.Atendente.OrderBy(a => a.Id).Last().Id);
            if(Banco.Atendente.ToList().Count > 0)
            if (Banco.Atendente.FirstOrDefault(at => at.Id == email.AtendenteId) == null)
                sortear(rd, email);
        }

        public IActionResult NaoEnviado()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


     //   static async Task RunAsync()
     //   {
     //       MailjetClient client =
     //       new MailjetClient(Environment.GetEnvironmentVariable("518af4665ebbb902ca070750015358c3"),
     //       Environment.GetEnvironmentVariable("e973e78ba28a098e6c41d8d410f02ff3"));

     //       MailjetRequest request = new MailjetRequest
     //       {
     //           Resource = Send.Resource,
     //       }
     //        .Property(Send.Messages, new JArray {
     //new JObject {
     // {
     //  "From",
     //  new JObject {
     //   {"Email", "leandro91luis@gmail.com"},
     //   {"Name", "Leandro luis"}
     //  }
     // }, {
     //  "To",
     //  new JArray {
     //   new JObject {
     //    {
     //     "Email",
     //     "leandro91luis@gmail.com"
     //    }, {
     //     "Name",
     //     "Leandro luis"
     //    }
     //   }
     //  }
     // }, {
     //  "Subject",
     //  "Greetings from Mailjet."
     // }, {
     //  "TextPart",
     //  "My first Mailjet email"
     // }, {
     //  "HTMLPart",
     //  "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
     // }, {
     //  "CustomID",
     //  "AppGettingStartedTest"
     // }
     //}
     //        });
     //       MailjetResponse response = await client.PostAsync(request);
     //       if (response.IsSuccessStatusCode)
     //       {
     //           Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
     //           Console.WriteLine(response.GetData());
     //       }
     //       else
     //       {
     //           Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
     //           Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
     //           Console.WriteLine(response.GetData());
     //           Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
     //       }
     //   }

    }
}
