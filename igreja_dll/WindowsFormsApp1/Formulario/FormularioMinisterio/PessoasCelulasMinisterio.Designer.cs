namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    partial class PessoasCelulasMinisterio
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoxPessoa = new System.Windows.Forms.ListBox();
            this.lstBoxCelula = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Celulas do ministério";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pessoas do ministério";
            // 
            // lstBoxPessoa
            // 
            this.lstBoxPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxPessoa.FormattingEnabled = true;
            this.lstBoxPessoa.ItemHeight = 25;
            this.lstBoxPessoa.Location = new System.Drawing.Point(12, 77);
            this.lstBoxPessoa.Name = "lstBoxPessoa";
            this.lstBoxPessoa.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxPessoa.Size = new System.Drawing.Size(339, 354);
            this.lstBoxPessoa.TabIndex = 6;
            this.lstBoxPessoa.SelectedValueChanged += new System.EventHandler(this.lstBoxPessoa_SelectedValueChanged);
            // 
            // lstBoxCelula
            // 
            this.lstBoxCelula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxCelula.FormattingEnabled = true;
            this.lstBoxCelula.ItemHeight = 25;
            this.lstBoxCelula.Location = new System.Drawing.Point(369, 77);
            this.lstBoxCelula.Name = "lstBoxCelula";
            this.lstBoxCelula.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxCelula.Size = new System.Drawing.Size(338, 354);
            this.lstBoxCelula.TabIndex = 7;
            this.lstBoxCelula.SelectedValueChanged += new System.EventHandler(this.lstBoxCelula_SelectedValueChanged);
            // 
            // PessoasCelulasMinisterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 477);
            this.Controls.Add(this.lstBoxCelula);
            this.Controls.Add(this.lstBoxPessoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PessoasCelulasMinisterio";
            this.Text = "PessoasCelulasMinisterio";
            this.Load += new System.EventHandler(this.PessoasCelulasMinisterio_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lstBoxPessoa, 0);
            this.Controls.SetChildIndex(this.lstBoxCelula, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxPessoa;
        private System.Windows.Forms.ListBox lstBoxCelula;
    }
}