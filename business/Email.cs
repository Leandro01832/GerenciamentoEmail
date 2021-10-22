using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public abstract class Email : BaseModel
    {
        public string MensagemId { get; set; }        
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return this.Assunto + " - " + Data.ToString("dd/MM/yyyy");
        }
    }
}
