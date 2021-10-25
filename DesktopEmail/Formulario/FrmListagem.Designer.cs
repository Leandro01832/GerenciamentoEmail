namespace DesktopEmail.Formulario
{
    partial class FrmListagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstListagem = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstListagem
            // 
            this.lstListagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstListagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListagem.FormattingEnabled = true;
            this.lstListagem.ItemHeight = 25;
            this.lstListagem.Location = new System.Drawing.Point(0, 0);
            this.lstListagem.Name = "lstListagem";
            this.lstListagem.Size = new System.Drawing.Size(356, 450);
            this.lstListagem.TabIndex = 0;
            // 
            // FrmListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstListagem);
            this.Name = "FrmListagem";
            this.Text = "FrmListagem";
            this.Load += new System.EventHandler(this.FrmListagem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstListagem;
    }
}