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
            this.txt_numeros_restricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_todos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pesquisa_numero1 = new System.Windows.Forms.TextBox();
            this.txt_pesquisa_numero2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radio_telefone = new System.Windows.Forms.RadioButton();
            this.radio_endereco = new System.Windows.Forms.RadioButton();
            this.radio_mudanca = new System.Windows.Forms.RadioButton();
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
            this.check_horario_celula = new System.Windows.Forms.CheckBox();
            this.check_horario_reuniao = new System.Windows.Forms.CheckBox();
            this.check_horario_final_reuniao = new System.Windows.Forms.CheckBox();
            this.check_data_mudanca_estado = new System.Windows.Forms.CheckBox();
            this.txt_comando = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_pessoa
            // 
            this.radio_pessoa.AutoSize = true;
            this.radio_pessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_pessoa.Location = new System.Drawing.Point(55, 20);
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
            this.radio_ministerio.Location = new System.Drawing.Point(205, 20);
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
            this.radio_celula.Location = new System.Drawing.Point(363, 20);
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
            this.radio_chamada.Location = new System.Drawing.Point(55, 68);
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
            this.radio_reuniao.Location = new System.Drawing.Point(205, 68);
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
            this.radio_historico.Location = new System.Drawing.Point(363, 68);
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
            this.dgdados.SelectionChanged += new System.EventHandler(this.dgdados_SelectionChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 242);
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
            this.check_pesquisa_id.Location = new System.Drawing.Point(599, 20);
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
            this.check_pesquisa_nome_mae.Enabled = false;
            this.check_pesquisa_nome_mae.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome_mae.Location = new System.Drawing.Point(599, 55);
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
            this.check_pesquisa_nome_pai.Enabled = false;
            this.check_pesquisa_nome_pai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome_pai.Location = new System.Drawing.Point(599, 90);
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
            this.check_pesquisa_email.Enabled = false;
            this.check_pesquisa_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_email.Location = new System.Drawing.Point(599, 131);
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
            this.check_pesquisa_data_reuniao.Enabled = false;
            this.check_pesquisa_data_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_data_reuniao.Location = new System.Drawing.Point(917, 24);
            this.check_pesquisa_data_reuniao.Name = "check_pesquisa_data_reuniao";
            this.check_pesquisa_data_reuniao.Size = new System.Drawing.Size(294, 29);
            this.check_pesquisa_data_reuniao.TabIndex = 13;
            this.check_pesquisa_data_reuniao.Text = "Pesquisar por data da reunião";
            this.check_pesquisa_data_reuniao.UseVisualStyleBackColor = true;
            // 
            // check_pesquisa_data_visita
            // 
            this.check_pesquisa_data_visita.AutoSize = true;
            this.check_pesquisa_data_visita.Enabled = false;
            this.check_pesquisa_data_visita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_data_visita.Location = new System.Drawing.Point(917, 55);
            this.check_pesquisa_data_visita.Name = "check_pesquisa_data_visita";
            this.check_pesquisa_data_visita.Size = new System.Drawing.Size(273, 29);
            this.check_pesquisa_data_visita.TabIndex = 14;
            this.check_pesquisa_data_visita.Text = "Pesquisar por data da visita";
            this.check_pesquisa_data_visita.UseVisualStyleBackColor = true;
            // 
            // check_pesquisa_ano_batismo
            // 
            this.check_pesquisa_ano_batismo.AutoSize = true;
            this.check_pesquisa_ano_batismo.Enabled = false;
            this.check_pesquisa_ano_batismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_ano_batismo.Location = new System.Drawing.Point(917, 119);
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
            this.check_pesquisa_nome.Enabled = false;
            this.check_pesquisa_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_pesquisa_nome.Location = new System.Drawing.Point(599, 166);
            this.check_pesquisa_nome.Name = "check_pesquisa_nome";
            this.check_pesquisa_nome.Size = new System.Drawing.Size(208, 29);
            this.check_pesquisa_nome.TabIndex = 18;
            this.check_pesquisa_nome.Text = "Pesquisar por nome";
            this.check_pesquisa_nome.UseVisualStyleBackColor = true;
            this.check_pesquisa_nome.CheckedChanged += new System.EventHandler(this.check_pesquisa_nome_CheckedChanged);
            // 
            // txt_numeros_restricao
            // 
            this.txt_numeros_restricao.Enabled = false;
            this.txt_numeros_restricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeros_restricao.Location = new System.Drawing.Point(1310, 676);
            this.txt_numeros_restricao.Name = "txt_numeros_restricao";
            this.txt_numeros_restricao.Size = new System.Drawing.Size(495, 28);
            this.txt_numeros_restricao.TabIndex = 19;
            this.txt_numeros_restricao.TextChanged += new System.EventHandler(this.txt_numeros_restricao_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1307, 641);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Numeros das restrições";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1371, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Pesquisar por numero";
            // 
            // txt_pesquisa_numero1
            // 
            this.txt_pesquisa_numero1.Enabled = false;
            this.txt_pesquisa_numero1.Location = new System.Drawing.Point(1570, 55);
            this.txt_pesquisa_numero1.Name = "txt_pesquisa_numero1";
            this.txt_pesquisa_numero1.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_numero1.TabIndex = 28;
            // 
            // txt_pesquisa_numero2
            // 
            this.txt_pesquisa_numero2.Enabled = false;
            this.txt_pesquisa_numero2.Location = new System.Drawing.Point(1715, 55);
            this.txt_pesquisa_numero2.Name = "txt_pesquisa_numero2";
            this.txt_pesquisa_numero2.Size = new System.Drawing.Size(69, 22);
            this.txt_pesquisa_numero2.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1538, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "De";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1667, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Até";
            // 
            // radio_telefone
            // 
            this.radio_telefone.AutoSize = true;
            this.radio_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_telefone.Location = new System.Drawing.Point(55, 117);
            this.radio_telefone.Name = "radio_telefone";
            this.radio_telefone.Size = new System.Drawing.Size(131, 33);
            this.radio_telefone.TabIndex = 38;
            this.radio_telefone.TabStop = true;
            this.radio_telefone.Text = "Telefone";
            this.radio_telefone.UseVisualStyleBackColor = true;
            this.radio_telefone.CheckedChanged += new System.EventHandler(this.radio_telefone_CheckedChanged);
            // 
            // radio_endereco
            // 
            this.radio_endereco.AutoSize = true;
            this.radio_endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_endereco.Location = new System.Drawing.Point(205, 117);
            this.radio_endereco.Name = "radio_endereco";
            this.radio_endereco.Size = new System.Drawing.Size(139, 33);
            this.radio_endereco.TabIndex = 39;
            this.radio_endereco.TabStop = true;
            this.radio_endereco.Text = "Endereço";
            this.radio_endereco.UseVisualStyleBackColor = true;
            this.radio_endereco.CheckedChanged += new System.EventHandler(this.radio_endereco_CheckedChanged);
            // 
            // radio_mudanca
            // 
            this.radio_mudanca.AutoSize = true;
            this.radio_mudanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_mudanca.Location = new System.Drawing.Point(55, 162);
            this.radio_mudanca.Name = "radio_mudanca";
            this.radio_mudanca.Size = new System.Drawing.Size(245, 33);
            this.radio_mudanca.TabIndex = 40;
            this.radio_mudanca.TabStop = true;
            this.radio_mudanca.Text = "Mudança de estado";
            this.radio_mudanca.UseVisualStyleBackColor = true;
            this.radio_mudanca.CheckedChanged += new System.EventHandler(this.radio_mudanca_CheckedChanged);
            // 
            // mask_horario_valor1
            // 
            this.mask_horario_valor1.Enabled = false;
            this.mask_horario_valor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask_horario_valor1.Location = new System.Drawing.Point(1570, 107);
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
            this.mask_horario_valor2.Location = new System.Drawing.Point(1715, 107);
            this.mask_horario_valor2.Mask = "00:00";
            this.mask_horario_valor2.Name = "mask_horario_valor2";
            this.mask_horario_valor2.Size = new System.Drawing.Size(69, 30);
            this.mask_horario_valor2.TabIndex = 276;
            this.mask_horario_valor2.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1538, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 17);
            this.label11.TabIndex = 277;
            this.label11.Text = "De";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1667, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 278;
            this.label12.Text = "Até";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1374, 117);
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
            this.mask_data_valor1.Location = new System.Drawing.Point(1539, 166);
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
            this.label14.Location = new System.Drawing.Point(1361, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 17);
            this.label14.TabIndex = 281;
            this.label14.Text = "Pesquisar por data";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1506, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 17);
            this.label15.TabIndex = 282;
            this.label15.Text = "De";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1647, 172);
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
            this.mask_data_valor2.Location = new System.Drawing.Point(1683, 163);
            this.mask_data_valor2.Margin = new System.Windows.Forms.Padding(4);
            this.mask_data_valor2.Mask = "00/00/0000";
            this.mask_data_valor2.Name = "mask_data_valor2";
            this.mask_data_valor2.RejectInputOnFirstFailure = true;
            this.mask_data_valor2.Size = new System.Drawing.Size(101, 29);
            this.mask_data_valor2.TabIndex = 284;
            this.mask_data_valor2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // check_horario_celula
            // 
            this.check_horario_celula.AutoSize = true;
            this.check_horario_celula.Enabled = false;
            this.check_horario_celula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_horario_celula.Location = new System.Drawing.Point(917, 158);
            this.check_horario_celula.Name = "check_horario_celula";
            this.check_horario_celula.Size = new System.Drawing.Size(302, 29);
            this.check_horario_celula.TabIndex = 285;
            this.check_horario_celula.Text = "Pesquisar por horario da celula";
            this.check_horario_celula.UseVisualStyleBackColor = true;
            this.check_horario_celula.CheckedChanged += new System.EventHandler(this.check_horario_celula_CheckedChanged);
            // 
            // check_horario_reuniao
            // 
            this.check_horario_reuniao.AutoSize = true;
            this.check_horario_reuniao.Enabled = false;
            this.check_horario_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_horario_reuniao.Location = new System.Drawing.Point(917, 193);
            this.check_horario_reuniao.Name = "check_horario_reuniao";
            this.check_horario_reuniao.Size = new System.Drawing.Size(392, 29);
            this.check_horario_reuniao.TabIndex = 286;
            this.check_horario_reuniao.Text = "Pesquisar por horario de inicio de reunião";
            this.check_horario_reuniao.UseVisualStyleBackColor = true;
            this.check_horario_reuniao.CheckedChanged += new System.EventHandler(this.check_horario_reuniao_CheckedChanged);
            // 
            // check_horario_final_reuniao
            // 
            this.check_horario_final_reuniao.AutoSize = true;
            this.check_horario_final_reuniao.Enabled = false;
            this.check_horario_final_reuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_horario_final_reuniao.Location = new System.Drawing.Point(917, 229);
            this.check_horario_final_reuniao.Name = "check_horario_final_reuniao";
            this.check_horario_final_reuniao.Size = new System.Drawing.Size(356, 29);
            this.check_horario_final_reuniao.TabIndex = 287;
            this.check_horario_final_reuniao.Text = "Pesquisar por horario final de reunião";
            this.check_horario_final_reuniao.UseVisualStyleBackColor = true;
            this.check_horario_final_reuniao.CheckedChanged += new System.EventHandler(this.check_horario_final_reuniao_CheckedChanged);
            // 
            // check_data_mudanca_estado
            // 
            this.check_data_mudanca_estado.AutoSize = true;
            this.check_data_mudanca_estado.Enabled = false;
            this.check_data_mudanca_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_data_mudanca_estado.Location = new System.Drawing.Point(917, 90);
            this.check_data_mudanca_estado.Name = "check_data_mudanca_estado";
            this.check_data_mudanca_estado.Size = new System.Drawing.Size(401, 29);
            this.check_data_mudanca_estado.TabIndex = 288;
            this.check_data_mudanca_estado.Text = "Pesquisar por data da mudança de estado";
            this.check_data_mudanca_estado.UseVisualStyleBackColor = true;
            this.check_data_mudanca_estado.CheckedChanged += new System.EventHandler(this.check_data_mudanca_estado_CheckedChanged);
            // 
            // txt_comando
            // 
            this.txt_comando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_comando.Location = new System.Drawing.Point(1310, 305);
            this.txt_comando.Multiline = true;
            this.txt_comando.Name = "txt_comando";
            this.txt_comando.ReadOnly = true;
            this.txt_comando.Size = new System.Drawing.Size(504, 322);
            this.txt_comando.TabIndex = 289;
            this.txt_comando.Text = "Restrições";
            this.txt_comando.TextChanged += new System.EventHandler(this.txt_comando_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1670, 233);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 46);
            this.btnAdd.TabIndex = 290;
            this.btnAdd.Text = "Adicionar Restrição";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Pesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 819);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txt_comando);
            this.Controls.Add(this.check_data_mudanca_estado);
            this.Controls.Add(this.check_horario_final_reuniao);
            this.Controls.Add(this.check_horario_reuniao);
            this.Controls.Add(this.check_horario_celula);
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
            this.Controls.Add(this.radio_mudanca);
            this.Controls.Add(this.radio_endereco);
            this.Controls.Add(this.radio_telefone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pesquisa_numero2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_pesquisa_numero1);
            this.Controls.Add(this.btn_todos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_numeros_restricao);
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
        private System.Windows.Forms.TextBox txt_numeros_restricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_todos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pesquisa_numero1;
        private System.Windows.Forms.TextBox txt_pesquisa_numero2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radio_telefone;
        private System.Windows.Forms.RadioButton radio_endereco;
        private System.Windows.Forms.RadioButton radio_mudanca;
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
        private System.Windows.Forms.CheckBox check_horario_celula;
        private System.Windows.Forms.CheckBox check_horario_reuniao;
        private System.Windows.Forms.CheckBox check_horario_final_reuniao;
        private System.Windows.Forms.CheckBox check_data_mudanca_estado;
        private System.Windows.Forms.TextBox txt_comando;
        private System.Windows.Forms.Button btnAdd;
    }
}