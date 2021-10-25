using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoEmail.Models;
using business;
using GerenciamentoEmail.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEmail.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext Banco { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public HomeController(ApplicationDbContext banco, UserManager<IdentityUser> userManager)
        {
            Banco = banco;
            UserManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Email()
        {
            var usuario = await UserManager.GetUserAsync(this.User);

            var user = Banco.Pessoa.OfType<Funcionario>()
                .Include(f => f.Permissao).ThenInclude(f => f.Permissao).FirstOrDefault(f => f.Email == usuario.Email);

            if (user == null || user.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarBody") == null)
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
           await  Banco.EmailAdvocacia.AddAsync(email);
            await Banco.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult Index()
        {
            var email = new EmailAdvocacia();
            return View(email);
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
    }
}
