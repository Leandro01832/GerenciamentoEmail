using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public abstract class Funcionario : Pessoa
    {
        public virtual List<PermissaoFuncionario> Permissao { get; set; }

        public string Senha { get; set; }
    }
}
