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
            this.radio_pessoa = new System.Windows.Forms.RadioButton();
            this.radio_ministerio = new System.Windows.Forms.RadioButton();
            this.radio_celula = new System.Windows.Forms.RadioButton();
            this.radio_chamada = new System.Windows.Forms.RadioButton();
            this.radio_reuniao = new System.Windows.Forms.RadioButton();
            this.radio_historico = new System.Windows.Forms.RadioButton();
            this.dgdados = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.check_pesquisa_id = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_nome_mae = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_nome_pai = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_email = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_data_reuniao = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_data_visita = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_ano_batismo = new System.Windows.Forms.CheckBox();
            this.check_pesquisa_nome = new System.Windows.Forms.CheckBox();
            this.txt_pesquisa_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_todos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pesquisa_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pesquisa_nome_pai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pesquisa_nome_mae = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pesquisa_ano_batismo_valor1 = new System.Windows.Forms.TextBox();
            this.txt_pesquisa_ano_batismo_valor2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_pesquisa_id_valor2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_pesquisa_id_valor1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_pessoa
            // 
            this.radio_pessoa.AutoSize = true;
            this.radio_pessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_pessoa.Location = new System.Drawing.Point(37, 30);
            this.radio_pessoa.Name = "radio_pessoa";
            this.radio_pessoa.Size = new System.Drawing.Size(115, 33);
            this.radio_pessoa.TabIndex = 0;
            this.radio_pessoa.TabStop = true;
            this.radio_pessoa.Text = "Pessoa";
            this.radio_pessoa.UseVisualStyleBackColor = true;
            this.radio_pessoa.CheckedChanged += new System.EventHandler(this.radio_pessoa_CheckedChanged);
            // 
            // radio_ministerio
            // 
            this.radio_ministerio.AutoSize = true;
            this.radio_ministerio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_ministerio.Location = new System.Drawing.Point(177, 30);
            this.radio_ministerio.Name = "radio_ministerio";
            this.radio_ministerio.Size = new System.Drawing.Size(139, 33);
            this.radio_ministerio.TabIndex = 1;
            this.radio_ministerio.TabStop = true;
            this.radio_ministerio.Text = "Ministério";
            this.radio_ministerio.UseVisualStyleBackColor = true;
            this.radio_ministerio.CheckedChanged += new System.EventHandler(this.radio_ministerio_CheckedChanged);
            // 
            // radio_celula
            // 
            this.radio_celula.AutoSize = true;
            this.radio_celula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_celula.Location = new System.Drawing.Point(350, 30);
            this.radio_celula.Name = "radio_celula";
            this.radio_celula.Size = new System.Drawing.Size(103, 33);
            this.radio_celula.TabIndex = 2;
            this.radio_celula.TabStop = true;
            this.radio_celula.Text = "Celula";
            this.radio_celula.UseVisualStyleBackColor = true;
            this.radio_celula.CheckedChanged += new System.EventHandler(this.radio_celula_CheckedChanged);
            // 
            // radio_chamada
            // 
            this.radio_chamada.AutoSize = true;
            this.radio_chamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_chamada.Location = new System.Drawing.Point(37, 87);
            this.radio_chamada.Name = "radio_chamada";
            this.radio_chamada.Size = new System.Drawing.Size(137, 33);
            this.radio_chamada.TabIndex = 3;
            this.radio_chamada.TabStop = true;
            this.radio_chamada.Text = "Chamada";
            this.radio_chamada.UseVisualStyleBackColor = true;
            this.radio_chamada.CheckedChanged += new System.EventHandler(this.radio_chamada_CheckedChanged);
            // 
            // radio_reuniao
            // 
            this.radio_reuniao.AutoSize = true;
            this.radio_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_reuniao.Location = new System.Drawing.Point(192, 87);
            this.radio_reuniao.Name = "radio_reuniao";
            this.radio_reuniao.Size = new System.Drawing.Size(124, 33);
            this.radio_reuniao.TabIndex = 4;
            this.radio_reuniao.TabStop = true;
            this.radio_reuniao.Text = "Reunião";
            this.radio_reuniao.UseVisualStyleBackColor = true;
            this.radio_reuniao.CheckedChanged += new System.EventHandler(this.radio_reuniao_CheckedChanged);
            // 
            // radio_historico
            // 
            this.radio_historico.AutoSize = true;
            this.radio_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_historico.Location = new System.Drawing.Point(350, 87);
            this.radio_historico.Name = "radio_historico";
            this.radio_historico.Size = new System.Drawing.Size(129, 33);
            this.radio_historico.TabIndex = 5;
            this.radio_historico.TabStop = true;
            this.radio_historico.Text = "Histórico";
            this.radio_historico.UseVisualStyleBackColor = true;
            this.radio_historico.CheckedChanged += new System.EventHandler(this.radio_historico_CheckedChanged);
            // 
            // dgdados
            // 
            this.dgdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdados.Location = new System.Drawing.Point(55, 305);
            this.dgdados.Name = "dgdados";
            this.dgdados.RowTemplate.Height = 24;
            this.dgdados.Size = new System.Drawing.Size(1240, 493);
            this.dgdados.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(487, 37);
            this.comboBox1.TabIndex = 7;
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesquisar.Location = new System.Drawing.Point(1631, 738);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(163, 60);
            this.btn_pesquisar.TabIndex = 8;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            // 
            // check_pesquisa_id
            // 
            this.check_pesquisa_id.AutoSize = true;
            this.check_pesquisa_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_id.Location = new System.Drawing.Point(631, 24);
            this.check_pesquisa_id.Name = "check_pesquisa_id";
            this.check_pesquisa_id.Size = new System.Drawing.Size(175, 29);
            this.check_pesquisa_id.TabIndex = 9;
            this.check_pesquisa_id.Text = "Pesquisar por Id";
            this.check_pesquisa_id.UseVisualStyleBackColor = true;
            this.check_pesquisa_id.CheckedChanged += new System.EventHandler(this.check_pesquisa_id_CheckedChanged);
            // 
            // check_pesquisa_nome_mae
            // 
            this.check_pesquisa_nome_mae.AutoSize = true;
            this.check_pesquisa_nome_mae.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome_mae.Location = new System.Drawing.Point(631, 78);
            this.check_pesquisa_nome_mae.Name = "check_pesquisa_nome_mae";
            this.check_pesquisa_nome_mae.Size = new System.Drawing.Size(278, 29);
            this.check_pesquisa_nome_mae.TabIndex = 10;
            this.check_pesquisa_nome_mae.Text = "Pesquisar por nome da mãe";
            this.check_pesquisa_nome_mae.UseVisualStyleBackColor = true;
            this.check_pesquisa_nome_mae.CheckedChanged += new System.EventHandler(this.check_pesquisa_nome_mae_CheckedChanged);
            // 
            // check_pesquisa_nome_pai
            // 
            this.check_pesquisa_nome_pai.AutoSize = true;
            this.check_pesquisa_nome_pai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome_pai.Location = new System.Drawing.Point(631, 137);
            this.check_pesquisa_nome_pai.Name = "check_pesquisa_nome_pai";
            this.check_pesquisa_nome_pai.Size = new System.Drawing.Size(266, 29);
            this.check_pesquisa_nome_pai.TabIndex = 11;
            this.check_pesquisa_nome_pai.Text = "Pesquisar por nome do pai";
            this.check_pesquisa_nome_pai.UseVisualStyleBackColor = true;
            this.check_pesquisa_nome_pai.CheckedChanged += new System.EventHandler(this.check_pesquisa_nome_pai_CheckedChanged);
            // 
            // check_pesquisa_email
            // 
            this.check_pesquisa_email.AutoSize = true;
            this.check_pesquisa_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_email.Location = new System.Drawing.Point(631, 196);
            this.check_pesquisa_email.Name = "check_pesquisa_email";
            this.check_pesquisa_email.Size = new System.Drawing.Size(205, 29);
            this.check_pesquisa_email.TabIndex = 12;
            this.check_pesquisa_email.Text = "Pesquisar por email";
            this.check_pesquisa_email.UseVisualStyleBackColor = true;
            this.check_pesquisa_email.CheckedChanged += new System.EventHandler(this.check_pesquisa_email_CheckedChanged);
            // 
            // check_pesquisa_data_reuniao
            // 
            this.check_pesquisa_data_reuniao.AutoSize = true;
            this.check_pesquisa_data_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_data_reuniao.Location = new System.Drawing.Point(960, 24);
            this.check_pesquisa_data_reuniao.Name = "check_pesquisa_data_reuniao";
            this.check_pesquisa_data_reuniao.Size = new System.Drawing.Size(294, 29);
            this.check_pesquisa_data_reuniao.TabIndex = 13;
            this.check_pesquisa_data_reuniao.Text = "Pesquisar por data da reunião";
            this.check_pesquisa_data_reuniao.UseVisualStyleBackColor = true;
            this.check_pesquisa_data_reuniao.CheckedChanged += new System.EventHandler(this.check_pesquisa_data_reuniao_CheckedChanged);
            // 
            // check_pesquisa_data_visita
            // 
            this.check_pesquisa_data_visita.AutoSize = true;
            this.check_pesquisa_data_visita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_data_visita.Location = new System.Drawing.Point(960, 78);
            this.check_pesquisa_data_visita.Name = "check_pesquisa_data_visita";
            this.check_pesquisa_data_visita.Size = new System.Drawing.Size(273, 29);
            this.check_pesquisa_data_visita.TabIndex = 14;
            this.check_pesquisa_data_visita.Text = "Pesquisar por data da visita";
            this.check_pesquisa_data_visita.UseVisualStyleBackColor = true;
            this.check_pesquisa_data_visita.CheckedChanged += new System.EventHandler(this.check_pesquisa_data_visita_CheckedChanged);
            // 
            // check_pesquisa_ano_batismo
            // 
            this.check_pesquisa_ano_batismo.AutoSize = true;
            this.check_pesquisa_ano_batismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_ano_batismo.Location = new System.Drawing.Point(960, 137);
            this.check_pesquisa_ano_batismo.Name = "check_pesquisa_ano_batismo";
            this.check_pesquisa_ano_batismo.Size = new System.Drawing.Size(292, 29);
            this.check_pesquisa_ano_batismo.TabIndex = 17;
            this.check_pesquisa_ano_batismo.Text = "Pesquisar por ano de batismo";
            this.check_pesquisa_ano_batismo.UseVisualStyleBackColor = true;
            this.check_pesquisa_ano_batismo.CheckedChanged += new System.EventHandler(this.check_pesquisa_ano_batismo_CheckedChanged);
            // 
            // check_pesquisa_nome
            // 
            this.check_pesquisa_nome.AutoSize = true;
            this.check_pesquisa_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome.Location = new System.Drawing.Point(960, 196);
            this.check_pesquisa_nome.Name = "check_pesquisa_nome";
            this.check_pesquisa_nome.Size = new System.Drawing.Size(208, 29);
            this.check_pesquisa_nome.TabIndex = 18;
            this.check_pesquisa_nome.Text = "Pesquisar por nome";
            this.check_pesquisa_nome.UseVisualStyleBackColor = true;
            this.check_pesquisa_nome.CheckedChanged += new System.EventHandler(this.check_pesquisa_nome_CheckedChanged);
            // 
            // txt_pesquisa_nome
            // 
            this.txt_pesquisa_nome.Enabled = false;
            this.txt_pesquisa_nome.Location = new System.Drawing.Point(1542, 31);
            this.txt_pesquisa_nome.Name = "txt_pesquisa_nome";
            this.txt_pesquisa_nome.Size = new System.Drawing.Size(242, 22);
            this.txt_pesquisa_nome.TabIndex = 19;
            this.txt_pesquisa_nome.TextChanged += new System.EventHandler(this.txt_pesquisa_nome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1399, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Pesquisar por nome";
            // 
            // btn_todos
            // 
            this.btn_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_todos.Location = new System.Drawing.Point(1346, 738);
            this.btn_todos.Name = "btn_todos";
            this.btn_todos.Size = new System.Drawing.Size(245, 60);
            this.btn_todos.TabIndex = 21;
            this.btn_todos.Text = "Todos os registros";
            this.btn_todos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1399, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Pesquisar por email";
            // 
            // txt_pesquisa_email
            // 
            this.txt_pesquisa_email.Enabled = false;
            this.txt_pesquisa_email.Location = new System.Drawing.Point(1542, 77);
            this.txt_pesquisa_email.Name = "txt_pesquisa_email";
            this.txt_pesquisa_email.Size = new System.Drawing.Size(242, 22);
            this.txt_pesquisa_email.TabIndex = 22;
            this.txt_pesquisa_email.TextChanged += new System.EventHandler(this.txt_pesquisa_email_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1354, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Pesquisar por nome do pai";
            // 
            // txt_pesquisa_nome_pai
            // 
            this.txt_pesquisa_nome_pai.Enabled = false;
            this.txt_pesquisa_nome_pai.Location = new System.Drawing.Point(1542, 126);
            this.txt_pesquisa_nome_pai.Name = "txt_pesquisa_nome_pai";
            this.txt_pesquisa_nome_pai.Size = new System.Drawing.Size(242, 22);
            this.txt_pesquisa_nome_pai.TabIndex = 24;
            this.txt_pesquisa_nome_pai.TextChanged += new System.EventHandler(this.txt_pesquisa_nome_pai_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1354, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Pesquisar por nome do mãe";
            // 
            // txt_pesquisa_nome_mae
            // 
            this.txt_pesquisa_nome_mae.Enabled = false;
            this.txt_pesquisa_nome_mae.Location = new System.Drawing.Point(1542, 169);
            this.txt_pesquisa_nome_mae.Name = "txt_pesquisa_nome_mae";
            this.txt_pesquisa_nome_mae.Size = new System.Drawing.Size(242, 22);
            this.txt_pesquisa_nome_mae.TabIndex = 26;
            this.txt_pesquisa_nome_mae.TextChanged += new System.EventHandler(this.txt_pesquisa_nome_mae_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1322, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Pesquisar por ano de batismo";
            // 
            // txt_pesquisa_ano_batismo_valor1
            // 
            this.txt_pesquisa_ano_batismo_valor1.Enabled = false;
            this.txt_pesquisa_ano_batismo_valor1.Location = new System.Drawing.Point(1570, 221);
            this.txt_pesquisa_ano_batismo_valor1.Name = "txt_pesquisa_ano_batismo_valor1";
            this.txt_pesquisa_ano_batismo_valor1.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_ano_batismo_valor1.TabIndex = 28;
            this.txt_pesquisa_ano_batismo_valor1.TextChanged += new System.EventHandler(this.txt_pesquisa_ano_batismo_valor1_TextChanged);
            // 
            // txt_pesquisa_ano_batismo_valor2
            // 
            this.txt_pesquisa_ano_batismo_valor2.Enabled = false;
            this.txt_pesquisa_ano_batismo_valor2.Location = new System.Drawing.Point(1715, 221);
            this.txt_pesquisa_ano_batismo_valor2.Name = "txt_pesquisa_ano_batismo_valor2";
            this.txt_pesquisa_ano_batismo_valor2.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_ano_batismo_valor2.TabIndex = 30;
            this.txt_pesquisa_ano_batismo_valor2.TextChanged += new System.EventHandler(this.txt_pesquisa_ano_batismo_valor2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1538, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "De";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1667, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Até";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1667, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Até";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1538, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "De";
            // 
            // txt_pesquisa_id_valor2
            // 
            this.txt_pesquisa_id_valor2.Enabled = false;
            this.txt_pesquisa_id_valor2.Location = new System.Drawing.Point(1715, 281);
            this.txt_pesquisa_id_valor2.Name = "txt_pesquisa_id_valor2";
            this.txt_pesquisa_id_valor2.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_id_valor2.TabIndex = 35;
            this.txt_pesquisa_id_valor2.TextChanged += new System.EventHandler(this.txt_pesquisa_id_valor2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1408, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Pesquisar por id";
            // 
            // txt_pesquisa_id_valor1
            // 
            this.txt_pesquisa_id_valor1.Enabled = false;
            this.txt_pesquisa_id_valor1.Location = new System.Drawing.Point(1570, 281);
            this.txt_pesquisa_id_valor1.Name = "txt_pesquisa_id_valor1";
            this.txt_pesquisa_id_valor1.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_id_valor1.TabIndex = 33;
            this.txt_pesquisa_id_valor1.TextChanged += new System.EventHandler(this.txt_pesquisa_id_valor1_TextChanged);
            // 
            // Pesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 819);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_pesquisa_id_valor2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_pesquisa_id_valor1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pesquisa_ano_batismo_valor2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_pesquisa_ano_batismo_valor1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_pesquisa_nome_mae);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_pesquisa_nome_pai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_pesquisa_email);
            this.Controls.Add(this.btn_todos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_pesquisa_nome);
            this.Controls.Add(this.check_pesquisa_nome);
            this.Controls.Add(this.check_pesquisa_ano_batismo);
            this.Controls.Add(this.check_pesquisa_data_visita);
            this.Controls.Add(this.check_pesquisa_data_reuniao);
            this.Controls.Add(this.check_pesquisa_email);
            this.Controls.Add(this.check_pesquisa_nome_pai);
            this.Controls.Add(this.check_pesquisa_nome_mae);
            this.Controls.Add(this.check_pesquisa_id);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgdados);
            this.Controls.Add(this.radio_historico);
            this.Controls.Add(this.radio_reuniao);
            this.Controls.Add(this.radio_chamada);
            this.Controls.Add(this.radio_celula);
            this.Controls.Add(this.radio_ministerio);
            this.Controls.Add(this.radio_pessoa);
            this.Name = "Pesquisar";
            this.Text = "Pesquisar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pesquisar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_pessoa;
        private System.Windows.Forms.RadioButton radio_ministerio;
        private System.Windows.Forms.RadioButton radio_celula;
        private System.Windows.Forms.RadioButton radio_chamada;
        private System.Windows.Forms.RadioButton radio_reuniao;
        private System.Windows.Forms.RadioButton radio_historico;
        private System.Windows.Forms.DataGridView dgdados;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.CheckBox check_pesquisa_id;
        private System.Windows.Forms.CheckBox check_pesquisa_nome_mae;
        private System.Windows.Forms.CheckBox check_pesquisa_nome_pai;
        private System.Windows.Forms.CheckBox check_pesquisa_email;
        private System.Windows.Forms.CheckBox check_pesquisa_data_reuniao;
        private System.Windows.Forms.CheckBox check_pesquisa_data_visita;
        private System.Windows.Forms.CheckBox check_pesquisa_ano_batismo;
        private System.Windows.Forms.CheckBox check_pesquisa_nome;
        private System.Windows.Forms.TextBox txt_pesquisa_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_todos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pesquisa_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pesquisa_nome_pai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_pesquisa_nome_mae;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pesquisa_ano_batismo_valor1;
        private System.Windows.Forms.TextBox txt_pesquisa_ano_batismo_valor2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_pesquisa_id_valor2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_pesquisa_id_valor1;
    }
}