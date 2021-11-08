namespace WindowsFormsApp1
{
    partial class FrmGrafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn1 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn2 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem3 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem4 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem5 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn3 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn4 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem6 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem7 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem8 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem9 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem10 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateEscolhida = new System.Windows.Forms.DateTimePicker();
            this.checkEnable3D = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericGrau = new System.Windows.Forms.NumericUpDown();
            this.btnDescrimina = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrau)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Gray;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameTitle1;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legendCellColumn1.BackColor = System.Drawing.Color.DarkSalmon;
            legendCellColumn1.ColumnType = System.Windows.Forms.DataVisualization.Charting.LegendCellColumnType.SeriesSymbol;
            legendCellColumn1.ForeColor = System.Drawing.Color.Transparent;
            legendCellColumn1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            legendCellColumn1.HeaderForeColor = System.Drawing.Color.Maroon;
            legendCellColumn1.HeaderText = "Cor";
            legendCellColumn1.Name = "Column1";
            legendCellColumn1.Text = "#leo2";
            legendCellColumn2.BackColor = System.Drawing.Color.DarkSalmon;
            legendCellColumn2.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            legendCellColumn2.HeaderForeColor = System.Drawing.Color.Maroon;
            legendCellColumn2.HeaderText = "Classe";
            legendCellColumn2.Name = "Column2";
            legend1.CellColumns.Add(legendCellColumn1);
            legend1.CellColumns.Add(legendCellColumn2);
            legendItem1.Color = System.Drawing.Color.Red;
            legendItem1.Name = "Bazar";
            legendItem2.Color = System.Drawing.Color.Yellow;
            legendItem2.Name = "Lava-Rápido";
            legendItem3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            legendItem3.Name = "Dízimo";
            legendItem4.Color = System.Drawing.Color.Navy;
            legendItem4.Name = "Oferta";
            legendItem5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            legendItem5.Name = "Cantina";
            legend1.CustomItems.Add(legendItem1);
            legend1.CustomItems.Add(legendItem2);
            legend1.CustomItems.Add(legendItem3);
            legend1.CustomItems.Add(legendItem4);
            legend1.CustomItems.Add(legendItem5);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsDockedInsideChartArea = false;
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Title = "Movimentação de entrada";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legendCellColumn3.BackColor = System.Drawing.Color.DarkSalmon;
            legendCellColumn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legendCellColumn3.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            legendCellColumn3.HeaderForeColor = System.Drawing.Color.Maroon;
            legendCellColumn3.HeaderText = "Cor";
            legendCellColumn3.Name = "Column1";
            legendCellColumn3.Text = "#leo";
            legendCellColumn4.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCellColumn4.BackColor = System.Drawing.Color.DarkSalmon;
            legendCellColumn4.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            legendCellColumn4.HeaderForeColor = System.Drawing.Color.Maroon;
            legendCellColumn4.HeaderText = "Classe";
            legendCellColumn4.Name = "Column2";
            legend2.CellColumns.Add(legendCellColumn3);
            legend2.CellColumns.Add(legendCellColumn4);
            legendItem6.Color = System.Drawing.Color.Red;
            legendItem6.Name = "Aluguel";
            legendItem7.Color = System.Drawing.Color.Yellow;
            legendItem7.Name = "Transação";
            legendItem8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            legendItem8.Name = "Transporte";
            legendItem9.Color = System.Drawing.Color.Navy;
            legendItem9.Name = "Compra";
            legendItem10.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            legendItem10.Name = "Retiro";
            legend2.CustomItems.Add(legendItem6);
            legend2.CustomItems.Add(legendItem7);
            legend2.CustomItems.Add(legendItem8);
            legend2.CustomItems.Add(legendItem9);
            legend2.CustomItems.Add(legendItem10);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.HeaderSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.DashLine;
            legend2.HeaderSeparatorColor = System.Drawing.Color.Silver;
            legend2.IsDockedInsideChartArea = false;
            legend2.IsEquallySpacedItems = true;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend2";
            legend2.Title = "Movimentação de saída";
            legend2.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            this.chart1.Legends.Add(legend1);
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.LegendText = "...";
            series1.Name = "Series1";
            series1.XValueMember = "Data";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "Valor";
            series1.YValuesPerPoint = 3;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend2";
            series2.LegendText = "...";
            series2.Name = "Series2";
            series2.XValueMember = "Data";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Valor";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1496, 679);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Gráfico de movimentação";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dateEscolhida
            // 
            this.dateEscolhida.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEscolhida.Location = new System.Drawing.Point(0, 0);
            this.dateEscolhida.Name = "dateEscolhida";
            this.dateEscolhida.Size = new System.Drawing.Size(287, 22);
            this.dateEscolhida.TabIndex = 1;
            this.dateEscolhida.ValueChanged += new System.EventHandler(this.dateEscolhida_ValueChanged);
            // 
            // checkEnable3D
            // 
            this.checkEnable3D.AutoSize = true;
            this.checkEnable3D.Location = new System.Drawing.Point(304, 0);
            this.checkEnable3D.Name = "checkEnable3D";
            this.checkEnable3D.Size = new System.Drawing.Size(88, 21);
            this.checkEnable3D.TabIndex = 2;
            this.checkEnable3D.Text = "Ativar 3D";
            this.checkEnable3D.UseVisualStyleBackColor = true;
            this.checkEnable3D.CheckedChanged += new System.EventHandler(this.checkEnable3D_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grau";
            // 
            // numericGrau
            // 
            this.numericGrau.Location = new System.Drawing.Point(464, 3);
            this.numericGrau.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericGrau.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericGrau.Name = "numericGrau";
            this.numericGrau.Size = new System.Drawing.Size(82, 22);
            this.numericGrau.TabIndex = 5;
            this.numericGrau.ValueChanged += new System.EventHandler(this.numericGrau_ValueChanged);
            // 
            // btnDescrimina
            // 
            this.btnDescrimina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescrimina.Location = new System.Drawing.Point(0, 27);
            this.btnDescrimina.Name = "btnDescrimina";
            this.btnDescrimina.Size = new System.Drawing.Size(337, 33);
            this.btnDescrimina.TabIndex = 6;
            this.btnDescrimina.Text = "Descriminar movimentações";
            this.btnDescrimina.UseVisualStyleBackColor = true;
            this.btnDescrimina.Click += new System.EventHandler(this.btnDescrimina_Click);
            // 
            // FrmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 679);
            this.Controls.Add(this.btnDescrimina);
            this.Controls.Add(this.numericGrau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkEnable3D);
            this.Controls.Add(this.dateEscolhida);
            this.Controls.Add(this.chart1);
            this.Name = "FrmGrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGrafico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGrafico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DateTimePicker dateEscolhida;
        private System.Windows.Forms.CheckBox checkEnable3D;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericGrau;
        private System.Windows.Forms.Button btnDescrimina;
    }
}