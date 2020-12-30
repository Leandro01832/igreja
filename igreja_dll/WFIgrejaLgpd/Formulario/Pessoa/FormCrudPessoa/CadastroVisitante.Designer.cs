namespace WFIgrejaLgpd.Formulario.Pessoa
{
    partial class CadastroVisitante
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
            this.mask_data_visita = new System.Windows.Forms.MaskedTextBox();
            this.txt_condicao_religiosa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data da visita";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Condição religiosa";
            // 
            // mask_data_visita
            // 
            this.mask_data_visita.BeepOnError = true;
            this.mask_data_visita.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_visita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_visita.Location = new System.Drawing.Point(216, 160);
            this.mask_data_visita.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_visita.Mask = "00/00/0000";
            this.mask_data_visita.Name = "mask_data_visita";
            this.mask_data_visita.RejectInputOnFirstFailure = true;
            this.mask_data_visita.Size = new System.Drawing.Size(196, 29);
            this.mask_data_visita.TabIndex = 272;
            this.mask_data_visita.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_visita.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_data_visita_MaskInputRejected);
            this.mask_data_visita.TextChanged += new System.EventHandler(this.mask_data_visita_TextChanged);
            // 
            // txt_condicao_religiosa
            // 
            this.txt_condicao_religiosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_condicao_religiosa.Location = new System.Drawing.Point(216, 224);
            this.txt_condicao_religiosa.Name = "txt_condicao_religiosa";
            this.txt_condicao_religiosa.Size = new System.Drawing.Size(196, 30);
            this.txt_condicao_religiosa.TabIndex = 273;
            this.txt_condicao_religiosa.TextChanged += new System.EventHandler(this.txt_condicao_religiosa_TextChanged);
            // 
            // CadastroVisitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_condicao_religiosa);
            this.Controls.Add(this.mask_data_visita);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroVisitante";
            this.Text = "CadastroVisitante";
            this.Load += new System.EventHandler(this.CadastroVisitante_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mask_data_visita;
        private System.Windows.Forms.TextBox txt_condicao_religiosa;
    }
}