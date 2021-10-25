using business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEmail.Formulario.FormularioEmail
{
    public partial class FrmEmailCliente : FrmCrud
    {
        public FrmEmailCliente()
        {
            InitializeComponent();
        }

        public FrmEmailCliente(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {

        }

        private void FrmEmailCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
