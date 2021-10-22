using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public abstract class Pessoa : BaseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public int? PessoaPJId { get; set; }

        public virtual PessoaPJ PessoaPJ { get; set; }

        public virtual List<EmailAdvocacia> EmailAdvocacia { get; set; }
    }
}
