namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    partial class FrmVersiculo
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
            this.txt_texto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_livro = new System.Windows.Forms.ComboBox();
            this.combo_capitulo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_versiculo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_texto
            // 
            this.txt_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_texto.Location = new System.Drawing.Point(151, 292);
            this.txt_texto.Multiline = true;
            this.txt_texto.Name = "txt_texto";
            this.txt_texto.Size = new System.Drawing.Size(637, 429);
            this.txt_texto.TabIndex = 3;
            this.txt_texto.TextChanged += new System.EventHandler(this.txt_texto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Texto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Livro";
            // 
            // combo_livro
            // 
            this.combo_livro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_livro.FormattingEnabled = true;
            this.combo_livro.Location = new System.Drawing.Point(151, 93);
            this.combo_livro.Name = "combo_livro";
            this.combo_livro.Size = new System.Drawing.Size(243, 33);
            this.combo_livro.TabIndex = 7;
            this.combo_livro.SelectedIndexChanged += new System.EventHandler(this.combo_livro_SelectedIndexChanged);
            // 
            // combo_capitulo
            // 
            this.combo_capitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_capitulo.FormattingEnabled = true;
            this.combo_capitulo.Location = new System.Drawing.Point(151, 151);
            this.combo_capitulo.Name = "combo_capitulo";
            this.combo_capitulo.Size = new System.Drawing.Size(243, 33);
            this.combo_capitulo.TabIndex = 9;
            this.combo_capitulo.SelectedIndexChanged += new System.EventHandler(this.combo_capitulo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capitulo";
            // 
            // combo_versiculo
            // 
            this.combo_versiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_versiculo.FormattingEnabled = true;
            this.combo_versiculo.Location = new System.Drawing.Point(151, 222);
            this.combo_versiculo.Name = "combo_versiculo";
            this.combo_versiculo.Size = new System.Drawing.Size(243, 33);
            this.combo_versiculo.TabIndex = 11;
            this.combo_versiculo.SelectedIndexChanged += new System.EventHandler(this.combo_versiculo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Versiculo";
            // 
            // FrmCadastrarVersiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 733);
            this.Controls.Add(this.combo_versiculo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_capitulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_livro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_texto);
            this.Controls.Add(this.label2);
            this.Name = "FrmCadastrarVersiculo";
            this.Text = "FrmCadastrarVersiculo";
            this.Load += new System.EventHandler(this.FrmCadastrarVersiculo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_texto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_livro;
        private System.Windows.Forms.ComboBox combo_capitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_versiculo;
        private System.Windows.Forms.Label label1;
    }
}