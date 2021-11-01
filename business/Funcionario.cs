using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace business
{
   public abstract class Funcionario : Pessoa
    {
        public virtual List<PermissaoFuncionario> Permissao { get; set; }

        private string senha;
        [OpcoesBase(Caracteres = 8, ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo é necessário!!!")]
        public string Senha { get; set; }
    }
}
