using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public abstract class Email : BaseModel
    {
        public string Categoria { get; set; }
        public string MensagemId { get; set; }
        private string assunto;
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        public string Assunto
        {
            get
            {
                if(BaseModel.Desktop)
                if (string.IsNullOrWhiteSpace(assunto) || string.IsNullOrWhiteSpace(assunto))
                    throw new Exception("Assunto");
                return assunto;
            }
            set { assunto = value; }
        }

        private DateTime data;
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        public DateTime Data
        {
            get
            {
                if (data.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data");
                return data;
            }
            set { data = value; }
        }
        

        public override string ToString()
        {
            return this.Id + " - " + Data.ToString("dd/MM/yyyy");
        }
    }
}
