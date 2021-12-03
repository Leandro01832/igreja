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
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdados
            // 
            this.dgdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdados.Location = new System.Drawing.Point(12, 12);
            this.dgdados.Name = "dgdados";
            this.dgdados.RowTemplate.Height = 24;
            this.dgdados.Size = new System.Drawing.Size(1467, 786);
            this.dgdados.TabIndex = 6;
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesquisar.Location = new System.Drawing.Point(1603, 495);
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
            this.btn_todos.Location = new System.Drawing.Point(1521, 408);
            this.btn_todos.Name = "btn_todos";
            this.btn_todos.Size = new System.Drawing.Size(245, 60);
            this.btn_todos.TabIndex = 21;
            this.btn_todos.Text = "Remover filtro";
            this.btn_todos.UseVisualStyleBackColor = true;
            this.btn_todos.Click += new System.EventHandler(this.btn_todos_Click);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltro.Location = new System.Drawing.Point(1521, 324);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(245, 60);
            this.btnFiltro.TabIndex = 290;
            this.btnFiltro.Text = "Aplicar filtro";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // Pesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 819);
            this.Controls.Add(this.btnFiltro);
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

        }

        #endregion
        private System.Windows.Forms.DataGridView dgdados;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.Button btn_todos;
        private System.Windows.Forms.Button btnFiltro;
    }
}