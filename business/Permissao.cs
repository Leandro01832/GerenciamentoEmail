using System.Collections.Generic;

namespace business
{
    public class Permissao : BaseModel
    {
        public string Nome { get; set; }
        public virtual List<PermissaoFuncionario> Funcionarios { get; set; }
    }
}