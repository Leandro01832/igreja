namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    partial class FrmCanalTv
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
            this.txt_nome_canal = new System.Windows.Forms.TextBox();
            this.txt_nome_programa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mask_horario = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do canal";
            // 
            // txt_nome_canal
            // 
            this.txt_nome_canal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_canal.Location = new System.Drawing.Point(225, 128);
            this.txt_nome_canal.Name = "txt_nome_canal";
            this.txt_nome_canal.Size = new System.Drawing.Size(237, 30);
            this.txt_nome_canal.TabIndex = 1;
            this.txt_nome_canal.TextChanged += new System.EventHandler(this.txt_nome_canal_TextChanged);
            // 
            // txt_nome_programa
            // 
            this.txt_nome_programa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_programa.Location = new System.Drawing.Point(225, 196);
            this.txt_nome_programa.Name = "txt_nome_programa";
            this.txt_nome_programa.Size = new System.Drawing.Size(237, 30);
            this.txt_nome_programa.TabIndex = 3;
            this.txt_nome_programa.TextChanged += new System.EventHandler(this.txt_nome_programa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome do programa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Horário do programa";
            // 
            // mask_horario
            // 
            this.mask_horario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario.Location = new System.Drawing.Point(225, 265);
            this.mask_horario.Mask = "00:00";
            this.mask_horario.Name = "mask_horario";
            this.mask_horario.Size = new System.Drawing.Size(100, 30);
            this.mask_horario.TabIndex = 5;
            this.mask_horario.ValidatingType = typeof(System.DateTime);
            this.mask_horario.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_horario_MaskInputRejected);
            this.mask_horario.TextChanged += new System.EventHandler(this.mask_horario_TextChanged);
            // 
            // FrmCadastrarCanalTv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mask_horario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nome_programa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nome_canal);
            this.Controls.Add(this.label1);
            this.Name = "FrmCadastrarCanalTv";
            this.Text = "FrmCadastrarCanalTv";
            this.Load += new System.EventHandler(this.FrmCadastrarCanalTv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nome_canal;
        private System.Windows.Forms.TextBox txt_nome_programa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mask_horario;
    }
}