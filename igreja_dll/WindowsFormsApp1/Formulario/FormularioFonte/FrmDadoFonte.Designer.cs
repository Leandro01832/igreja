namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    partial class FrmDadoFonte
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoxMensagem = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mensagem";
            // 
            // lstBoxMensagem
            // 
            this.lstBoxMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxMensagem.FormattingEnabled = true;
            this.lstBoxMensagem.ItemHeight = 25;
            this.lstBoxMensagem.Location = new System.Drawing.Point(128, 47);
            this.lstBoxMensagem.Name = "lstBoxMensagem";
            this.lstBoxMensagem.Size = new System.Drawing.Size(320, 354);
            this.lstBoxMensagem.TabIndex = 1;
            this.lstBoxMensagem.SelectedValueChanged += new System.EventHandler(this.lstBoxMensagem_SelectedValueChanged);
            // 
            // FrmDadoFonte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstBoxMensagem);
            this.Controls.Add(this.label1);
            this.Name = "FrmDadoFonte";
            this.Text = "FrmDadoFonte";
            this.Load += new System.EventHandler(this.FrmDadoFonte_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lstBoxMensagem, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxMensagem;
    }
}