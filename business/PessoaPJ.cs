using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class PessoaPJ : Pessoa
    {
        public string Cnpj { get; set; }
        public virtual List<Pessoa> Clientes { get; set; }
    }
}
