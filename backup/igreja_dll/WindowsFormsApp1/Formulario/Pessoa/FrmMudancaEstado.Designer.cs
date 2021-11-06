namespace WindowsFormsApp1.Formulario.Pessoa
{
    partial class FrmMudancaEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMudancaEstado));
            this.label1 = new System.Windows.Forms.Label();
            this.radio_membrobatismo = new System.Windows.Forms.RadioButton();
            this.radio_membroreconciliacao = new System.Windows.Forms.RadioButton();
            this.radio_membroaclamacao = new System.Windows.Forms.RadioButton();
            this.radio_membrotransferencia = new System.Windows.Forms.RadioButton();
            this.radio_visitante = new System.Windows.Forms.RadioButton();
            this.radio_crianca = new System.Windows.Forms.RadioButton();
            this.btn_proximo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha a nova classe:";
            // 
            // radio_membrobatismo
            // 
            this.radio_membrobatismo.AutoSize = true;
            this.radio_membrobatismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_membrobatismo.Location = new System.Drawing.Point(36, 140);
            this.radio_membrobatismo.Name = "radio_membrobatismo";
            this.radio_membrobatismo.Size = new System.Drawing.Size(211, 29);
            this.radio_membrobatismo.TabIndex = 1;
            this.radio_membrobatismo.TabStop = true;
            this.radio_membrobatismo.Text = "Membro por batismo";
            this.radio_membrobatismo.UseVisualStyleBackColor = true;
            this.radio_membrobatismo.CheckedChanged += new System.EventHandler(this.radio_membrobatismo_CheckedChanged);
            // 
            // radio_membroreconciliacao
            // 
            this.radio_membroreconciliacao.AutoSize = true;
            this.radio_membroreconciliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_membroreconciliacao.Location = new System.Drawing.Point(36, 255);
            this.radio_membroreconciliacao.Name = "radio_membroreconciliacao";
            this.radio_membroreconciliacao.Size = new System.Drawing.Size(257, 29);
            this.radio_membroreconciliacao.TabIndex = 2;
            this.radio_membroreconciliacao.TabStop = true;
            this.radio_membroreconciliacao.Text = "Membro por reconciliação";
            this.radio_membroreconciliacao.UseVisualStyleBackColor = true;
            this.radio_membroreconciliacao.CheckedChanged += new System.EventHandler(this.radio_membroreconciliacao_CheckedChanged);
            // 
            // radio_membroaclamacao
            // 
            this.radio_membroaclamacao.AutoSize = true;
            this.radio_membroaclamacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_membroaclamacao.Location = new System.Drawing.Point(36, 193);
            this.radio_membroaclamacao.Name = "radio_membroaclamacao";
            this.radio_membroaclamacao.Size = new System.Drawing.Size(241, 29);
            this.radio_membroaclamacao.TabIndex = 3;
            this.radio_membroaclamacao.TabStop = true;
            this.radio_membroaclamacao.Text = "Membro por Aclamação";
            this.radio_membroaclamacao.UseVisualStyleBackColor = true;
            this.radio_membroaclamacao.CheckedChanged += new System.EventHandler(this.radio_membroaclamacao_CheckedChanged);
            // 
            // radio_membrotransferencia
            // 
            this.radio_membrotransferencia.AutoSize = true;
            this.radio_membrotransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_membrotransferencia.Location = new System.Drawing.Point(301, 140);
            this.radio_membrotransferencia.Name = "radio_membrotransferencia";
            this.radio_membrotransferencia.Size = new System.Drawing.Size(255, 29);
            this.radio_membrotransferencia.TabIndex = 4;
            this.radio_membrotransferencia.TabStop = true;
            this.radio_membrotransferencia.Text = "Membro por transferência";
            this.radio_membrotransferencia.UseVisualStyleBackColor = true;
            this.radio_membrotransferencia.CheckedChanged += new System.EventHandler(this.radio_membrotransferencia_CheckedChanged);
            // 
            // radio_visitante
            // 
            this.radio_visitante.AutoSize = true;
            this.radio_visitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_visitante.Location = new System.Drawing.Point(301, 193);
            this.radio_visitante.Name = "radio_visitante";
            this.radio_visitante.Size = new System.Drawing.Size(108, 29);
            this.radio_visitante.TabIndex = 5;
            this.radio_visitante.TabStop = true;
            this.radio_visitante.Text = "Visitante";
            this.radio_visitante.UseVisualStyleBackColor = true;
            this.radio_visitante.CheckedChanged += new System.EventHandler(this.radio_visitante_CheckedChanged);
            // 
            // radio_crianca
            // 
            this.radio_crianca.AutoSize = true;
            this.radio_crianca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_crianca.Location = new System.Drawing.Point(306, 255);
            this.radio_crianca.Name = "radio_crianca";
            this.radio_crianca.Size = new System.Drawing.Size(101, 29);
            this.radio_crianca.TabIndex = 6;
            this.radio_crianca.TabStop = true;
            this.radio_crianca.Text = "Criança";
            this.radio_crianca.UseVisualStyleBackColor = true;
            this.radio_crianca.CheckedChanged += new System.EventHandler(this.radio_crianca_CheckedChanged);
            // 
            // btn_proximo
            // 
            this.btn_proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proximo.Location = new System.Drawing.Point(651, 214);
            this.btn_proximo.Name = "btn_proximo";
            this.btn_proximo.Size = new System.Drawing.Size(122, 60);
            this.btn_proximo.TabIndex = 7;
            this.btn_proximo.Text = "Próximo";
            this.btn_proximo.UseVisualStyleBackColor = true;
            this.btn_proximo.Click += new System.EventHandler(this.btn_proximo_Click);
            // 
            // FrmMudancaEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_proximo);
            this.Controls.Add(this.radio_crianca);
            this.Controls.Add(this.radio_visitante);
            this.Controls.Add(this.radio_membrotransferencia);
            this.Controls.Add(this.radio_membroaclamacao);
            this.Controls.Add(this.radio_membroreconciliacao);
            this.Controls.Add(this.radio_membrobatismo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMudancaEstado";
            this.Text = "FrmMudancaEstado";
            this.Load += new System.EventHandler(this.FrmMudancaEstado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_membrobatismo;
        private System.Windows.Forms.RadioButton radio_membroreconciliacao;
        private System.Windows.Forms.RadioButton radio_membroaclamacao;
        private System.Windows.Forms.RadioButton radio_membrotransferencia;
        private System.Windows.Forms.RadioButton radio_visitante;
        private System.Windows.Forms.RadioButton radio_crianca;
        private System.Windows.Forms.Button btn_proximo;
    }
}