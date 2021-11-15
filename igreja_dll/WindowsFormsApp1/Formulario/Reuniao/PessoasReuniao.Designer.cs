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
            this.label5 = new System.Windows.Forms.Label();
            this.lstBoxPessoa = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 283;
            this.label5.Text = "Pessoas:";
            // 
            // lstBoxPessoa
            // 
            this.lstBoxPessoa.FormattingEnabled = true;
            this.lstBoxPessoa.ItemHeight = 16;
            this.lstBoxPessoa.Location = new System.Drawing.Point(136, 37);
            this.lstBoxPessoa.Name = "lstBoxPessoa";
            this.lstBoxPessoa.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxPessoa.Size = new System.Drawing.Size(346, 388);
            this.lstBoxPessoa.TabIndex = 284;
            this.lstBoxPessoa.SelectedValueChanged += new System.EventHandler(this.lstBoxPessoa_SelectedValueChanged);
            // 
            // PessoasReuniao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstBoxPessoa);
            this.Controls.Add(this.label5);
            this.Name = "PessoasReuniao";
            this.Text = "PessoasReuniao";
            this.Load += new System.EventHandler(this.PessoasReuniao_Load);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lstBoxPessoa, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstBoxPessoa;
    }
}