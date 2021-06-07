namespace WindowsFormsApp1
{
    partial class FormProcessamento
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_processa_pessoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_processa_pessoa
            // 
            this.btn_processa_pessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_processa_pessoa.Location = new System.Drawing.Point(82, 576);
            this.btn_processa_pessoa.Name = "btn_processa_pessoa";
            this.btn_processa_pessoa.Size = new System.Drawing.Size(340, 43);
            this.btn_processa_pessoa.TabIndex = 0;
            this.btn_processa_pessoa.Text = "processar todos os dados de pessoas";
            this.btn_processa_pessoa.UseVisualStyleBackColor = true;
            this.btn_processa_pessoa.Click += new System.EventHandler(this.btn_processa_pessoa_Click);
            // 
            // FormProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 655);
            this.Controls.Add(this.btn_processa_pessoa);
            this.Name = "FormProcessamento";
            this.Text = "FormProcessamento";
            this.Load += new System.EventHandler(this.FormProcessamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_processa_pessoa;
    }
}