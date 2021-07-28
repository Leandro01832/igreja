namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    partial class ReunioesMinisteriosPessoa
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
            this.txt_reunioes = new System.Windows.Forms.TextBox();
            this.txt_ministerios = new System.Windows.Forms.TextBox();
            this.txt_celula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listareuniao = new System.Windows.Forms.Button();
            this.listaministerios = new System.Windows.Forms.Button();
            this.listacelulas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reuniões da pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ministérios da pessoa";
            // 
            // txt_reunioes
            // 
            this.txt_reunioes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reunioes.Location = new System.Drawing.Point(235, 147);
            this.txt_reunioes.Name = "txt_reunioes";
            this.txt_reunioes.Size = new System.Drawing.Size(296, 30);
            this.txt_reunioes.TabIndex = 2;
            this.txt_reunioes.TextChanged += new System.EventHandler(this.txt_reunioes_TextChanged);
            // 
            // txt_ministerios
            // 
            this.txt_ministerios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ministerios.Location = new System.Drawing.Point(235, 235);
            this.txt_ministerios.Name = "txt_ministerios";
            this.txt_ministerios.Size = new System.Drawing.Size(296, 30);
            this.txt_ministerios.TabIndex = 3;
            this.txt_ministerios.TextChanged += new System.EventHandler(this.txt_ministerios_TextChanged);
            // 
            // txt_celula
            // 
            this.txt_celula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_celula.Location = new System.Drawing.Point(235, 320);
            this.txt_celula.Name = "txt_celula";
            this.txt_celula.Size = new System.Drawing.Size(296, 30);
            this.txt_celula.TabIndex = 5;
            this.txt_celula.TextChanged += new System.EventHandler(this.txt_celula_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Celula da pessoa";
            // 
            // listareuniao
            // 
            this.listareuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listareuniao.Location = new System.Drawing.Point(235, 183);
            this.listareuniao.Name = "listareuniao";
            this.listareuniao.Size = new System.Drawing.Size(233, 37);
            this.listareuniao.TabIndex = 6;
            this.listareuniao.Text = "Abrir lista de Reuniões";
            this.listareuniao.UseVisualStyleBackColor = true;
            this.listareuniao.Click += new System.EventHandler(this.listareuniao_Click);
            // 
            // listaministerios
            // 
            this.listaministerios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaministerios.Location = new System.Drawing.Point(235, 271);
            this.listaministerios.Name = "listaministerios";
            this.listaministerios.Size = new System.Drawing.Size(233, 37);
            this.listaministerios.TabIndex = 7;
            this.listaministerios.Text = "Abrir lista de ministérios";
            this.listaministerios.UseVisualStyleBackColor = true;
            this.listaministerios.Click += new System.EventHandler(this.listaministerios_Click);
            // 
            // listacelulas
            // 
            this.listacelulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listacelulas.Location = new System.Drawing.Point(235, 356);
            this.listacelulas.Name = "listacelulas";
            this.listacelulas.Size = new System.Drawing.Size(233, 37);
            this.listacelulas.TabIndex = 8;
            this.listacelulas.Text = "Abrir lista de Celulas";
            this.listacelulas.UseVisualStyleBackColor = true;
            this.listacelulas.Click += new System.EventHandler(this.listacelulas_Click);
            // 
            // ReunioesMinisteriosPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listacelulas);
            this.Controls.Add(this.listaministerios);
            this.Controls.Add(this.listareuniao);
            this.Controls.Add(this.txt_celula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ministerios);
            this.Controls.Add(this.txt_reunioes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReunioesMinisteriosPessoa";
            this.Text = "ReunioesMinisteriosPessoa";
            this.Load += new System.EventHandler(this.ReunioesMinisteriosPessoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_reunioes;
        private System.Windows.Forms.TextBox txt_ministerios;
        private System.Windows.Forms.TextBox txt_celula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button listareuniao;
        private System.Windows.Forms.Button listaministerios;
        private System.Windows.Forms.Button listacelulas;
    }
}