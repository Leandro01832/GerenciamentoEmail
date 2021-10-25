using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public abstract class Funcionario : Pessoa
    {
        public virtual List<PermissaoFuncionario> Permissao { get; set; }

        private string senha;
        [OpcoesBase(Caracteres = 8, ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        public string Senha
        {
            get
            {
                if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(senha) || senha.Length <= 7)
                    throw new Exception("Senha");
                return senha;
            }
            set { senha = value; }
        }
    }
}
