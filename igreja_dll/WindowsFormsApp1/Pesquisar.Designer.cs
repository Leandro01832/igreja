namespace WindowsFormsApp1
{
    partial class Pesquisar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pesquisar));
            this.dgdados = new System.Windows.Forms.DataGridView();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.btn_todos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pesquisa_numero1 = new System.Windows.Forms.TextBox();
            this.txt_pesquisa_numero2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mask_horario_valor1 = new System.Windows.Forms.MaskedTextBox();
            this.mask_horario_valor2 = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.mask_data_valor1 = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.mask_data_valor2 = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txt_pesquisa_texto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdados
            // 
            this.dgdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdados.Location = new System.Drawing.Point(55, 305);
            this.dgdados.Name = "dgdados";
            this.dgdados.RowTemplate.Height = 24;
            this.dgdados.Size = new System.Drawing.Size(1240, 493);
            this.dgdados.TabIndex = 6;
            this.dgdados.SelectionChanged += new System.EventHandler(this.dgdados_SelectionChanged);
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesquisar.Location = new System.Drawing.Point(1617, 664);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(163, 60);
            this.btn_pesquisar.TabIndex = 8;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // btn_todos
            // 
            this.btn_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_todos.Location = new System.Drawing.Point(1332, 664);
            this.btn_todos.Name = "btn_todos";
            this.btn_todos.Size = new System.Drawing.Size(245, 60);
            this.btn_todos.TabIndex = 21;
            this.btn_todos.Text = "Todos os registros";
            this.btn_todos.UseVisualStyleBackColor = true;
            this.btn_todos.Click += new System.EventHandler(this.btn_todos_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1367, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Pesquisar por numero";
            // 
            // txt_pesquisa_numero1
            // 
            this.txt_pesquisa_numero1.Enabled = false;
            this.txt_pesquisa_numero1.Location = new System.Drawing.Point(1566, 318);
            this.txt_pesquisa_numero1.Name = "txt_pesquisa_numero1";
            this.txt_pesquisa_numero1.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_numero1.TabIndex = 28;
            // 
            // txt_pesquisa_numero2
            // 
            this.txt_pesquisa_numero2.Enabled = false;
            this.txt_pesquisa_numero2.Location = new System.Drawing.Point(1711, 318);
            this.txt_pesquisa_numero2.Name = "txt_pesquisa_numero2";
            this.txt_pesquisa_numero2.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_numero2.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1534, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "De";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1663, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Até";
            // 
            // mask_horario_valor1
            // 
            this.mask_horario_valor1.Enabled = false;
            this.mask_horario_valor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario_valor1.Location = new System.Drawing.Point(1566, 370);
            this.mask_horario_valor1.Mask = "00:00";
            this.mask_horario_valor1.Name = "mask_horario_valor1";
            this.mask_horario_valor1.Size = new System.Drawing.Size(69, 30);
            this.mask_horario_valor1.TabIndex = 275;
            this.mask_horario_valor1.ValidatingType = typeof(System.DateTime);
            // 
            // mask_horario_valor2
            // 
            this.mask_horario_valor2.Enabled = false;
            this.mask_horario_valor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario_valor2.Location = new System.Drawing.Point(1711, 370);
            this.mask_horario_valor2.Mask = "00:00";
            this.mask_horario_valor2.Name = "mask_horario_valor2";
            this.mask_horario_valor2.Size = new System.Drawing.Size(69, 30);
            this.mask_horario_valor2.TabIndex = 276;
            this.mask_horario_valor2.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1534, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 17);
            this.label11.TabIndex = 277;
            this.label11.Text = "De";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1663, 383);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 278;
            this.label12.Text = "Até";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1370, 380);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 17);
            this.label13.TabIndex = 279;
            this.label13.Text = "Pesquisar por horario";
            // 
            // mask_data_valor1
            // 
            this.mask_data_valor1.BeepOnError = true;
            this.mask_data_valor1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_valor1.Enabled = false;
            this.mask_data_valor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_valor1.Location = new System.Drawing.Point(1535, 429);
            this.mask_data_valor1.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_valor1.Mask = "00/00/0000";
            this.mask_data_valor1.Name = "mask_data_valor1";
            this.mask_data_valor1.RejectInputOnFirstFailure = true;
            this.mask_data_valor1.Size = new System.Drawing.Size(101, 29);
            this.mask_data_valor1.TabIndex = 280;
            this.mask_data_valor1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1357, 435);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 17);
            this.label14.TabIndex = 281;
            this.label14.Text = "Pesquisar por data";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1502, 435);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 17);
            this.label15.TabIndex = 282;
            this.label15.Text = "De";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1643, 435);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 17);
            this.label16.TabIndex = 283;
            this.label16.Text = "Até";
            // 
            // mask_data_valor2
            // 
            this.mask_data_valor2.BeepOnError = true;
            this.mask_data_valor2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_valor2.Enabled = false;
            this.mask_data_valor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_valor2.Location = new System.Drawing.Point(1679, 426);
            this.mask_data_valor2.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_valor2.Mask = "00/00/0000";
            this.mask_data_valor2.Name = "mask_data_valor2";
            this.mask_data_valor2.RejectInputOnFirstFailure = true;
            this.mask_data_valor2.Size = new System.Drawing.Size(101, 29);
            this.mask_data_valor2.TabIndex = 284;
            this.mask_data_valor2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1666, 496);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 46);
            this.btnAdd.TabIndex = 290;
            this.btnAdd.Text = "Adicionar Restrição";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txt_pesquisa_texto
            // 
            this.txt_pesquisa_texto.Enabled = false;
            this.txt_pesquisa_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pesquisa_texto.Location = new System.Drawing.Point(1535, 275);
            this.txt_pesquisa_texto.Name = "txt_pesquisa_texto";
            this.txt_pesquisa_texto.Size = new System.Drawing.Size(245, 28);
            this.txt_pesquisa_texto.TabIndex = 291;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1367, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 292;
            this.label2.Text = "Pesquisar por texto";
            // 
            // Pesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 819);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_pesquisa_texto);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mask_data_valor2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.mask_data_valor1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mask_horario_valor2);
            this.Controls.Add(this.mask_horario_valor1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pesquisa_numero2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_pesquisa_numero1);
            this.Controls.Add(this.btn_todos);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.dgdados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pesquisar";
            this.Text = "Pesquisar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pesquisar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgdados;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.Button btn_todos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pesquisa_numero1;
        private System.Windows.Forms.TextBox txt_pesquisa_numero2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mask_horario_valor1;
        private System.Windows.Forms.MaskedTextBox mask_horario_valor2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mask_data_valor1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox mask_data_valor2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txt_pesquisa_texto;
        private System.Windows.Forms.Label label2;
    }
}