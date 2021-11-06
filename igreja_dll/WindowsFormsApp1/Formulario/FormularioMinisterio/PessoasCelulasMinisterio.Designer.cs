namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    partial class PessoasCelulasMinisterio
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
            this.txt_celulas = new System.Windows.Forms.TextBox();
            this.txt_pessoas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listapessoas = new System.Windows.Forms.Button();
            this.listacelulas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_celulas
            // 
            this.txt_celulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_celulas.Location = new System.Drawing.Point(252, 250);
            this.txt_celulas.Name = "txt_celulas";
            this.txt_celulas.Size = new System.Drawing.Size(236, 30);
            this.txt_celulas.TabIndex = 7;
            this.txt_celulas.TextChanged += new System.EventHandler(this.txt_celulas_TextChanged);
            // 
            // txt_pessoas
            // 
            this.txt_pessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pessoas.Location = new System.Drawing.Point(252, 143);
            this.txt_pessoas.Name = "txt_pessoas";
            this.txt_pessoas.Size = new System.Drawing.Size(227, 30);
            this.txt_pessoas.TabIndex = 6;
            this.txt_pessoas.TextChanged += new System.EventHandler(this.txt_pessoas_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Celulas do ministério";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pessoas do ministério";
            // 
            // listapessoas
            // 
            this.listapessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listapessoas.Location = new System.Drawing.Point(252, 179);
            this.listapessoas.Name = "listapessoas";
            this.listapessoas.Size = new System.Drawing.Size(227, 42);
            this.listapessoas.TabIndex = 8;
            this.listapessoas.Text = "Abrir lista de pessoas";
            this.listapessoas.UseVisualStyleBackColor = true;
            this.listapessoas.Click += new System.EventHandler(this.listapessoas_Click);
            // 
            // listacelulas
            // 
            this.listacelulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listacelulas.Location = new System.Drawing.Point(252, 295);
            this.listacelulas.Name = "listacelulas";
            this.listacelulas.Size = new System.Drawing.Size(227, 42);
            this.listacelulas.TabIndex = 9;
            this.listacelulas.Text = "Abrir lista de celulas";
            this.listacelulas.UseVisualStyleBackColor = true;
            this.listacelulas.Click += new System.EventHandler(this.listacelulas_Click);
            // 
            // PessoasCelulasMinisterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 477);
            this.Controls.Add(this.listacelulas);
            this.Controls.Add(this.listapessoas);
            this.Controls.Add(this.txt_celulas);
            this.Controls.Add(this.txt_pessoas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PessoasCelulasMinisterio";
            this.Text = "PessoasCelulasMinisterio";
            this.Load += new System.EventHandler(this.PessoasCelulasMinisterio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_celulas;
        private System.Windows.Forms.TextBox txt_pessoas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listapessoas;
        private System.Windows.Forms.Button listacelulas;
    }
}