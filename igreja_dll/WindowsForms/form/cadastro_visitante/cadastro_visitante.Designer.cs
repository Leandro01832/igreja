namespace WindowsForms.form.cadastro_visitante
{
    partial class cadastro_visitante
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
            this.list_condicao = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.mask_visita = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_condicao
            // 
            this.list_condicao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_condicao.FormattingEnabled = true;
            this.list_condicao.ItemHeight = 16;
            this.list_condicao.Items.AddRange(new object[] {
            "católico",
            "evangélico",
            "espirita",
            "outros"});
            this.list_condicao.Location = new System.Drawing.Point(396, 138);
            this.list_condicao.Margin = new System.Windows.Forms.Padding(4);
            this.list_condicao.Name = "list_condicao";
            this.list_condicao.Size = new System.Drawing.Size(159, 68);
            this.list_condicao.TabIndex = 191;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(196, 156);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 25);
            this.label20.TabIndex = 193;
            this.label20.Text = "condição religiosa:";
            // 
            // mask_visita
            // 
            this.mask_visita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mask_visita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_visita.Location = new System.Drawing.Point(396, 68);
            this.mask_visita.Margin = new System.Windows.Forms.Padding(4);
            this.mask_visita.Mask = "00/00/0000";
            this.mask_visita.Name = "mask_visita";
            this.mask_visita.Size = new System.Drawing.Size(129, 29);
            this.mask_visita.TabIndex = 190;
            this.mask_visita.ValidatingType = typeof(System.DateTime);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(235, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 24);
            this.label16.TabIndex = 192;
            this.label16.Text = "data da visita";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(285, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 58);
            this.button1.TabIndex = 194;
            this.button1.Text = "finalizar cadastro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cadastro_visitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_condicao);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.mask_visita);
            this.Controls.Add(this.label16);
            this.Name = "cadastro_visitante";
            this.Text = "cadastro_visitante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cadastro_visitante_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_condicao;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox mask_visita;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
    }
}