using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class Atendente : Funcionario
    {
        public virtual List<EmailCliente> EmailCliente { get; set; }
    }
}
