namespace WindowsForms.form.cadastro_membro
{
    partial class cadastro_dados_pessoais
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
            this.text_cpf = new System.Windows.Forms.TextBox();
            this.text_rg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listestado_civil = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.text_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textemail = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.listBox_status = new System.Windows.Forms.ListBox();
            this.mask_data_nascimento = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_feminino = new System.Windows.Forms.RadioButton();
            this.radioButton_masculino = new System.Windows.Forms.RadioButton();
            this.nome = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_cpf
            // 
            this.text_cpf.AllowDrop = true;
            this.text_cpf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_cpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cpf.Location = new System.Drawing.Point(391, 219);
            this.text_cpf.Margin = new System.Windows.Forms.Padding(4);
            this.text_cpf.Name = "text_cpf";
            this.text_cpf.Size = new System.Drawing.Size(366, 29);
            this.text_cpf.TabIndex = 239;
            // 
            // text_rg
            // 
            this.text_rg.AllowDrop = true;
            this.text_rg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_rg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_rg.Location = new System.Drawing.Point(391, 158);
            this.text_rg.Margin = new System.Windows.Forms.Padding(4);
            this.text_rg.Name = "text_rg";
            this.text_rg.Size = new System.Drawing.Size(366, 29);
            this.text_rg.TabIndex = 238;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 291);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 236;
            this.label5.Text = "estado civil";
            // 
            // listestado_civil
            // 
            this.listestado_civil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listestado_civil.FormattingEnabled = true;
            this.listestado_civil.ItemHeight = 16;
            this.listestado_civil.Items.AddRange(new object[] {
            "casado(a)",
            "separado(a)",
            "solteiro(a)",
            "viuvo(a)"});
            this.listestado_civil.Location = new System.Drawing.Point(391, 280);
            this.listestado_civil.Margin = new System.Windows.Forms.Padding(4);
            this.listestado_civil.Name = "listestado_civil";
            this.listestado_civil.Size = new System.Drawing.Size(365, 36);
            this.listestado_civil.TabIndex = 227;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(185, 164);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 25);
            this.label14.TabIndex = 235;
            this.label14.Text = "RG";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(185, 223);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 25);
            this.label13.TabIndex = 234;
            this.label13.Text = "CPF";
            // 
            // text_nome
            // 
            this.text_nome.AllowDrop = true;
            this.text_nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_nome.Location = new System.Drawing.Point(391, 103);
            this.text_nome.Margin = new System.Windows.Forms.Padding(4);
            this.text_nome.Name = "text_nome";
            this.text_nome.Size = new System.Drawing.Size(366, 29);
            this.text_nome.TabIndex = 225;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 226;
            this.label1.Text = "nome";
            // 
            // textemail
            // 
            this.textemail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textemail.Location = new System.Drawing.Point(391, 548);
            this.textemail.Margin = new System.Windows.Forms.Padding(4);
            this.textemail.Name = "textemail";
            this.textemail.Size = new System.Drawing.Size(365, 29);
            this.textemail.TabIndex = 247;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(209, 552);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 25);
            this.label16.TabIndex = 251;
            this.label16.Text = "email";
            // 
            // listBox_status
            // 
            this.listBox_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_status.FormattingEnabled = true;
            this.listBox_status.ItemHeight = 16;
            this.listBox_status.Items.AddRange(new object[] {
            "residente em Cataguases",
            "residente em outra cidade de Minas Gerais",
            "residente em outro estado do Brasil",
            "residente em outro país"});
            this.listBox_status.Location = new System.Drawing.Point(391, 350);
            this.listBox_status.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_status.Name = "listBox_status";
            this.listBox_status.Size = new System.Drawing.Size(291, 68);
            this.listBox_status.TabIndex = 253;
            // 
            // mask_data_nascimento
            // 
            this.mask_data_nascimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mask_data_nascimento.BeepOnError = true;
            this.mask_data_nascimento.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mask_data_nascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mask_data_nascimento.Location = new System.Drawing.Point(391, 470);
            this.mask_data_nascimento.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_nascimento.Mask = "00/00/0000";
            this.mask_data_nascimento.Name = "mask_data_nascimento";
            this.mask_data_nascimento.RejectInputOnFirstFailure = true;
            this.mask_data_nascimento.Size = new System.Drawing.Size(204, 29);
            this.mask_data_nascimento.TabIndex = 254;
            this.mask_data_nascimento.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(135, 474);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 25);
            this.label11.TabIndex = 255;
            this.label11.Text = "data de nascimento";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 382);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 252;
            this.label2.Text = "status";
            // 
            // radioButton_feminino
            // 
            this.radioButton_feminino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton_feminino.AutoSize = true;
            this.radioButton_feminino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_feminino.Location = new System.Drawing.Point(391, 692);
            this.radioButton_feminino.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_feminino.Name = "radioButton_feminino";
            this.radioButton_feminino.Size = new System.Drawing.Size(106, 29);
            this.radioButton_feminino.TabIndex = 257;
            this.radioButton_feminino.TabStop = true;
            this.radioButton_feminino.Text = "feminino";
            this.radioButton_feminino.UseVisualStyleBackColor = true;
            // 
            // radioButton_masculino
            // 
            this.radioButton_masculino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton_masculino.AutoSize = true;
            this.radioButton_masculino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_masculino.Location = new System.Drawing.Point(395, 639);
            this.radioButton_masculino.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_masculino.Name = "radioButton_masculino";
            this.radioButton_masculino.Size = new System.Drawing.Size(121, 29);
            this.radioButton_masculino.TabIndex = 256;
            this.radioButton_masculino.TabStop = true;
            this.radioButton_masculino.Text = "masculino";
            this.radioButton_masculino.UseVisualStyleBackColor = true;
            // 
            // nome
            // 
            this.nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nome.AutoSize = true;
            this.nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nome.Location = new System.Drawing.Point(207, 643);
            this.nome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(60, 25);
            this.nome.TabIndex = 258;
            this.nome.Text = "sexo:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(288, 750);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 89);
            this.button1.TabIndex = 259;
            this.button1.Text = "cadastrar endereço";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cadastro_dados_pessoais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 877);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton_feminino);
            this.Controls.Add(this.radioButton_masculino);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.listBox_status);
            this.Controls.Add(this.mask_data_nascimento);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textemail);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.text_cpf);
            this.Controls.Add(this.text_rg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listestado_civil);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.text_nome);
            this.Controls.Add(this.label1);
            this.Name = "cadastro_dados_pessoais";
            this.Text = "cadastro de dados pessoais";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cadastro_dados_pessoais_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_cpf;
        private System.Windows.Forms.TextBox text_rg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listestado_civil;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textemail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox listBox_status;
        private System.Windows.Forms.MaskedTextBox mask_data_nascimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_feminino;
        private System.Windows.Forms.RadioButton radioButton_masculino;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Button button1;
    }
}