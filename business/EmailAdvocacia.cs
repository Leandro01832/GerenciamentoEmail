using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class EmailAdvocacia : Email
    {
        public static string EndEmailAdvocacia = "leandro91luis@gmail.com";

        public static string SenhaAdvocacia = "Gasparzinho2020";

        public bool Enviado { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa  { get; set; }
        public Body Body { get; set; }
    }
}
