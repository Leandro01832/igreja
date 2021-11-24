namespace WindowsFormsApp1
{
    partial class FrmEnviaEmail
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.lstEmail = new System.Windows.Forms.ListBox();
            this.wbHtml = new System.Windows.Forms.WebBrowser();
            this.lstCategoria = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApagar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(1261, 627);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(174, 42);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar Email";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(139, 639);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(569, 30);
            this.txtEmail.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Para:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 697);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Assunto:";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssunto.Location = new System.Drawing.Point(139, 692);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(569, 30);
            this.txtAssunto.TabIndex = 4;
            // 
            // lstEmail
            // 
            this.lstEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmail.FormattingEnabled = true;
            this.lstEmail.ItemHeight = 25;
            this.lstEmail.Location = new System.Drawing.Point(12, 12);
            this.lstEmail.Name = "lstEmail";
            this.lstEmail.Size = new System.Drawing.Size(696, 604);
            this.lstEmail.TabIndex = 6;
            this.lstEmail.SelectedValueChanged += new System.EventHandler(this.lstEmail_SelectedValueChanged);
            // 
            // wbHtml
            // 
            this.wbHtml.Location = new System.Drawing.Point(798, 12);
            this.wbHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtml.Name = "wbHtml";
            this.wbHtml.Size = new System.Drawing.Size(967, 604);
            this.wbHtml.TabIndex = 7;
            // 
            // lstCategoria
            // 
            this.lstCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCategoria.FormattingEnabled = true;
            this.lstCategoria.ItemHeight = 25;
            this.lstCategoria.Location = new System.Drawing.Point(895, 627);
            this.lstCategoria.Name = "lstCategoria";
            this.lstCategoria.Size = new System.Drawing.Size(349, 104);
            this.lstCategoria.TabIndex = 8;
            this.lstCategoria.SelectedValueChanged += new System.EventHandler(this.lstCategoria_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(781, 636);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Categoria:";
            // 
            // btnApagar
            // 
            this.btnApagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagar.Location = new System.Drawing.Point(1480, 627);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(174, 42);
            this.btnApagar.TabIndex = 10;
            this.btnApagar.Text = "Apagar Email";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1261, 684);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 42);
            this.button1.TabIndex = 11;
            this.button1.Text = "Atualizar lista de E-mail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmEnviaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 738);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCategoria);
            this.Controls.Add(this.wbHtml);
            this.Controls.Add(this.lstEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnEnviar);
            this.Name = "FrmEnviaEmail";
            this.Text = "FrmEnviaEmail";
            this.Load += new System.EventHandler(this.FrmEnviaEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.ListBox lstEmail;
        private System.Windows.Forms.WebBrowser wbHtml;
        private System.Windows.Forms.ListBox lstCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button button1;
    }
}