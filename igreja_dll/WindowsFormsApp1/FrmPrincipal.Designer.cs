namespace WindowsFormsApp1
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaFinanceiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esboçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaDeEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_horario = new System.Windows.Forms.Label();
            this.Principal = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1515, 558);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.sistemaFinanceiroToolStripMenuItem,
            this.esboçoToolStripMenuItem,
            this.sistemaDeEmailToolStripMenuItem,
            this.configuraçãoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1518, 36);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileMenu
            // 
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(355, 32);
            this.fileMenu.Text = "Sistema de gerenciamento de pessoas";
            this.fileMenu.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // sistemaFinanceiroToolStripMenuItem
            // 
            this.sistemaFinanceiroToolStripMenuItem.Name = "sistemaFinanceiroToolStripMenuItem";
            this.sistemaFinanceiroToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.sistemaFinanceiroToolStripMenuItem.Text = "Sistema Financeiro";
            this.sistemaFinanceiroToolStripMenuItem.Click += new System.EventHandler(this.sistemaFinanceiroToolStripMenuItem_Click);
            // 
            // esboçoToolStripMenuItem
            // 
            this.esboçoToolStripMenuItem.Name = "esboçoToolStripMenuItem";
            this.esboçoToolStripMenuItem.Size = new System.Drawing.Size(87, 32);
            this.esboçoToolStripMenuItem.Text = "Esboço";
            this.esboçoToolStripMenuItem.Click += new System.EventHandler(this.esboçoToolStripMenuItem_Click);
            // 
            // sistemaDeEmailToolStripMenuItem
            // 
            this.sistemaDeEmailToolStripMenuItem.Name = "sistemaDeEmailToolStripMenuItem";
            this.sistemaDeEmailToolStripMenuItem.Size = new System.Drawing.Size(179, 32);
            this.sistemaDeEmailToolStripMenuItem.Text = "Sistema de e-mail";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(908, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Horario: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(449, 614);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(444, 30);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lbl_horario
            // 
            this.lbl_horario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_horario.AutoSize = true;
            this.lbl_horario.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_horario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_horario.Location = new System.Drawing.Point(1033, 613);
            this.lbl_horario.Name = "lbl_horario";
            this.lbl_horario.Size = new System.Drawing.Size(0, 29);
            this.lbl_horario.TabIndex = 8;
            // 
            // Principal
            // 
            this.Principal.Enabled = true;
            this.Principal.Interval = 60000;
            this.Principal.Tick += new System.EventHandler(this.Principal_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PIB Cataguases";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(141, 32);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1518, 690);
            this.Controls.Add(this.lbl_horario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.Text = "Sistema Igreja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbl_horario;
        private System.Windows.Forms.Timer Principal;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem sistemaFinanceiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esboçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaDeEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
    }
}