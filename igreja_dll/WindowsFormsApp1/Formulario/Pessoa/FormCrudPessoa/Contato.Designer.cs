namespace WindowsFormsApp1.Formulario.Pessoas
{
    partial class Contato
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
            this.label19 = new System.Windows.Forms.Label();
            this.mask_tel3 = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.mask_tel2 = new System.Windows.Forms.MaskedTextBox();
            this.mask_tel1 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(22, 272);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 25);
            this.label19.TabIndex = 230;
            this.label19.Text = "whatsapp";
            // 
            // mask_tel3
            // 
            this.mask_tel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_tel3.Location = new System.Drawing.Point(178, 268);
            this.mask_tel3.Margin = new System.Windows.Forms.Padding(4);
            this.mask_tel3.Mask = "(999) 00000-0000";
            this.mask_tel3.Name = "mask_tel3";
            this.mask_tel3.Size = new System.Drawing.Size(259, 29);
            this.mask_tel3.TabIndex = 229;
            this.mask_tel3.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_tel3_MaskInputRejected);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(34, 196);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 25);
            this.label18.TabIndex = 228;
            this.label18.Text = "celular";
            // 
            // mask_tel2
            // 
            this.mask_tel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_tel2.Location = new System.Drawing.Point(176, 192);
            this.mask_tel2.Margin = new System.Windows.Forms.Padding(4);
            this.mask_tel2.Mask = "(999) 00000-0000";
            this.mask_tel2.Name = "mask_tel2";
            this.mask_tel2.Size = new System.Drawing.Size(259, 29);
            this.mask_tel2.TabIndex = 227;
            this.mask_tel2.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_tel2_MaskInputRejected);
            // 
            // mask_tel1
            // 
            this.mask_tel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_tel1.Location = new System.Drawing.Point(176, 118);
            this.mask_tel1.Margin = new System.Windows.Forms.Padding(4);
            this.mask_tel1.Mask = "(999) 0000-0000";
            this.mask_tel1.Name = "mask_tel1";
            this.mask_tel1.Size = new System.Drawing.Size(259, 29);
            this.mask_tel1.TabIndex = 225;
            this.mask_tel1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_tel1_MaskInputRejected);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 123);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 25);
            this.label10.TabIndex = 226;
            this.label10.Text = "telefone";
            // 
            // Contato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mask_tel3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.mask_tel2);
            this.Controls.Add(this.mask_tel1);
            this.Controls.Add(this.label10);
            this.Name = "Contato";
            this.Text = "Contato";
            this.Load += new System.EventHandler(this.Contato_Load);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.mask_tel1, 0);
            this.Controls.SetChildIndex(this.mask_tel2, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.mask_tel3, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox mask_tel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox mask_tel2;
        private System.Windows.Forms.MaskedTextBox mask_tel1;
        private System.Windows.Forms.Label label10;
    }
}