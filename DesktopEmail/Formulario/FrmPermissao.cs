using business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmPermissao : FrmCrud
    {
        Button AtendentesCategoria;
        Button EmailCategoria;
        public FrmPermissao() : base()
        {
            AtendentesCategoria = new Button();
            AtendentesCategoria.Click += AtendentesCategoria_Click;
            AtendentesCategoria.Text = "Atendentes desta categoria";
            AtendentesCategoria.Location = new Point(350, 150);
            AtendentesCategoria.Size = new Size(250, 50);
            AtendentesCategoria.Visible = false;

            EmailCategoria = new Button();
            EmailCategoria.Click += EmailCategoria_Click;     
            EmailCategoria.Text = "E-mails desta categoria";
            EmailCategoria.Location = new Point(350, 150);
            EmailCategoria.Size = new Size(250, 50);
            EmailCategoria.Visible = false;

            InitializeComponent();
        }

        private void EmailCategoria_Click(object sender, EventArgs e)
        {
            var lista = new List<Funcionario>();
            var Permissao = (Permissao)Modelo;
            FrmListagem form = new FrmListagem(Permissao.Categoria.Email.Cast<BaseModel>().ToList());
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void AtendentesCategoria_Click(object sender, EventArgs e)
        {
            var lista = new List<Funcionario>();
            var Permissao = (Permissao)Modelo;
            foreach (var item in Permissao.Funcionarios)
                lista.Add(item.Funcionario);
            FrmListagem form = new FrmListagem(lista.Cast<BaseModel>().ToList());
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var Permissao = (Permissao)Modelo;
            Permissao.Nome = txtNome.Text;
        }

        private void FrmPermissao_Load(object sender, EventArgs e)
        {
            LoadForm();
            var Permissao = (Permissao)Modelo;
            if (Permissao.Id != 0)
            {
                txtNome.Text = Permissao.Nome;

                if(Permissao.Categoria != null)
                {
                    AtendentesCategoria.Visible = true;
                    AtendentesCategoria.Enabled = true;
                    EmailCategoria.Visible = true;
                    EmailCategoria.Enabled = true;
                }
                else
                {
                    AtendentesCategoria.Visible = false;
                    AtendentesCategoria.Enabled = false;
                    EmailCategoria.Visible = false;
                    EmailCategoria.Enabled = false;
                }
            }
            else
                Permissao.Categoria = new Categoria();

        }
    }
}
