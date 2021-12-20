namespace WindowsFormsApp1.Formulario.Celulas
{
    partial class FrmDia_semana
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
            this.txt_nome_celula = new System.Windows.Forms.TextBox();
            this.txt_dia_semana = new System.Windows.Forms.TextBox();
            this.mask_horario = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome da celula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dia da semana para reunião";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Horário para reunião";
            // 
            // txt_nome_celula
            // 
            this.txt_nome_celula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_celula.Location = new System.Drawing.Point(284, 115);
            this.txt_nome_celula.Name = "txt_nome_celula";
            this.txt_nome_celula.Size = new System.Drawing.Size(175, 30);
            this.txt_nome_celula.TabIndex = 3;
            this.txt_nome_celula.TextChanged += new System.EventHandler(this.txt_nome_celula_TextChanged);
            // 
            // txt_dia_semana
            // 
            this.txt_dia_semana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dia_semana.Location = new System.Drawing.Point(284, 179);
            this.txt_dia_semana.Name = "txt_dia_semana";
            this.txt_dia_semana.Size = new System.Drawing.Size(175, 30);
            this.txt_dia_semana.TabIndex = 4;
            this.txt_dia_semana.TextChanged += new System.EventHandler(this.txt_dia_semana_TextChanged);
            // 
            // mask_horario
            // 
            this.mask_horario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario.Location = new System.Drawing.Point(284, 251);
            this.mask_horario.Mask = "00:00";
            this.mask_horario.Name = "mask_horario";
            this.mask_horario.Size = new System.Drawing.Size(158, 30);
            this.mask_horario.TabIndex = 5;
            this.mask_horario.ValidatingType = typeof(System.DateTime);
            this.mask_horario.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_horario_MaskInputRejected);
            this.mask_horario.TextChanged += new System.EventHandler(this.mask_horario_TextChanged);
            // 
            // FrmDia_semana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.mask_horario);
            this.Controls.Add(this.txt_dia_semana);
            this.Controls.Add(this.txt_nome_celula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDia_semana";
            this.Load += new System.EventHandler(this.DadoCelula_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_nome_celula, 0);
            this.Controls.SetChildIndex(this.txt_dia_semana, 0);
            this.Controls.SetChildIndex(this.mask_horario, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nome_celula;
        private System.Windows.Forms.TextBox txt_dia_semana;
        private System.Windows.Forms.MaskedTextBox mask_horario;
    }
}