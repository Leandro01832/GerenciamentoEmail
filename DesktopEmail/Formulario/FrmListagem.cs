using business;
using DesktopEmail.Formulario.FormularioEmail;
using DesktopEmail.Formulario.FormularioPessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmListagem : Form
    {
        FrmCrud result;
        FrmCrud fc = new FrmPermissao();
        FrmCrud fc2 = new FrmEmailAdvocacia();
        FrmCrud fc3 = new FrmAdmin();
        ObjectHandle handle;
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        private Button botaoAtualizarLista { get; }

        public Type Tipo { get; }

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

        public FrmListagem(List<BaseModel> lista)
        {
            if (lista.Count > 0)
                lstListagem.DataSource = lista;

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

        private async void BotaoAtualizarLista_Click(object sender, EventArgs e)
        {
            BaseModel.modelos = new List<BaseModel>();
            await BaseModel.Recuperar();
            CarregarListagem();
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(true, false, false);
        }

        private void BotaoAtualizar_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(false, true, false);
        }

        private void BotaoDeletar_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(false, false, true);
        }



        private void FrmListagem_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            if (Tipo != null)
            {
                if (Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)))
                {
                    if (Tipo.IsSubclassOf(typeof(Pessoa)))
                        lstListagem.DataSource = BaseModel.modelos.Where(m => m.GetType() == Tipo).ToList();
                    else
                        lstListagem.DataSource = BaseModel.modelos.OfType<Pessoa>().ToList();
                }

                if (Tipo == typeof(Permissao))
                    lstListagem.DataSource = BaseModel.modelos.OfType<Permissao>().ToList();

                if (Tipo == typeof(Categoria))
                    lstListagem.DataSource = BaseModel.modelos.OfType<Categoria>().ToList();

                if (Tipo == typeof(Email) || Tipo.IsSubclassOf(typeof(Email)))
                {
                    if (Tipo.IsSubclassOf(typeof(Email)))
                        lstListagem.DataSource = BaseModel.modelos.Where(m => m.GetType() == Tipo).ToList();
                    else
                        lstListagem.DataSource = BaseModel.modelos.OfType<Email>().ToList();
                }
            }
        }

        private void AbrirFrmCrud(bool detalhes, bool atualizar, bool deletar)
        {
            try
            {
                if (FormPadrao.funcionario is Admin || FormPadrao.ativar)
                {
                    var listaTypes = typeof(BaseModel).Assembly.GetTypes()
                    .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(BaseModel))).ToList();

                    foreach (var item in listaTypes)
                        if (lstListagem.SelectedItem.GetType() == item && item.IsSubclassOf(typeof(Pessoa)))
                            handle = Activator.CreateInstance(null, fc3.GetType().FullName.Replace(fc3.GetType().Name, "Frm" + item.Name));
                        else if (lstListagem.SelectedItem.GetType() == item && item.IsSubclassOf(typeof(Email)))
                            handle = Activator.CreateInstance(null, fc2.GetType().FullName.Replace(fc2.GetType().Name, "Frm" + item.Name));
                        else if (lstListagem.SelectedItem.GetType() == item)
                            handle = Activator.CreateInstance(null, fc.GetType().FullName.Replace(fc.GetType().Name, "Frm" + item.Name));

                    result = (FrmCrud)handle.Unwrap();

                    result.Modelo = (BaseModel)lstListagem.SelectedItem;
                    result.CondicaoDetalhes = detalhes;
                    result.CondicaoDeletar = deletar;
                    result.CondicaoAtualizar = atualizar;
                    result.MdiParent = this.MdiParent;
                    result.Show();
                }
                else
                {
                    MessageBox.Show("Você não tem permissão!!!");
                }
            }
            catch { }
        }
    }
}
