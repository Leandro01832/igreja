namespace WindowsFormsApp1.Formulario.Pessoa
{
    partial class DetalhesMudancaEstado
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
            this.lbl_data_mudanca = new System.Windows.Forms.Label();
            this.lbl_modelo_antigo = new System.Windows.Forms.Label();
            this.lbl_modelo_novo = new System.Windows.Forms.Label();
            this.lbl_id_pessoa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_data_mudanca
            // 
            this.lbl_data_mudanca.AutoSize = true;
            this.lbl_data_mudanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data_mudanca.Location = new System.Drawing.Point(50, 87);
            this.lbl_data_mudanca.Name = "lbl_data_mudanca";
            this.lbl_data_mudanca.Size = new System.Drawing.Size(177, 25);
            this.lbl_data_mudanca.TabIndex = 0;
            this.lbl_data_mudanca.Text = "Data da mudança: ";
            // 
            // lbl_modelo_antigo
            // 
            this.lbl_modelo_antigo.AutoSize = true;
            this.lbl_modelo_antigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelo_antigo.Location = new System.Drawing.Point(50, 151);
            this.lbl_modelo_antigo.Name = "lbl_modelo_antigo";
            this.lbl_modelo_antigo.Size = new System.Drawing.Size(146, 25);
            this.lbl_modelo_antigo.TabIndex = 1;
            this.lbl_modelo_antigo.Text = "Modelo antigo: ";
            // 
            // lbl_modelo_novo
            // 
            this.lbl_modelo_novo.AutoSize = true;
            this.lbl_modelo_novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelo_novo.Location = new System.Drawing.Point(50, 217);
            this.lbl_modelo_novo.Name = "lbl_modelo_novo";
            this.lbl_modelo_novo.Size = new System.Drawing.Size(136, 25);
            this.lbl_modelo_novo.TabIndex = 2;
            this.lbl_modelo_novo.Text = "Modelo novo: ";
            // 
            // lbl_id_pessoa
            // 
            this.lbl_id_pessoa.AutoSize = true;
            this.lbl_id_pessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_pessoa.Location = new System.Drawing.Point(50, 290);
            this.lbl_id_pessoa.Name = "lbl_id_pessoa";
            this.lbl_id_pessoa.Size = new System.Drawing.Size(135, 25);
            this.lbl_id_pessoa.TabIndex = 3;
            this.lbl_id_pessoa.Text = "Id da pessoa: ";
            // 
            // DetalhesMudancaEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_id_pessoa);
            this.Controls.Add(this.lbl_modelo_novo);
            this.Controls.Add(this.lbl_modelo_antigo);
            this.Controls.Add(this.lbl_data_mudanca);
            this.Name = "DetalhesMudancaEstado";
            this.Text = "DetalhesMudancaEstado";
            this.Load += new System.EventHandler(this.DetalhesMudancaEstado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_data_mudanca;
        private System.Windows.Forms.Label lbl_modelo_antigo;
        private System.Windows.Forms.Label lbl_modelo_novo;
        private System.Windows.Forms.Label lbl_id_pessoa;
    }
}