﻿using business;
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
    public partial class FrmEmailAdvocacia : FrmCrud
    {
        public FrmEmailAdvocacia()
        {
            InitializeComponent();
        }

        public FrmEmailAdvocacia(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {

        }

        private void FrmEmailAdvocacia_Load(object sender, EventArgs e)
        {

        }
    }
}