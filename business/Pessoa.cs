using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace business
{
   public abstract class Pessoa : BaseModel
    {
        private string nome;
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        public string Nome
        {
            get
            {
                if ( string.IsNullOrWhiteSpace(nome) ||  string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
                return nome;
            }
            set { nome = value; }
        }

        private string email;
        [OpcoesBase(ChaveEstrangeira =false, ChavePrimaria =false, Index =true, Obrigatorio =true)]
        public string Email
        {
            get
            {
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!rg.IsMatch(email))
                    throw new Exception("Email");
                
                return email;
            }
            set { email = value; }
        }

        public int? PessoaPJId { get; set; }

        public virtual PessoaPJ PessoaPJ { get; set; }

        public virtual List<EmailAdvocacia> EmailAdvocacia { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Nome;
        }
    }
}
