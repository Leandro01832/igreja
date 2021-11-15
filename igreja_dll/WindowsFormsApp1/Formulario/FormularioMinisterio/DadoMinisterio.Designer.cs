namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    partial class DadoMinisterio
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nome_ministerio = new System.Windows.Forms.TextBox();
            this.txt_proposito = new System.Windows.Forms.TextBox();
            this.txt_ministro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do ministério";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proposito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ministro";
            // 
            // txt_nome_ministerio
            // 
            this.txt_nome_ministerio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_ministerio.Location = new System.Drawing.Point(222, 225);
            this.txt_nome_ministerio.Name = "txt_nome_ministerio";
            this.txt_nome_ministerio.Size = new System.Drawing.Size(203, 30);
            this.txt_nome_ministerio.TabIndex = 3;
            this.txt_nome_ministerio.TextChanged += new System.EventHandler(this.txt_nome_ministerio_TextChanged);
            // 
            // txt_proposito
            // 
            this.txt_proposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_proposito.Location = new System.Drawing.Point(222, 300);
            this.txt_proposito.Name = "txt_proposito";
            this.txt_proposito.Size = new System.Drawing.Size(203, 30);
            this.txt_proposito.TabIndex = 4;
            this.txt_proposito.TextChanged += new System.EventHandler(this.txt_proposito_TextChanged);
            // 
            // txt_ministro
            // 
            this.txt_ministro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ministro.Location = new System.Drawing.Point(222, 371);
            this.txt_ministro.Name = "txt_ministro";
            this.txt_ministro.Size = new System.Drawing.Size(203, 30);
            this.txt_ministro.TabIndex = 5;
            this.txt_ministro.TextChanged += new System.EventHandler(this.txt_ministro_TextChanged);
            // 
            // DadoMinisterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 711);
            this.Controls.Add(this.txt_ministro);
            this.Controls.Add(this.txt_proposito);
            this.Controls.Add(this.txt_nome_ministerio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DadoMinisterio";
            this.Text = "DadoMinisterio";
            this.Load += new System.EventHandler(this.DadoMinisterio_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_nome_ministerio, 0);
            this.Controls.SetChildIndex(this.txt_proposito, 0);
            this.Controls.SetChildIndex(this.txt_ministro, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nome_ministerio;
        private System.Windows.Forms.TextBox txt_proposito;
        private System.Windows.Forms.TextBox txt_ministro;
    }
}