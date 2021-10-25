using business;
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
    public partial class MDIFormulario : Form
    {
        private int childFormNumber = 0;

        public MDIFormulario()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin form = new FrmAdmin(new Admin(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void atendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAtendente form = new FrmAtendente(new Atendente(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void clientePFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientePF form = new FrmClientePF(new PessoaPF(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void clientePJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientePJ form = new FrmClientePJ(new PessoaPJ(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void terceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmTerceiros form = new FrmTerceiros(new Terceiros(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmPermissao form = new FrmPermissao(new Permissao(), false, false, false);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListagem form = new FrmListagem(typeof(Admin));
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmListagem form = new FrmListagem(typeof(Atendente));
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmListagem form = new FrmListagem(typeof(PessoaPF));
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmListagem form = new FrmListagem(typeof(PessoaPJ));
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmListagem form = new FrmListagem(typeof(Terceiros));
            form.MdiParent = this;
            form.Show();
        }
    }
}
