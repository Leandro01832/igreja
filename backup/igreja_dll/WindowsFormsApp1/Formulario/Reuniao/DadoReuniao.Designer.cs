namespace WindowsFormsApp1.Formulario.Reuniao
{
    partial class DadoReuniao
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
            this.mask_data_reuniao = new System.Windows.Forms.MaskedTextBox();
            this.mask_horario_inicio = new System.Windows.Forms.MaskedTextBox();
            this.mask_horario_final = new System.Windows.Forms.MaskedTextBox();
            this.txt_local_reuniao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mask_data_reuniao
            // 
            this.mask_data_reuniao.BeepOnError = true;
            this.mask_data_reuniao.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_reuniao.Location = new System.Drawing.Point(262, 204);
            this.mask_data_reuniao.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_reuniao.Mask = "00/00/0000";
            this.mask_data_reuniao.Name = "mask_data_reuniao";
            this.mask_data_reuniao.RejectInputOnFirstFailure = true;
            this.mask_data_reuniao.Size = new System.Drawing.Size(196, 29);
            this.mask_data_reuniao.TabIndex = 273;
            this.mask_data_reuniao.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_reuniao.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_data_reuniao_MaskInputRejected);
            this.mask_data_reuniao.TextChanged += new System.EventHandler(this.mask_data_reuniao_TextChanged);
            // 
            // mask_horario_inicio
            // 
            this.mask_horario_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario_inicio.Location = new System.Drawing.Point(262, 275);
            this.mask_horario_inicio.Mask = "00:00";
            this.mask_horario_inicio.Name = "mask_horario_inicio";
            this.mask_horario_inicio.Size = new System.Drawing.Size(158, 30);
            this.mask_horario_inicio.TabIndex = 274;
            this.mask_horario_inicio.ValidatingType = typeof(System.DateTime);
            this.mask_horario_inicio.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_horario_inicio_MaskInputRejected);
            this.mask_horario_inicio.TextChanged += new System.EventHandler(this.mask_horario_inicio_TextChanged);
            // 
            // mask_horario_final
            // 
            this.mask_horario_final.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario_final.Location = new System.Drawing.Point(262, 348);
            this.mask_horario_final.Mask = "00:00";
            this.mask_horario_final.Name = "mask_horario_final";
            this.mask_horario_final.Size = new System.Drawing.Size(158, 30);
            this.mask_horario_final.TabIndex = 275;
            this.mask_horario_final.ValidatingType = typeof(System.DateTime);
            this.mask_horario_final.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_horario_final_MaskInputRejected);
            this.mask_horario_final.TextChanged += new System.EventHandler(this.mask_horario_final_TextChanged);
            // 
            // txt_local_reuniao
            // 
            this.txt_local_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_local_reuniao.Location = new System.Drawing.Point(262, 134);
            this.txt_local_reuniao.Name = "txt_local_reuniao";
            this.txt_local_reuniao.Size = new System.Drawing.Size(196, 30);
            this.txt_local_reuniao.TabIndex = 276;
            this.txt_local_reuniao.TextChanged += new System.EventHandler(this.txt_local_reuniao_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 277;
            this.label1.Text = "Local da reunião";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 278;
            this.label2.Text = "data da reunião";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 279;
            this.label3.Text = "horário de inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 280;
            this.label4.Text = "horário final";
            // 
            // DadoReuniao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_local_reuniao);
            this.Controls.Add(this.mask_horario_final);
            this.Controls.Add(this.mask_horario_inicio);
            this.Controls.Add(this.mask_data_reuniao);
            this.Name = "DadoReuniao";
            this.Text = "Reuniao";
            this.Load += new System.EventHandler(this.Reuniao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mask_data_reuniao;
        private System.Windows.Forms.MaskedTextBox mask_horario_inicio;
        private System.Windows.Forms.MaskedTextBox mask_horario_final;
        private System.Windows.Forms.TextBox txt_local_reuniao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}