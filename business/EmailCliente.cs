using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace business
{
   public class EmailCliente : Email
    {
        public string Remetente { get; set; }
        public string Categoria { get; set; }
        public string ConteudoTexto { get; set; }
        public int? AtendenteId { get; set; }
        public virtual Atendente Atendente { get; set; }

        public static int TotalRegistro()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            
                try
                {
                    var stringConexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database-Email;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM EmailCliente", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    
                }
            
            return _TotalRegistros;
        }
    }
}
