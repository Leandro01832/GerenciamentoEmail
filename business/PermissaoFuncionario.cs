using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class PermissaoFuncionario
    {
        public int PermissaoId { get; set; }
        public Permissao Permissao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
