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
            this.timerProcessamento = new System.Windows.Forms.Timer(this.components);
            this.btn_processa_pessoa = new System.Windows.Forms.Button();
            this.btn_processo_inicial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerProcessamento
            // 
            this.timerProcessamento.Enabled = true;
            this.timerProcessamento.Interval = 30000;
            this.timerProcessamento.Tick += new System.EventHandler(this.timerProcessamento_Tick);
            // 
            // btn_processa_pessoa
            // 
            this.btn_processa_pessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_processa_pessoa.Location = new System.Drawing.Point(455, 557);
            this.btn_processa_pessoa.Name = "btn_processa_pessoa";
            this.btn_processa_pessoa.Size = new System.Drawing.Size(340, 43);
            this.btn_processa_pessoa.TabIndex = 0;
            this.btn_processa_pessoa.Text = "processar todos os dados de pessoas";
            this.btn_processa_pessoa.UseVisualStyleBackColor = true;
            this.btn_processa_pessoa.Click += new System.EventHandler(this.btn_processa_pessoa_Click);
            // 
            // btn_processo_inicial
            // 
            this.btn_processo_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_processo_inicial.Location = new System.Drawing.Point(33, 557);
            this.btn_processo_inicial.Name = "btn_processo_inicial";
            this.btn_processo_inicial.Size = new System.Drawing.Size(340, 43);
            this.btn_processo_inicial.TabIndex = 1;
            this.btn_processo_inicial.Text = "processamento inicial";
            this.btn_processo_inicial.UseVisualStyleBackColor = true;
            this.btn_processo_inicial.Click += new System.EventHandler(this.btn_processo_inicial_Click);
            // 
            // FormProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 655);
            this.Controls.Add(this.btn_processo_inicial);
            this.Controls.Add(this.btn_processa_pessoa);
            this.Name = "FormProcessamento";
            this.Text = "FormProcessamento";
            this.Load += new System.EventHandler(this.FormProcessamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerProcessamento;
        private System.Windows.Forms.Button btn_processa_pessoa;
        private System.Windows.Forms.Button btn_processo_inicial;
    }
}