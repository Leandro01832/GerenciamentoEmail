using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class EmailAdvocacia : Email
    {
        public bool Enviado { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa  { get; set; }
        public Body Body { get; set; }
    }
}
