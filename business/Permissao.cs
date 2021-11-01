using System.Collections.Generic;

namespace business
{
    public class Permissao : BaseModel
    {
        public string Nome { get; set; }
        public virtual List<PermissaoFuncionario> Funcionarios { get; set; }

        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Nome;
        }
    }
}