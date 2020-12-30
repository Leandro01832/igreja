namespace WFIgrejaLgpd.Formulario.Pessoa
{
    partial class CadastroCrianca
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nome_pai = new System.Windows.Forms.TextBox();
            this.txt_nome_mae = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "nome do pai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "nome da mãe";
            // 
            // txt_nome_pai
            // 
            this.txt_nome_pai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_pai.Location = new System.Drawing.Point(171, 160);
            this.txt_nome_pai.Name = "txt_nome_pai";
            this.txt_nome_pai.Size = new System.Drawing.Size(283, 30);
            this.txt_nome_pai.TabIndex = 3;
            this.txt_nome_pai.TextChanged += new System.EventHandler(this.txt_nome_pai_TextChanged);
            // 
            // txt_nome_mae
            // 
            this.txt_nome_mae.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_mae.Location = new System.Drawing.Point(171, 217);
            this.txt_nome_mae.Name = "txt_nome_mae";
            this.txt_nome_mae.Size = new System.Drawing.Size(283, 30);
            this.txt_nome_mae.TabIndex = 4;
            this.txt_nome_mae.TextChanged += new System.EventHandler(this.txt_nome_mae_TextChanged);
            // 
            // CadastroCrianca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_nome_mae);
            this.Controls.Add(this.txt_nome_pai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CadastroCrianca";
            this.Text = "CadastroCrianca";
            this.Load += new System.EventHandler(this.CadastroCrianca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nome_pai;
        private System.Windows.Forms.TextBox txt_nome_mae;
    }
}