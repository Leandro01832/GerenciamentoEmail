using business;
using DesktopEmail.Formulario.FormularioPessoa;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DesktopEmail.Formulario
{
    public partial class FrmCrud : Form
    {
        private Label InfoForm;
        private Button deletar;
        private Button atualizar;
        private Button finalizarCadastro;

        private static string addNaListaCelulaMinisterios;

        private bool condicaoDeletar;
        private bool condicaoAtualizar;
        private bool condicaoDetalhes;

        public bool CondicaoDeletar { get => condicaoDeletar; set => condicaoDeletar = value; }
        public bool CondicaoAtualizar { get => condicaoAtualizar; set => condicaoAtualizar = value; }
        public bool CondicaoDetalhes { get => condicaoDetalhes; set => condicaoDetalhes = value; }
        public static string AddNaListaCelulaMinisterios
        { get => addNaListaCelulaMinisterios; set => addNaListaCelulaMinisterios = value; }
        
        public Button Atualizar { get => atualizar; set => atualizar = value; }
        public Button Deletar { get => deletar; set => deletar = value; }
        public Button FinalizaCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }
        public BaseModel Modelo { get; set; }
        
        public FrmCrud()
        {

            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);

            this.FormClosing += FrmCrud_FormClosing;           

            Deletar = new Button();
            Deletar.Click += Deletar_Click;
            Deletar.Text = "Deletar";
            Deletar.Location = new Point(650, 250);
            Deletar.Size = new Size(100, 50);
            Deletar.Visible = false;

            Atualizar = new Button();
            Atualizar.Click += Atualizar_Click;
            Atualizar.Text = "Atualizar";
            Atualizar.Location = new Point(650, 350);
            Atualizar.Size = new Size(100, 50);
            Atualizar.Visible = false;

            FinalizaCadastro = new Button();
            FinalizaCadastro.Click += FinalizaCadastro_Click;
            FinalizaCadastro.Text = "Finalizar Cadastro";
            FinalizaCadastro.Location = new Point(650, 250);
            FinalizaCadastro.Size = new Size(100, 50);
            FinalizaCadastro.Visible = false;
            
            this.Controls.Add(Deletar);
            this.Controls.Add(Atualizar);
            this.Controls.Add(FinalizaCadastro);
            

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);           
        }

        private void FinalizaCadastro_Click(object sender, EventArgs e)
        {
            FinalizaCadastro.Enabled = false;
            if (FormPadrao.ativar || 
                Modelo is Email && FormPadrao.funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "EnviarEmail")    != null ||
                Modelo is Admin)
            {

                try
                {
                    
                    Modelo.Salvar();

                    if(Modelo is Funcionario)
                    {
                        Funcionario func = (Funcionario)Modelo;
                        foreach (var item in func.Permissao)
                            item.FuncionarioId = func.Id;

                        BaseModel.banco.SaveChanges();
                    }
                    BaseModel.modelos.Add(Modelo);
                    MessageBox.Show("cadastro realizado com sucesso!!!");
                    this.Dispose();
                }
                catch (Exception ex) { MessageBox.Show("O cadastro não foi realizado. " + Modelo.MensagemErro(ex)); }
            }
            else
            {
                MessageBox.Show("você não tem permissão!!!");
            }

            FinalizaCadastro.Enabled = true;
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar.Enabled = false;

            if (FormPadrao.ativar ||
                Modelo is Email && FormPadrao.funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "AtualizarEmail") != null ||
                Modelo is Admin )
            {
                Email email = null;
                if (Modelo is Email)
                    email = (Email)Modelo;
                if (Modelo is Email &&
                        FormPadrao.funcionario.Permissao.FirstOrDefault(f => f.Permissao.Nome == email.Categoria.Permissao.Nome) != null ||
                          FormPadrao.ativar ||  FormPadrao.funcionario is Admin)
                {
                    Modelo.Alterar();  
                    MessageBox.Show("Dados atualizados com sucesso!!!");
                }
                else if(!(Modelo is Email))
                {
                    Modelo.Alterar();
                    MessageBox.Show("Dados atualizados com sucesso!!!");
                }
                else
                    MessageBox.Show("Dados atualizados com sucesso!!!");
                   

            }
            else
            {
                MessageBox.Show("você não tem permissão!!!");

            }

            Atualizar.Enabled = true;
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            Deletar.Enabled = false;

            if (FormPadrao.ativar ||
                Modelo is Email && FormPadrao.funcionario.Permissao.FirstOrDefault(p => p.Permissao.Nome == "DeletarEmail") != null ||
                Modelo is Admin)
            {
                Email email = null;
                if (Modelo is Email)
                    email = (Email)Modelo;
                if (Modelo is Email &&
                        FormPadrao.funcionario.Permissao.FirstOrDefault(f => f.Permissao.Nome == email.Categoria.Permissao.Nome) != null ||
                        FormPadrao.ativar ||  FormPadrao.funcionario is Admin)
                {
                    Modelo.Excluir();
                    BaseModel.modelos.Remove(Modelo);
                    MessageBox.Show("Dados apagados com sucesso!!!");
                }
                else if (!(Modelo is Email))
                {
                    Modelo.Excluir();
                    BaseModel.modelos.Remove(Modelo);
                    MessageBox.Show("Dados apagados com sucesso!!!");
                }
                else
                    MessageBox.Show("você não tem permissão!!!");

            }
            else
            {
                MessageBox.Show("você não tem permissão!!!");
            }

            Deletar.Enabled = true;
        }

        private async void FrmCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modelo.Id != 0)
            {
                BaseModel resultado = null;

                var listaTypes = typeof(BaseModel).Assembly.GetTypes()
            .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(BaseModel))).ToList();

                foreach (var item in listaTypes)
                  if(Modelo.GetType() == item)
                  resultado = (BaseModel) Activator.CreateInstance(item);

                resultado = await resultado.Recuperar(Modelo.Id);
                if (resultado != null)
                {
                    BaseModel.modelos.Remove(Modelo);
                    BaseModel.modelos.Add(resultado);
                } 
            }
        }
                    

        private void FrmCrud_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadForm()
        {
            if (this.CondicaoAtualizar || this.CondicaoDeletar || this.CondicaoDetalhes)
            {
                InfoForm.Visible = true;
                FinalizaCadastro.Visible = false;

                if (Modelo is Pessoa)
                {
                    var pessoa = (Pessoa)Modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Id.ToString() +
                    " - " + pessoa.Nome;
                }
                else
                if (Modelo is Permissao)
                {
                    var permissao = (Permissao)Modelo;
                    InfoForm.Text = "Identificação: " + permissao.Id.ToString() +
                        " - " + permissao.Nome;
                }
                else
                if (Modelo is Email)
                {
                    var email = (Email)Modelo;
                    InfoForm.Text = "Identificação: " + email.Id.ToString() +
                    " - " + email.Assunto;
                }

            }

            if (!this.CondicaoAtualizar && !this.CondicaoDeletar && !this.CondicaoDetalhes && this is FrmCrud)
            {
                FinalizaCadastro.Visible = true;
            }

            if (this.CondicaoAtualizar)
                Atualizar.Visible = true;


            if (this.CondicaoDeletar)
                Deletar.Visible = true;

            if (this.CondicaoDetalhes)
            {
                foreach (var item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        var t = (TextBox)item;
                        t.ReadOnly = true;
                    }
                    if (item is MaskedTextBox)
                    {
                        var t = (MaskedTextBox)item;
                        t.ReadOnly = true;
                    }

                    if (item is Button && !(this is FrmAtendente) &&
                        !(this is FrmClientePF) && !(this is FrmClientePJ) &&
                        !(this is FrmAdmin) && !(this is FrmTerceiros))
                    {
                        var t = (Button)item;
                        t.Enabled = false;
                    }
                }
            }
        }
    }
}
