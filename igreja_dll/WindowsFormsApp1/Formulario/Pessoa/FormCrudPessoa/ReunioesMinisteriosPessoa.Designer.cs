namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    partial class ReunioesMinisteriosPessoa
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
            this.label3 = new System.Windows.Forms.Label();
            this.lstBoxMinisterio = new System.Windows.Forms.ListBox();
            this.lstBoxCelula = new System.Windows.Forms.ListBox();
            this.lstBoxReuniao = new System.Windows.Forms.ListBox();
            this.ckBoxNulo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(704, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reuniões da pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ministérios da pessoa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Celula da pessoa";
            // 
            // lstBoxMinisterio
            // 
            this.lstBoxMinisterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxMinisterio.FormattingEnabled = true;
            this.lstBoxMinisterio.ItemHeight = 25;
            this.lstBoxMinisterio.Location = new System.Drawing.Point(16, 137);
            this.lstBoxMinisterio.Name = "lstBoxMinisterio";
            this.lstBoxMinisterio.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxMinisterio.Size = new System.Drawing.Size(306, 329);
            this.lstBoxMinisterio.TabIndex = 5;
            this.lstBoxMinisterio.SelectedValueChanged += new System.EventHandler(this.lstBoxMinisterio_SelectedValueChanged);
            // 
            // lstBoxCelula
            // 
            this.lstBoxCelula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxCelula.FormattingEnabled = true;
            this.lstBoxCelula.ItemHeight = 25;
            this.lstBoxCelula.Location = new System.Drawing.Point(358, 137);
            this.lstBoxCelula.Name = "lstBoxCelula";
            this.lstBoxCelula.Size = new System.Drawing.Size(315, 329);
            this.lstBoxCelula.TabIndex = 6;
            this.lstBoxCelula.SelectedValueChanged += new System.EventHandler(this.lstBoxCelula_SelectedValueChanged);
            // 
            // lstBoxReuniao
            // 
            this.lstBoxReuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxReuniao.FormattingEnabled = true;
            this.lstBoxReuniao.ItemHeight = 25;
            this.lstBoxReuniao.Location = new System.Drawing.Point(709, 137);
            this.lstBoxReuniao.Name = "lstBoxReuniao";
            this.lstBoxReuniao.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxReuniao.Size = new System.Drawing.Size(338, 329);
            this.lstBoxReuniao.TabIndex = 7;
            this.lstBoxReuniao.SelectedValueChanged += new System.EventHandler(this.lstBoxReuniao_SelectedValueChanged);
            // 
            // ckBoxNulo
            // 
            this.ckBoxNulo.AutoSize = true;
            this.ckBoxNulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBoxNulo.Location = new System.Drawing.Point(358, 93);
            this.ckBoxNulo.Name = "ckBoxNulo";
            this.ckBoxNulo.Size = new System.Drawing.Size(188, 29);
            this.ckBoxNulo.TabIndex = 20;
            this.ckBoxNulo.Text = "Não possui celula";
            this.ckBoxNulo.UseVisualStyleBackColor = true;
            this.ckBoxNulo.CheckedChanged += new System.EventHandler(this.ckBoxNulo_CheckedChanged);
            // 
            // ReunioesMinisteriosPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 493);
            this.Controls.Add(this.ckBoxNulo);
            this.Controls.Add(this.lstBoxReuniao);
            this.Controls.Add(this.lstBoxCelula);
            this.Controls.Add(this.lstBoxMinisterio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReunioesMinisteriosPessoa";
            this.Text = "ReunioesMinisteriosPessoa";
            this.Load += new System.EventHandler(this.ReunioesMinisteriosPessoa_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lstBoxMinisterio, 0);
            this.Controls.SetChildIndex(this.lstBoxCelula, 0);
            this.Controls.SetChildIndex(this.lstBoxReuniao, 0);
            this.Controls.SetChildIndex(this.ckBoxNulo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxMinisterio;
        private System.Windows.Forms.ListBox lstBoxCelula;
        private System.Windows.Forms.ListBox lstBoxReuniao;
        private System.Windows.Forms.CheckBox ckBoxNulo;
    }
}