namespace WindowsFormsApp1.Formulario.Reuniao
{
    partial class PessoasReuniao
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
            this.txt_pessoas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_pessoas
            // 
            this.txt_pessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pessoas.Location = new System.Drawing.Point(32, 123);
            this.txt_pessoas.Multiline = true;
            this.txt_pessoas.Name = "txt_pessoas";
            this.txt_pessoas.Size = new System.Drawing.Size(418, 278);
            this.txt_pessoas.TabIndex = 284;
            this.txt_pessoas.TextChanged += new System.EventHandler(this.txt_pessoas_TextChanged);
            this.txt_pessoas.Leave += new System.EventHandler(this.txt_pessoas_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 25);
            this.label5.TabIndex = 283;
            this.label5.Text = "Identificação das pessoas da reuniao";
            // 
            // PessoasReuniao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_pessoas);
            this.Controls.Add(this.label5);
            this.Name = "PessoasReuniao";
            this.Text = "PessoasReuniao";
            this.Load += new System.EventHandler(this.PessoasReuniao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pessoas;
        private System.Windows.Forms.Label label5;
    }
}