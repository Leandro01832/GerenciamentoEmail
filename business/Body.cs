using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business
{
    public class Body : BaseModel
    {
        [Key, ForeignKey("EmailAdvocacia")]
        public new int Id { get; set; }
        public string Html { get; set; }
        public EmailAdvocacia EmailAdvocacia { get; set; }
    }
}