namespace WindowsFormsApp1.Formulario.Pessoas
{
    partial class CadastroMembroTransferencia
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
            this.txt_nome_igreja = new System.Windows.Forms.TextBox();
            this.txt_nome_estado = new System.Windows.Forms.TextBox();
            this.txt_nome_cidade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nome da igreja onde estava";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Estado onde estava";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cidade onde estava";
            // 
            // txt_nome_igreja
            // 
            this.txt_nome_igreja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_igreja.Location = new System.Drawing.Point(301, 117);
            this.txt_nome_igreja.Name = "txt_nome_igreja";
            this.txt_nome_igreja.Size = new System.Drawing.Size(230, 30);
            this.txt_nome_igreja.TabIndex = 12;
            this.txt_nome_igreja.TextChanged += new System.EventHandler(this.txt_nome_igreja_TextChanged);
            // 
            // txt_nome_estado
            // 
            this.txt_nome_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_estado.Location = new System.Drawing.Point(301, 193);
            this.txt_nome_estado.Name = "txt_nome_estado";
            this.txt_nome_estado.Size = new System.Drawing.Size(230, 30);
            this.txt_nome_estado.TabIndex = 13;
            this.txt_nome_estado.TextChanged += new System.EventHandler(this.txt_nome_estado_TextChanged);
            // 
            // txt_nome_cidade
            // 
            this.txt_nome_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_cidade.Location = new System.Drawing.Point(301, 285);
            this.txt_nome_cidade.Name = "txt_nome_cidade";
            this.txt_nome_cidade.Size = new System.Drawing.Size(230, 30);
            this.txt_nome_cidade.TabIndex = 14;
            this.txt_nome_cidade.TextChanged += new System.EventHandler(this.txt_nome_cidade_TextChanged);
            // 
            // CadastroMembroTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_nome_cidade);
            this.Controls.Add(this.txt_nome_estado);
            this.Controls.Add(this.txt_nome_igreja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroMembroTransferencia";
            this.Text = "CadastroMembroTransferencia";
            this.Load += new System.EventHandler(this.CadastroMembroTransferencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nome_igreja;
        private System.Windows.Forms.TextBox txt_nome_estado;
        private System.Windows.Forms.TextBox txt_nome_cidade;
    }
}