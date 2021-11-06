namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    partial class FrmMudancaEstadoMinisterio
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
            this.lblMudanca = new System.Windows.Forms.Label();
            this.btnMudanca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMudanca
            // 
            this.lblMudanca.AutoSize = true;
            this.lblMudanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMudanca.Location = new System.Drawing.Point(12, 90);
            this.lblMudanca.Name = "lblMudanca";
            this.lblMudanca.Size = new System.Drawing.Size(0, 24);
            this.lblMudanca.TabIndex = 0;
            // 
            // btnMudanca
            // 
            this.btnMudanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMudanca.Location = new System.Drawing.Point(307, 302);
            this.btnMudanca.Name = "btnMudanca";
            this.btnMudanca.Size = new System.Drawing.Size(192, 50);
            this.btnMudanca.TabIndex = 1;
            this.btnMudanca.Text = "Fazer mudança";
            this.btnMudanca.UseVisualStyleBackColor = true;
            this.btnMudanca.Click += new System.EventHandler(this.btnMudanca_Click);
            // 
            // FrmMudancaEstadoMinisterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMudanca);
            this.Controls.Add(this.lblMudanca);
            this.Name = "FrmMudancaEstadoMinisterio";
            this.Text = "FrmMudancaEstadoMinisterio";
            this.Load += new System.EventHandler(this.FrmMudancaEstadoMinisterio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMudanca;
        private System.Windows.Forms.Button btnMudanca;
    }
}