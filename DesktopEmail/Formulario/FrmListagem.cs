using business;
using DesktopEmail.Formulario.FormularioEmail;
using DesktopEmail.Formulario.FormularioPessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmListagem : Form
    {
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        private Button botaoAtualizarLista { get; }

        bool atualizar = true;

        public FrmListagem()
        {
            InitializeComponent();
        }

        public FrmListagem(Type tipo)
        {
            Tipo = tipo;

            botaoDeletar = new Button();
            botaoDeletar.Location = new Point(570, 120);
            botaoDeletar.Size = new Size(100, 50);
            botaoDeletar.Text = "Excluir";
            botaoDeletar.Click += BotaoDeletar_Click;
            botaoDeletar.Dock = DockStyle.Right;

            botaoAtualizar = new Button();
            botaoAtualizar.Location = new Point(570, 200);
            botaoAtualizar.Size = new Size(100, 50);
            botaoAtualizar.Text = "Atualizar";
            botaoAtualizar.Click += BotaoAtualizar_Click;
            botaoAtualizar.Dock = DockStyle.Right;

            botaoDetalhes = new Button();
            botaoDetalhes.Location = new Point(570, 280);
            botaoDetalhes.Size = new Size(100, 50);
            botaoDetalhes.Text = "Detalhes";
            botaoDetalhes.Click += BotaoDetalhes_Click;
            botaoDetalhes.Dock = DockStyle.Right;

            botaoAtualizarLista = new Button();
            botaoAtualizarLista.Location = new Point(570, 360);
            botaoAtualizarLista.Size = new Size(100, 50);
            botaoAtualizarLista.Text = "Atualizar lista";
            botaoAtualizarLista.Click += BotaoAtualizarLista_Click;
            botaoAtualizarLista.Dock = DockStyle.Right;

            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;

            Controls.Add(botaoDetalhes);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDeletar);
            Controls.Add(botaoAtualizarLista);
            InitializeComponent();
        }

        private void BotaoAtualizarLista_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            FrmCrud fc = null;
                try
                {
                    if(lstListagem.SelectedItem is PessoaPF      ) fc = new FrmClientePF     ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is PessoaPJ      ) fc = new FrmClientePJ     ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is Terceiros     ) fc = new FrmTerceiros     ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is Admin         ) fc = new FrmAdmin         ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is Atendente     ) fc = new FrmAtendente     ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is EmailAdvocacia) fc = new FrmEmailAdvocacia((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is EmailCliente  ) fc = new FrmEmailCliente  ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    if(lstListagem.SelectedItem is Permissao     ) fc = new FrmPermissao     ((BaseModel)lstListagem.SelectedItem, false, false, true);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch { }
        }

        private void BotaoAtualizar_Click(object sender, EventArgs e)
        {
            FrmCrud fc = null;
                try
                {
                    if(lstListagem.SelectedItem is PessoaPF      ) fc = new FrmClientePF     ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is PessoaPJ      ) fc = new FrmClientePJ     ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is Terceiros     ) fc = new FrmTerceiros     ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is Admin         ) fc = new FrmAdmin         ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is Atendente     ) fc = new FrmAtendente     ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is EmailAdvocacia) fc = new FrmEmailAdvocacia((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is EmailCliente  ) fc = new FrmEmailCliente  ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    if(lstListagem.SelectedItem is Permissao     ) fc = new FrmPermissao     ((BaseModel)lstListagem.SelectedItem, false, true, false);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch { }
        }

        private void BotaoDeletar_Click(object sender, EventArgs e)
        {
            FrmCrud fc = null;
                try
                {
                    if(lstListagem.SelectedItem is PessoaPF      ) fc = new FrmClientePF     ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is PessoaPJ      ) fc = new FrmClientePJ     ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is Terceiros     ) fc = new FrmTerceiros     ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is Admin         ) fc = new FrmAdmin         ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is Atendente     ) fc = new FrmAtendente     ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is EmailAdvocacia) fc = new FrmEmailAdvocacia((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is EmailCliente  ) fc = new FrmEmailCliente  ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    if(lstListagem.SelectedItem is Permissao     ) fc = new FrmPermissao     ((BaseModel)lstListagem.SelectedItem, true, false, false);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch { }
        }

        public Type Tipo { get; }

        private void FrmListagem_Load(object sender, EventArgs e)
        {
            if(Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                if (Tipo.IsSubclassOf(typeof(Pessoa)))
                    lstListagem.DataSource = BaseModel.modelos.Where(m => m.GetType() == Tipo).ToList();
                else
                    lstListagem.DataSource = BaseModel.modelos.OfType<Pessoa>().ToList();
            }

            if(Tipo == typeof(Permissao))
                lstListagem.DataSource = BaseModel.modelos.OfType<Permissao>().ToList();

            if(Tipo == typeof(Email) || Tipo.IsSubclassOf(typeof(Email)))
            {
                if (Tipo.IsSubclassOf(typeof(Email)))
                    lstListagem.DataSource = BaseModel.modelos.Where(m => m.GetType() == Tipo).ToList();
                else
                    lstListagem.DataSource = BaseModel.modelos.OfType<Email>().ToList();
            }
        }
    }
}
