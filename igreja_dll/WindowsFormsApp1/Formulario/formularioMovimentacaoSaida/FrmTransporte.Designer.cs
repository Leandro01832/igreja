namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    partial class FrmTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransporte));
            this.checkBoxPagou = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.radioGasolina = new System.Windows.Forms.RadioButton();
            this.radioAlcool = new System.Windows.Forms.RadioButton();
            this.radioDiesel = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // checkBoxPagou
            // 
            this.checkBoxPagou.AutoSize = true;
            this.checkBoxPagou.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPagou.Location = new System.Drawing.Point(187, 181);
            this.checkBoxPagou.Name = "checkBoxPagou";
            this.checkBoxPagou.Size = new System.Drawing.Size(91, 29);
            this.checkBoxPagou.TabIndex = 282;
            this.checkBoxPagou.Text = "Pagou";
            this.checkBoxPagou.UseVisualStyleBackColor = true;
            this.checkBoxPagou.CheckedChanged += new System.EventHandler(this.checkBoxPagou_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 281;
            this.label2.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(187, 110);
            this.txtValor.MaxLength = 9;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(128, 30);
            this.txtValor.TabIndex = 283;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // radioGasolina
            // 
            this.radioGasolina.AutoSize = true;
            this.radioGasolina.Checked = true;
            this.radioGasolina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGasolina.Location = new System.Drawing.Point(187, 250);
            this.radioGasolina.Name = "radioGasolina";
            this.radioGasolina.Size = new System.Drawing.Size(110, 29);
            this.radioGasolina.TabIndex = 284;
            this.radioGasolina.TabStop = true;
            this.radioGasolina.Text = "Gasolina";
            this.radioGasolina.UseVisualStyleBackColor = true;
            this.radioGasolina.CheckedChanged += new System.EventHandler(this.radioGasolina_CheckedChanged);
            // 
            // radioAlcool
            // 
            this.radioAlcool.AutoSize = true;
            this.radioAlcool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlcool.Location = new System.Drawing.Point(187, 308);
            this.radioAlcool.Name = "radioAlcool";
            this.radioAlcool.Size = new System.Drawing.Size(87, 29);
            this.radioAlcool.TabIndex = 285;
            this.radioAlcool.Text = "Alcool";
            this.radioAlcool.UseVisualStyleBackColor = true;
            this.radioAlcool.CheckedChanged += new System.EventHandler(this.radioAlcool_CheckedChanged);
            // 
            // radioDiesel
            // 
            this.radioDiesel.AutoSize = true;
            this.radioDiesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDiesel.Location = new System.Drawing.Point(187, 368);
            this.radioDiesel.Name = "radioDiesel";
            this.radioDiesel.Size = new System.Drawing.Size(87, 29);
            this.radioDiesel.TabIndex = 286;
            this.radioDiesel.Text = "Diesel";
            this.radioDiesel.UseVisualStyleBackColor = true;
            this.radioDiesel.CheckedChanged += new System.EventHandler(this.radioDiesel_CheckedChanged);
            // 
            // FrmTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioGasolina);
            this.Controls.Add(this.radioDiesel);
            this.Controls.Add(this.radioAlcool);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.checkBoxPagou);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTransporte";
            this.Text = "FrmCadastrarTransporte";
            this.Load += new System.EventHandler(this.FrmCadastrarTransporte_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBoxPagou, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.Controls.SetChildIndex(this.radioAlcool, 0);
            this.Controls.SetChildIndex(this.radioDiesel, 0);
            this.Controls.SetChildIndex(this.radioGasolina, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPagou;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.RadioButton radioGasolina;
        private System.Windows.Forms.RadioButton radioAlcool;
        private System.Windows.Forms.RadioButton radioDiesel;
    }
}