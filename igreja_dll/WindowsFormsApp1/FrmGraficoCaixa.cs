using business.Classe;
using business.Classe.financeiro;
using business.classes.financeiro;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class FrmGraficoCaixa : Form
    {
        public FrmGraficoCaixa()
        {
            InitializeComponent();
        }

        private void FrmGraficoCaixa_Load(object sender, EventArgs e)
        {
            chart1.Legends.Clear();
            chart1.Series.Clear();

            Legend legenda = new Legend();
            chart1.Legends.Add(legenda);
            chart1.Legends[0].Title = "Legenda";
            chart1.Legends[0].Font = new Font("Arial", 14, FontStyle.Bold);
            chart1.Legends[0].BackColor = Color.Aqua;

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Dia do mês "
                + dateEscolhida.Value.ToString("dd/MM/yyyy");
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Dinheiro (R$)";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].BackColor = Color.Transparent;


            chart1.ChartAreas.Add("ChartArea2");
            chart1.ChartAreas["ChartArea2"].AxisX.Title = "Ano - " + dateEscolhida.Value.Year.ToString();
            chart1.ChartAreas["ChartArea2"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea2"].AxisY.Title = "Dinheiro (R$)";
            chart1.ChartAreas["ChartArea2"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea2"].BackColor = Color.Transparent;

            chart1.ChartAreas.Add("ChartArea3");
            chart1.ChartAreas["ChartArea3"].AxisX.Title = "Mês - " + dateEscolhida.Value.Month.ToString();
            chart1.ChartAreas["ChartArea3"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea3"].AxisY.Title = "Dinheiro (R$)";
            chart1.ChartAreas["ChartArea3"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas["ChartArea3"].BackColor = Color.Transparent;

            Title title1 = new Title();
            title1.Text = "Gráfico Caixa diario";
            title1.DockedToChartArea = "ChartArea1";
            title1.IsDockedInsideChartArea = false;
            title1.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title1);

            Title title2 = new Title();
            title2.Text = "Gráfico Caixa Anual";
            title2.DockedToChartArea = "ChartArea2";
            title2.IsDockedInsideChartArea = false;
            title2.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title2);

            Title title3 = new Title();
            title3.Text = "Gráfico Caixa Mensal";
            title3.DockedToChartArea = "ChartArea3";
            title3.IsDockedInsideChartArea = false;
            title3.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title3);

            // remove grades verticais
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
            chart1.ChartAreas[1].AxisX.MajorGrid.LineWidth = 2;
            chart1.ChartAreas[2].AxisX.MajorGrid.LineWidth = 2;

            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisY.Maximum = 5000;
            chart1.ChartAreas[0].AxisY.Minimum = -5000;
            chart1.ChartAreas[0].AxisY.Interval = 1000;

            chart1.Series.Add("Caixa");
            chart1.Series["Caixa"].LegendText = "Valor Caixa diario";
            chart1.Series["Caixa"].ChartType = SeriesChartType.Column;
            chart1.Series["Caixa"].BorderWidth = 1;
            chart1.Series["Caixa"].ChartArea = "ChartArea1";

            chart1.ChartAreas[1].AxisX.Interval = 2;
            chart1.ChartAreas[1].AxisY.Maximum = 10000;
            chart1.ChartAreas[1].AxisY.Minimum = -10000;
            chart1.ChartAreas[1].AxisY.Interval = 1000;

            chart1.Series.Add("CaixaAnual");
            chart1.Series["CaixaAnual"].LegendText = "Valor Caixa anual";
            chart1.Series["CaixaAnual"].ChartType = SeriesChartType.Column;
            chart1.Series["CaixaAnual"].BorderWidth = 1;
            chart1.Series["CaixaAnual"].ChartArea = "ChartArea2";

            chart1.ChartAreas[2].AxisY.Maximum = 20000;
            chart1.ChartAreas[2].AxisY.Minimum = -20000;
            chart1.ChartAreas[2].AxisY.Interval = 4000;
            chart1.ChartAreas[2].AxisX.Interval = 2;
            chart1.ChartAreas[2].AxisX.Maximum = 32;
            chart1.ChartAreas[2].AxisX.Minimum = 1;
            chart1.ChartAreas[2].AxisX.Interval = 5;

            chart1.Series.Add("CaixaMensal");
            chart1.Series["CaixaMensal"].LegendText = "Valor Caixa Mensal";
            chart1.Series["CaixaMensal"].ChartType = SeriesChartType.Column;
            chart1.Series["CaixaMensal"].BorderWidth = 1;
            chart1.Series["CaixaMensal"].ChartArea = "ChartArea3";
        }

        private void dateEscolhida_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["Caixa"].Points.Clear();
            chart1.Series["CaixaMensal"].Points.Clear();
            chart1.Series["CaixaAnual"].Points.Clear();

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Dia do mês";

            chart1.ChartAreas["ChartArea2"].AxisX.Title = "Ano - " + dateEscolhida.Value.Year.ToString();

            chart1.ChartAreas["ChartArea3"].AxisX.Title = "Mês - " + dateEscolhida.Value.Month.ToString();

            AddPoint();
        }

        private void AddPoint()
        {
            var me = modelocrud.Modelos.OfType<MovimentacaoEntrada>()
                            .Where(m => m.Data.ToString("dd/MM/yyyy") == dateEscolhida.Value.ToString("dd/MM/yyyy"));
            var ms = modelocrud.Modelos.OfType<MovimentacaoSaida>()
                            .Where(m => m.Data.ToString("dd/MM/yyyy") == dateEscolhida.Value.ToString("dd/MM/yyyy"));

            double valorME = 0;
            double valorMS = 0;

            foreach (var item in me)
                valorME += item.Valor;

            foreach (var item in ms)
                valorMS += item.Valor;

            chart1.Series["Caixa"].Points.AddXY(dateEscolhida.Value.Day, valorME - valorMS);

            for (int i = 1; i <= 12; i++)
            {
                double valorMovE = 0;
                double valorMovS = 0;
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoEntrada>()
                .Where(m => m.Data.Year == dateEscolhida.Value.Year && m.Data.Month == i))
                    valorMovE += item.Valor;

                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoSaida>()
                .Where(m => m.Data.Year == dateEscolhida.Value.Year && m.Data.Month == i))
                    valorMovS += item.Valor;

                string mes = "";

                if (i == 1)  mes =  "Janeiro"  ;
                if (i == 2)  mes =  "Fevereiro";
                if (i == 3)  mes =  "Março"    ;
                if (i == 4)  mes =  "Abril"    ;
                if (i == 5)  mes =  "Maio"     ;
                if (i == 6)  mes =  "Junho"    ;
                if (i == 7)  mes =  "Julho"    ;
                if (i == 8)  mes =  "Agosto"   ;
                if (i == 9)  mes =  "Setembro" ;
                if (i == 10) mes =  "Outubro"  ;
                if (i == 11) mes =  "Novembro" ;
                if (i == 12) mes =  "Dezembro" ;

                if (i == 1) chart1.Series ["CaixaAnual"].Points.AddXY(mes, valorMovE - valorMovS);

            }
            
            double valorCaixaME = 0;
            double valorCaixaMS = 0;
            DateTime data = DateTime.Now;

            for (int i = 1; i <= 31; i++)
            {
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoEntrada>()
                .Where(m => m.Data.ToString("dd/MM/yyyy")
                == new DateTime(dateEscolhida.Value.Year, dateEscolhida.Value.Month, i).ToString("dd/MM/yyyy")))
                {
                    valorCaixaME += item.Valor;
                    data = item.Data;
                }

                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoSaida>()
                .Where(m => m.Data.ToString("dd/MM/yyyy")
                == new DateTime(dateEscolhida.Value.Year, dateEscolhida.Value.Month, i).ToString("dd/MM/yyyy")))
                {
                    valorCaixaMS += item.Valor;
                    data = item.Data;
                }
                chart1.Series["CaixaMensal"].Points.AddXY(data.Day, valorCaixaME - valorCaixaMS);
            }
        }

        private void checkEnable3D_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnable3D.Checked)
            {
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart1.ChartAreas[1].Area3DStyle.Enable3D = true;
                chart1.ChartAreas[2].Area3DStyle.Enable3D = true;
            }
            else
            {
                chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
                chart1.ChartAreas[1].Area3DStyle.Enable3D = false;
                chart1.ChartAreas[2].Area3DStyle.Enable3D = false;

            }
        }

        private void numericGrau_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].Area3DStyle.Rotation = (int)numericGrau.Value;
            chart1.ChartAreas[1].Area3DStyle.Rotation = (int)numericGrau.Value;
            chart1.ChartAreas[2].Area3DStyle.Rotation = (int)numericGrau.Value;
        }
    }
}
