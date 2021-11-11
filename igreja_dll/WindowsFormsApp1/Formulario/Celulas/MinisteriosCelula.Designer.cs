namespace WindowsFormsApp1.Formulario.Celulas
{
    partial class MinisteriosCelula
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
            this.lstBoxMinisterio = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ministérios";
            // 
            // lstBoxMinisterio
            // 
            this.lstBoxMinisterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxMinisterio.FormattingEnabled = true;
            this.lstBoxMinisterio.ItemHeight = 25;
            this.lstBoxMinisterio.Location = new System.Drawing.Point(134, 48);
            this.lstBoxMinisterio.Name = "lstBoxMinisterio";
            this.lstBoxMinisterio.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxMinisterio.Size = new System.Drawing.Size(303, 354);
            this.lstBoxMinisterio.TabIndex = 4;
            this.lstBoxMinisterio.SelectedValueChanged += new System.EventHandler(this.lstBoxMinisterio_SelectedValueChanged);
            // 
            // MinisteriosCelula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstBoxMinisterio);
            this.Controls.Add(this.label1);
            this.Name = "MinisteriosCelula";
            this.Text = "MinisteriosCelula";
            this.Load += new System.EventHandler(this.MinisteriosCelula_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxMinisterio;
    }
}