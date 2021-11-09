namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    partial class FrmFontes
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
            this.lbl_fontes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_fontes
            // 
            this.lbl_fontes.AutoSize = true;
            this.lbl_fontes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fontes.Location = new System.Drawing.Point(16, 98);
            this.lbl_fontes.Name = "lbl_fontes";
            this.lbl_fontes.Size = new System.Drawing.Size(0, 25);
            this.lbl_fontes.TabIndex = 0;
            // 
            // FrmFontes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_fontes);
            this.Name = "FrmFontes";
            this.Text = "FrmFontes";
            this.Load += new System.EventHandler(this.FrmFontes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_fontes;
    }
}