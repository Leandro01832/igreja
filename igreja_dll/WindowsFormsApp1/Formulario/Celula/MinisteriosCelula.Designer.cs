namespace WindowsFormsApp1.Formulario.Celula
{
    partial class MinisteriosCelula
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
            this.txt_ministerio = new System.Windows.Forms.TextBox();
            this.lbl_pessoas = new System.Windows.Forms.Label();
            this.ListaMinisterios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ministérios";
            // 
            // txt_ministerio
            // 
            this.txt_ministerio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ministerio.Location = new System.Drawing.Point(140, 143);
            this.txt_ministerio.Name = "txt_ministerio";
            this.txt_ministerio.Size = new System.Drawing.Size(262, 30);
            this.txt_ministerio.TabIndex = 1;
            this.txt_ministerio.TextChanged += new System.EventHandler(this.txt_ministerio_TextChanged);
            // 
            // lbl_pessoas
            // 
            this.lbl_pessoas.AutoSize = true;
            this.lbl_pessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pessoas.Location = new System.Drawing.Point(25, 225);
            this.lbl_pessoas.Name = "lbl_pessoas";
            this.lbl_pessoas.Size = new System.Drawing.Size(0, 25);
            this.lbl_pessoas.TabIndex = 3;
            // 
            // ListaMinisterios
            // 
            this.ListaMinisterios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaMinisterios.Location = new System.Drawing.Point(140, 188);
            this.ListaMinisterios.Name = "ListaMinisterios";
            this.ListaMinisterios.Size = new System.Drawing.Size(262, 35);
            this.ListaMinisterios.TabIndex = 4;
            this.ListaMinisterios.Text = "Abrir Lista de Ministérios";
            this.ListaMinisterios.UseVisualStyleBackColor = true;
            this.ListaMinisterios.Click += new System.EventHandler(this.ListaMinisterios_Click);
            // 
            // MinisteriosCelula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListaMinisterios);
            this.Controls.Add(this.lbl_pessoas);
            this.Controls.Add(this.txt_ministerio);
            this.Controls.Add(this.label1);
            this.Name = "MinisteriosCelula";
            this.Text = "MinisteriosCelula";
            this.Load += new System.EventHandler(this.MinisteriosCelula_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ministerio;
        private System.Windows.Forms.Label lbl_pessoas;
        private System.Windows.Forms.Button ListaMinisterios;
    }
}