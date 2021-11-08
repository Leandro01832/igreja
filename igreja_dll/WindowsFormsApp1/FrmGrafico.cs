using business.Classe;
using business.Classe.financeiro;
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
    public partial class FrmGrafico : Form
    {
        public FrmGrafico()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGrafico_Load(object sender, EventArgs e)
        {
            chart1.Legends.Clear();
            chart1.Series.Clear();

            Legend legenda = new Legend();
            chart1.Legends.Add(legenda);
            chart1.Legends[0].Title = "Legenda";
            chart1.Legends[0].Font = new Font("Arial", 14, FontStyle.Bold);
            chart1.Legends[0].BackColor = Color.Aqua;
            
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Identificação da movimentação - "
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
            title1.Text = "Gráfico diario";
            title1.DockedToChartArea = "ChartArea1";
            title1.IsDockedInsideChartArea = false;
            title1.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title1);

            Title title2 = new Title();
            title2.Text = "Gráfico Anual";
            title2.DockedToChartArea = "ChartArea2";
            title2.IsDockedInsideChartArea = false;
            title2.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title2);

            Title title3 = new Title();
            title3.Text = "Gráfico Mensal";
            title3.DockedToChartArea = "ChartArea3";
            title3.IsDockedInsideChartArea = false;
            title3.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(title3);

            // remove grades verticais
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
             chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
             chart1.ChartAreas[1].AxisX.MajorGrid.LineWidth = 2;
             chart1.ChartAreas[2].AxisX.MajorGrid.LineWidth = 2;            

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Maximum = 5000;
            chart1.ChartAreas[0].AxisY.Interval = 500;

            chart1.Series.Add("MovimentoEntrada");
            chart1.Series["MovimentoEntrada"].LegendText = "Movimento de entrada diaria";
            chart1.Series["MovimentoEntrada"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoEntrada"].BorderWidth = 1;
            chart1.Series["MovimentoEntrada"].ChartArea = "ChartArea1";

            chart1.Series.Add("MovimentoSaida");
            chart1.Series["MovimentoSaida"].LegendText = "Movimento de saída diaria";
            chart1.Series["MovimentoSaida"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoSaida"].BorderWidth = 1;
            chart1.Series["MovimentoSaida"].ChartArea = "ChartArea1";

            chart1.Series.Add("MovimentoEntradaAnual");
            chart1.Series["MovimentoEntradaAnual"].LegendText = "Movimento de entrada Anual";
            chart1.Series["MovimentoEntradaAnual"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoEntradaAnual"].BorderWidth = 1;
            chart1.Series["MovimentoEntradaAnual"].ChartArea = "ChartArea2";

            chart1.ChartAreas[1].AxisX.Interval = 2;
            chart1.ChartAreas[1].AxisY.Maximum = 100000;
            chart1.ChartAreas[1].AxisY.Interval = 10000;              

            chart1.Series.Add("MovimentoSaidaAnual");
            chart1.Series["MovimentoSaidaAnual"].LegendText = "Movimento de saida anual";
            chart1.Series["MovimentoSaidaAnual"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoSaidaAnual"].BorderWidth = 1;
            chart1.Series["MovimentoSaidaAnual"].ChartArea = "ChartArea2";

            chart1.ChartAreas[2].AxisY.Maximum = 20000;
            chart1.ChartAreas[2].AxisY.Interval = 2000;
            chart1.ChartAreas[2].AxisX.Interval = 2;
            chart1.ChartAreas[2].AxisX.Maximum = 32;
            chart1.ChartAreas[2].AxisX.Minimum = 1;
            chart1.ChartAreas[2].AxisX.Interval = 5;

            chart1.Series.Add("MovimentoSaidaMensal");
            chart1.Series["MovimentoSaidaMensal"].LegendText = "Movimento de saida Mensal";
            chart1.Series["MovimentoSaidaMensal"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoSaidaMensal"].BorderWidth = 1;
            chart1.Series["MovimentoSaidaMensal"].ChartArea = "ChartArea3";

            chart1.Series.Add("MovimentoEntradaMensal");
            chart1.Series["MovimentoEntradaMensal"].LegendText = "Movimento de entrada Mensal";
            chart1.Series["MovimentoEntradaMensal"].ChartType = SeriesChartType.Column;
            chart1.Series["MovimentoEntradaMensal"].BorderWidth = 1;
            chart1.Series["MovimentoEntradaMensal"].ChartArea = "ChartArea3";

            AddPoint();
        }        

        private void dateEscolhida_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["MovimentoSaida"].Points.Clear();
            chart1.Series["MovimentoEntrada"].Points.Clear();

            chart1.Series["MovimentoSaidaMensal"].Points.Clear();
            chart1.Series["MovimentoEntradaMensal"].Points.Clear();

            chart1.Series["MovimentoSaidaAnual"].Points.Clear();
            chart1.Series["MovimentoEntradaAnual"].Points.Clear();

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Identificação da movimentação - "
                + dateEscolhida.Value.ToString("dd/MM/yyyy");

            chart1.ChartAreas["ChartArea2"].AxisX.Title = "Ano - " + dateEscolhida.Value.Year.ToString();

            chart1.ChartAreas["ChartArea3"].AxisX.Title = "Mês - " + dateEscolhida.Value.Month.ToString();

            AddPoint();
        }

        private void AddPoint()
        {
            var me = modelocrud.Modelos.OfType<MovimentacaoEntrada>()
            .Where(m => m.Data.Day == dateEscolhida.Value.Day &&
            m.Data.Month == dateEscolhida.Value.Month &&
            m.Data.Year == dateEscolhida.Value.Year).ToList();

            var ms = modelocrud.Modelos.OfType<MovimentacaoSaida>()
            .Where(m => m.Data.Day == dateEscolhida.Value.Day &&
            m.Data.Month == dateEscolhida.Value.Month &&
            m.Data.Year == dateEscolhida.Value.Year).ToList();

            //bool existeMovimentacaoEntrada = me.FirstOrDefault() != null;
            //bool existeMovimentacaoSaida = ms.FirstOrDefault() != null;

            //if (existeMovimentacaoEntrada && existeMovimentacaoSaida)
            //{
            //    int numMenor = 0;
            //    if (me.First().Id < ms.First().Id) numMenor = me.First().Id; else numMenor = ms.First().Id;

            //    chart1.ChartAreas[0].AxisX.Maximum = numMenor + me.Count() + ms.Count();
            //    chart1.ChartAreas[0].AxisX.Minimum = numMenor;
            //}


            foreach (var item in me)
            {
                chart1.Series["MovimentoEntrada"].Points.AddXY( item.Id.ToString(), item.Valor);
            }


            foreach (var item in ms)
            {
                chart1.Series["MovimentoSaida"].Points.AddXY( item.Id.ToString(), item.Valor);
            }            

            for (int i = 1; i <= 12; i++)
            {
                double valor = 0;
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoEntrada>()
                .Where(m => m.Data.Year == dateEscolhida.Value.Year && m.Data.Month == i))
                    valor += item.Valor;

                if (i == 1) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Janeiro", valor);
                if (i == 2) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Fevereiro", valor);
                if (i == 3) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Março", valor);
                if (i == 4) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Abril", valor);
                if (i == 5) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Maio", valor);
                if (i == 6) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Junho", valor);
                if (i == 7) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Julho", valor);
                if (i == 8) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Agosto", valor);
                if (i == 9) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Setembro", valor);
                if (i == 10) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Outubro", valor);
                if (i == 11) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Novembro", valor);
                if (i == 12) chart1.Series["MovimentoEntradaAnual"].Points.AddXY("Dezembro", valor);
            }

            for (int i = 1; i <= 12; i++)
            {
                double valor = 0;
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoSaida>()
                .Where(m => m.Data.Year == dateEscolhida.Value.Year && m.Data.Month == i))
                    valor += item.Valor;

                if (i == 1) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Janeiro", valor);
                if (i == 2) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Fevereiro", valor);
                if (i == 3) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Março", valor);
                if (i == 4) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Abril", valor);
                if (i == 5) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Maio", valor);
                if (i == 6) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Junho", valor);
                if (i == 7) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Julho", valor);
                if (i == 8) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Agosto", valor);
                if (i == 9) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Setembro", valor);
                if (i == 10) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Outubro", valor);
                if (i == 11) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Novembro", valor);
                if (i == 12) chart1.Series["MovimentoSaidaAnual"].Points.AddXY("Dezembro", valor);
            }

            double valorEntrada = 0;
            double valorSaida = 0;
            DateTime data = DateTime.Now;

            for (int i = 1; i <= 28; i++)
            {
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoSaida>()
                .Where(m => m.Data.ToString("dd/MM/yyyy")
                == new DateTime(dateEscolhida.Value.Year, dateEscolhida.Value.Month, i).ToString("dd/MM/yyyy")))
                {
                    valorSaida += item.Valor;
                    data = item.Data;
                }
                chart1.Series["MovimentoSaidaMensal"].Points.AddXY(data.Day, valorSaida);
            }


            for (int i = 1; i <= 28; i++)
            {
                foreach (var item in modelocrud.Modelos.OfType<MovimentacaoEntrada>()
                .Where(m => m.Data.ToString("dd/MM/yyyy")
                == new DateTime(dateEscolhida.Value.Year, dateEscolhida.Value.Month, i).ToString("dd/MM/yyyy")))
                {
                    valorEntrada += item.Valor;
                    data = item.Data;
                }
                chart1.Series["MovimentoEntradaMensal"].Points.AddXY(data.Day, valorEntrada);
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

        private void btnDescrimina_Click(object sender, EventArgs e)
        {
            var lista = modelocrud.Modelos.OfType<Movimentacao>()
                .Where(m => m.Data.ToString("dd/MM/yyyy") == dateEscolhida.Value.ToString("dd/MM/yyyy")).ToList();
            FrmDescrimina frm = new FrmDescrimina(lista, dateEscolhida.Value);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
