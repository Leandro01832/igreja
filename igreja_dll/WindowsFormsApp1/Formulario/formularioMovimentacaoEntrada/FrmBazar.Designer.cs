namespace WindowsFormsApp1.formulario.formularioMovimentacaoEntrada
{
    partial class FrmBazar
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
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxPagou = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mask_data_recebimento = new System.Windows.Forms.MaskedTextBox();
            this.txt_numero_id = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 25);
            this.label3.TabIndex = 286;
            this.label3.Text = "Nº de identificação do comprador:";
            // 
            // checkBoxPagou
            // 
            this.checkBoxPagou.AutoSize = true;
            this.checkBoxPagou.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPagou.Location = new System.Drawing.Point(257, 151);
            this.checkBoxPagou.Name = "checkBoxPagou";
            this.checkBoxPagou.Size = new System.Drawing.Size(91, 29);
            this.checkBoxPagou.TabIndex = 285;
            this.checkBoxPagou.Text = "Pagou";
            this.checkBoxPagou.UseVisualStyleBackColor = true;
            this.checkBoxPagou.CheckedChanged += new System.EventHandler(this.checkBoxPagou_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 284;
            this.label1.Text = "Data de recebimento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 283;
            this.label2.Text = "Valor:";
            // 
            // mask_data_recebimento
            // 
            this.mask_data_recebimento.BeepOnError = true;
            this.mask_data_recebimento.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_recebimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_recebimento.Location = new System.Drawing.Point(257, 232);
            this.mask_data_recebimento.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_recebimento.Mask = "00/00/0000";
            this.mask_data_recebimento.Name = "mask_data_recebimento";
            this.mask_data_recebimento.RejectInputOnFirstFailure = true;
            this.mask_data_recebimento.Size = new System.Drawing.Size(132, 29);
            this.mask_data_recebimento.TabIndex = 281;
            this.mask_data_recebimento.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_recebimento.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_data_recebimento_MaskInputRejected);
            // 
            // txt_numero_id
            // 
            this.txt_numero_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numero_id.Location = new System.Drawing.Point(326, 332);
            this.txt_numero_id.Name = "txt_numero_id";
            this.txt_numero_id.Size = new System.Drawing.Size(172, 30);
            this.txt_numero_id.TabIndex = 289;
            this.txt_numero_id.TextChanged += new System.EventHandler(this.txt_numero_id_TextChanged);
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(257, 69);
            this.txtValor.MaxLength = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(128, 30);
            this.txtValor.TabIndex = 290;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // FrmBazar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txt_numero_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxPagou);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mask_data_recebimento);
            this.Controls.Add(this.label1);
            this.Name = "FrmBazar";
            this.Text = "FrmCadastrarBazar";
            this.Load += new System.EventHandler(this.FrmCadastrarBazar_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.mask_data_recebimento, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBoxPagou, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_numero_id, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPagou;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mask_data_recebimento;
        private System.Windows.Forms.TextBox txt_numero_id;
        private System.Windows.Forms.TextBox txtValor;
    }
}