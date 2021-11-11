namespace WindowsFormsApp1.Formulario.FormularioEmail
{
    partial class FrmOpenEmail
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
            this.lblDe = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.lstBoxEmail = new System.Windows.Forms.ListBox();
            this.web = new System.Windows.Forms.WebBrowser();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCategoria = new System.Windows.Forms.ListBox();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBoxAtendente = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(878, 15);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(43, 25);
            this.lblDe.TabIndex = 0;
            this.lblDe.Text = "De:";
            // 
            // txtDe
            // 
            this.txtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDe.Location = new System.Drawing.Point(927, 12);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(557, 30);
            this.txtDe.TabIndex = 1;
            // 
            // lstBoxEmail
            // 
            this.lstBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxEmail.FormattingEnabled = true;
            this.lstBoxEmail.ItemHeight = 25;
            this.lstBoxEmail.Location = new System.Drawing.Point(12, 21);
            this.lstBoxEmail.Name = "lstBoxEmail";
            this.lstBoxEmail.Size = new System.Drawing.Size(835, 629);
            this.lstBoxEmail.TabIndex = 2;
            this.lstBoxEmail.SelectedIndexChanged += new System.EventHandler(this.lstBoxEmail_SelectedIndexChanged);
            this.lstBoxEmail.SelectedValueChanged += new System.EventHandler(this.lstBoxEmail_SelectedValueChanged);
            // 
            // web
            // 
            this.web.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.web.Location = new System.Drawing.Point(867, 78);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(918, 572);
            this.web.TabIndex = 3;
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(1599, 10);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(137, 30);
            this.txtData.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1519, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data:";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(1371, 664);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(113, 43);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(857, 673);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Categoria:";
            // 
            // lstCategoria
            // 
            this.lstCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCategoria.FormattingEnabled = true;
            this.lstCategoria.ItemHeight = 25;
            this.lstCategoria.Location = new System.Drawing.Point(966, 662);
            this.lstCategoria.Name = "lstCategoria";
            this.lstCategoria.Size = new System.Drawing.Size(349, 104);
            this.lstCategoria.TabIndex = 10;
            this.lstCategoria.SelectedValueChanged += new System.EventHandler(this.lstCategoria_SelectedValueChanged);
            // 
            // btnApagar
            // 
            this.btnApagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagar.Location = new System.Drawing.Point(1573, 664);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(113, 43);
            this.btnApagar.TabIndex = 12;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualiza.Location = new System.Drawing.Point(1371, 724);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(271, 42);
            this.btnAtualiza.TabIndex = 13;
            this.btnAtualiza.Text = "Atualizar lista de E-mail";
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 673);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Atendente:";
            // 
            // lstBoxAtendente
            // 
            this.lstBoxAtendente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxAtendente.FormattingEnabled = true;
            this.lstBoxAtendente.ItemHeight = 25;
            this.lstBoxAtendente.Location = new System.Drawing.Point(477, 664);
            this.lstBoxAtendente.Name = "lstBoxAtendente";
            this.lstBoxAtendente.Size = new System.Drawing.Size(349, 104);
            this.lstBoxAtendente.TabIndex = 15;
            this.lstBoxAtendente.SelectedValueChanged += new System.EventHandler(this.lstBoxAtendente_SelectedValueChanged);
            // 
            // FrmOpenEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 778);
            this.Controls.Add(this.lstBoxAtendente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAtualiza);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCategoria);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.web);
            this.Controls.Add(this.lstBoxEmail);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.lblDe);
            this.Name = "FrmOpenEmail";
            this.Text = "FrmOpenEmail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOpenEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.ListBox lstBoxEmail;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstCategoria;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstBoxAtendente;
    }
}