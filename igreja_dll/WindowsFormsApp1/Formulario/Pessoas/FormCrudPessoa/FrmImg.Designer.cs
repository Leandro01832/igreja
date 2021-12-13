namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    partial class FrmImg
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
            this.ptrb_foto = new System.Windows.Forms.PictureBox();
            this.btn_foto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptrb_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrb_foto
            // 
            this.ptrb_foto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptrb_foto.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptrb_foto.Location = new System.Drawing.Point(0, 0);
            this.ptrb_foto.Name = "ptrb_foto";
            this.ptrb_foto.Size = new System.Drawing.Size(720, 737);
            this.ptrb_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrb_foto.TabIndex = 0;
            this.ptrb_foto.TabStop = false;
            // 
            // btn_foto
            // 
            this.btn_foto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_foto.Location = new System.Drawing.Point(1145, 606);
            this.btn_foto.Name = "btn_foto";
            this.btn_foto.Size = new System.Drawing.Size(166, 86);
            this.btn_foto.TabIndex = 1;
            this.btn_foto.Text = "Escolher foto";
            this.btn_foto.UseVisualStyleBackColor = true;
            this.btn_foto.Click += new System.EventHandler(this.btn_foto_Click);
            // 
            // Foto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 737);
            this.Controls.Add(this.btn_foto);
            this.Controls.Add(this.ptrb_foto);
            this.Name = "Foto";
            this.Text = "Foto";
            this.Load += new System.EventHandler(this.Foto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptrb_foto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptrb_foto;
        private System.Windows.Forms.Button btn_foto;
    }
}