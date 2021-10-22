namespace DesktopEmail.Formulario
{
    partial class FrmEnviaEmail
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
            BaiqiSoft.HtmlEditorControl.FormatHtmlOptions formatHtmlOptions1 = new BaiqiSoft.HtmlEditorControl.FormatHtmlOptions();
            this.mstHtmlEditor1 = new BaiqiSoft.HtmlEditorControl.MstHtmlEditor();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mstHtmlEditor1
            // 
            formatHtmlOptions1.BreakBeforeBR = true;
            formatHtmlOptions1.ClosingSingleTags = true;
            formatHtmlOptions1.IndentHtmlTags = true;
            formatHtmlOptions1.IndentScript = true;
            formatHtmlOptions1.IndentSpaces = 4;
            formatHtmlOptions1.IndentWithTabs = false;
            formatHtmlOptions1.LowercaseTags = true;
            formatHtmlOptions1.QuoteAttributeValues = true;
            this.mstHtmlEditor1.FormatHtmlOptions = formatHtmlOptions1;
            this.mstHtmlEditor1.LanguageConfig = null;
            this.mstHtmlEditor1.Location = new System.Drawing.Point(10, 11);
            this.mstHtmlEditor1.Name = "mstHtmlEditor1";
            this.mstHtmlEditor1.SelectionLength = 0;
            this.mstHtmlEditor1.SelectionStart = 0;
            this.mstHtmlEditor1.Size = new System.Drawing.Size(1322, 605);
            this.mstHtmlEditor1.TabIndex = 0;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(801, 631);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(174, 42);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar Email";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(197, 643);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(569, 30);
            this.txtEmail.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email:";
            // 
            // FrmEnviaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 691);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.mstHtmlEditor1);
            this.Name = "FrmEnviaEmail";
            this.Text = "FrmEnviaEmail";
            this.Load += new System.EventHandler(this.FrmEnviaEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaiqiSoft.HtmlEditorControl.MstHtmlEditor mstHtmlEditor1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
    }
}