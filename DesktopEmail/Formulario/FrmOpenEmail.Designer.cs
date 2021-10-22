namespace DesktopEmail.Formulario
{
    partial class FrmOpenEmail
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
            this.lblDe = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.lstBoxEmail = new System.Windows.Forms.ListBox();
            this.web = new System.Windows.Forms.WebBrowser();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(878, 15);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(43, 25);
            this.lblDe.TabIndex = 0;
            this.lblDe.Text = "De:";
            // 
            // txtDe
            // 
            this.txtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDe.Location = new System.Drawing.Point(927, 12);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(557, 30);
            this.txtDe.TabIndex = 1;
            // 
            // lstBoxEmail
            // 
            this.lstBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxEmail.FormattingEnabled = true;
            this.lstBoxEmail.ItemHeight = 25;
            this.lstBoxEmail.Location = new System.Drawing.Point(12, 71);
            this.lstBoxEmail.Name = "lstBoxEmail";
            this.lstBoxEmail.Size = new System.Drawing.Size(835, 629);
            this.lstBoxEmail.TabIndex = 2;
            this.lstBoxEmail.SelectedIndexChanged += new System.EventHandler(this.lstBoxEmail_SelectedIndexChanged);
            this.lstBoxEmail.SelectedValueChanged += new System.EventHandler(this.lstBoxEmail_SelectedValueChanged);
            // 
            // web
            // 
            this.web.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.web.Location = new System.Drawing.Point(867, 124);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(918, 572);
            this.web.TabIndex = 3;
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(1599, 10);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(137, 30);
            this.txtData.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1519, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data:";
            // 
            // FrmOpenEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 767);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.web);
            this.Controls.Add(this.lstBoxEmail);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.lblDe);
            this.Name = "FrmOpenEmail";
            this.Text = "FrmOpenEmail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOpenEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.ListBox lstBoxEmail;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
    }
}