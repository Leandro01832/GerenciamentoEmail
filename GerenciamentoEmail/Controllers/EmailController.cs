using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoEmail.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEmail.Controllers
{
    public class EmailController : Controller
    {
        public EmailController(IEmailSender emailSender, IHostingEnvironment hostingEnvironment)
        {
            EmailSender = emailSender;
            HostingEnvironment = hostingEnvironment;
        }

        public IEmailSender EmailSender { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public IActionResult Index()
        {
            return View();
        }


    }
}