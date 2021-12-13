namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    partial class CadastroMembroReconciliacao
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
            this.txt_reconciliacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data da Reconciliação";
            // 
            // txt_reconciliacao
            // 
            this.txt_reconciliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reconciliacao.Location = new System.Drawing.Point(277, 157);
            this.txt_reconciliacao.Name = "txt_reconciliacao";
            this.txt_reconciliacao.Size = new System.Drawing.Size(178, 30);
            this.txt_reconciliacao.TabIndex = 10;
            this.txt_reconciliacao.TextChanged += new System.EventHandler(this.txt_reconciliacao_TextChanged);
            // 
            // CadastroMembroReconciliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 349);
            this.Controls.Add(this.txt_reconciliacao);
            this.Controls.Add(this.label1);
            this.Name = "CadastroMembroReconciliacao";
            this.Text = "CadastroMembroReconciliacao";
            this.Load += new System.EventHandler(this.CadastroMembroReconciliacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_reconciliacao;
    }
}