using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace business
{
   public abstract class Pessoa : BaseModel
    {
        private string nome;
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo é necessário!!!")]
        public string Nome { get; set; }

        private string email;
        [OpcoesBase(ChaveEstrangeira =false, ChavePrimaria =false, Index =true, Obrigatorio =true)]
        [Required(ErrorMessage ="Este campo é necessário!!!")]
        public string Email { get; set; }

        public int? PessoaPJId { get; set; }

        public virtual PessoaPJ PessoaPJ { get; set; }

        public virtual List<EmailAdvocacia> EmailAdvocacia { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Nome;
        }
    }
}
