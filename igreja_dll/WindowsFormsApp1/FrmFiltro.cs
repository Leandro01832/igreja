using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmFiltro : Form
    {
        public FrmFiltro()
        {
            InitializeComponent();
        }

        public FrmFiltro(List<PropertyInfo> props)
        {
            Props = props.Where(p => !p.PropertyType.IsSubclassOf(typeof(modelocrud))
            && p.PropertyType.Name != "List`1").ToList();

            quantNumero = Props.Where(
                        p => p.PropertyType == typeof(int) ||
                         p.PropertyType == typeof(int?) ||
                         p.PropertyType == typeof(decimal) ||
                         p.PropertyType == typeof(decimal?) ||
                         p.PropertyType == typeof(long) ||
                         p.PropertyType == typeof(long?) ||
                         p.PropertyType == typeof(double) ||
                         p.PropertyType == typeof(double?)
                        ).ToList().Count;

            quantData = Props.Where(
                        p => p.PropertyType == typeof(DateTime) ||
                         p.PropertyType == typeof(DateTime?)
                        ).ToList().Count;

            quantHora = Props.Where(
                        p => p.PropertyType == typeof(TimeSpan) ||
                         p.PropertyType == typeof(TimeSpan?)
                        ).ToList().Count;

            quantTexto = Props.Where(
                        p => p.PropertyType == typeof(string)
                        ).ToList().Count;

            quantLabelTexto = Props.Count;

            quantCondicao = Props.Where(
                        p => p.PropertyType == typeof(bool)
                        ).ToList().Count;

            TextBoxNumero = new TextBox[quantNumero * 2];
            for (int i = 0; i < TextBoxNumero.Length; i++)
            {
                TextBoxNumero[i] = new TextBox();
                this.Controls.Add(TextBoxNumero[i]);
            }

            TextBoxData = new MaskedTextBox[quantData * 2];
            for (int i = 0; i < TextBoxData.Length; i++)
            {
                TextBoxData[i] = new MaskedTextBox();
                this.Controls.Add(TextBoxData[i]);
            }

            TextBoxHora = new MaskedTextBox[quantHora * 2];
            for (int i = 0; i < TextBoxHora.Length; i++)
            {
                TextBoxHora[i] = new MaskedTextBox();
                this.Controls.Add(TextBoxHora[i]);
            }

            TextBoxTexto = new TextBox[quantTexto];
            for (int i = 0; i < TextBoxTexto.Length; i++)
            {
                TextBoxTexto[i] = new TextBox();
                this.Controls.Add(TextBoxTexto[i]);
            }

            LabelTexto = new Label[quantLabelTexto];
            for (int i = 0; i < LabelTexto.Length; i++)
            {
                LabelTexto[i] = new Label();
                this.Controls.Add(LabelTexto[i]);
            }

            CheckBoxCondicao = new CheckBox[quantCondicao];
            for (int i = 0; i < CheckBoxCondicao.Length; i++)
            {
                CheckBoxCondicao[i] = new CheckBox();
                this.Controls.Add(CheckBoxCondicao[i]);
            }

            

            InitializeComponent();
        }

        private Point localizacao = new Point(0, 0);

        private List<PropertyInfo> Props { get; }

        private  int quantNumero = 0;
        private  int quantData = 0;
        private  int quantHora = 0;
        private  int quantTexto = 0;
        private  int quantCondicao = 0;
        private  int quantLabelTexto = 0;

        private int arrTextBoxNumero = 0;
        private int arrTextBoxData = 0;
        private int arrTextBoxHora = 0;
        private int arrTextBoxTexto = 0;
        private int arrCheckBoxCondicao = 0;
        private int arrLabelTexto = 0;

       public static TextBox[] TextBoxNumero;
       public static MaskedTextBox[] TextBoxData;
       public static MaskedTextBox[] TextBoxHora;
       public static TextBox[] TextBoxTexto;
       public static Label[] LabelTexto;
       public static CheckBox[] CheckBoxCondicao;
        

        private void FrmFiltro_Load(object sender, EventArgs e)
        {
            


            foreach (var prop in Props)
            {
                if(prop.PropertyType == typeof(int)     || prop.PropertyType == typeof(int?)     ||
                   prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?) ||
                   prop.PropertyType == typeof(long)    || prop.PropertyType == typeof(long?)    ||
                   prop.PropertyType == typeof(double)  || prop.PropertyType == typeof(double?))
                {
                    LabelTexto[arrLabelTexto].Text = $"Pesquisar entre dois numeros {modelocrud.formatarTexto(prop.Name)}: ";
                    LabelTexto[arrLabelTexto].Location = new Point(50, localizacao.Y + 50);
                    LabelTexto[arrLabelTexto].Height = 40;
                    LabelTexto[arrLabelTexto].Width = 200;
                    LabelTexto[arrLabelTexto].Font = new Font("Arial", 11);
                    TextBoxNumero[arrTextBoxNumero].Location = new Point(250, localizacao.Y + 50);
                    TextBoxNumero[arrTextBoxNumero].Name = prop.Name;
                    TextBoxNumero[arrTextBoxNumero].Font = new Font("Arial", 12);
                    TextBoxNumero[arrTextBoxNumero].Width = 100;
                    arrTextBoxNumero++;
                    TextBoxNumero[arrTextBoxNumero].Location = new Point(400, localizacao.Y + 50);
                    TextBoxNumero[arrTextBoxNumero].Name = prop.Name + "campo2";                    
                    TextBoxNumero[arrTextBoxNumero].Font = new Font("Arial", 12);
                    TextBoxNumero[arrTextBoxNumero].Width = 100;
                    localizacao = TextBoxNumero[arrTextBoxNumero].Location;
                    arrTextBoxNumero++;
                }

                if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                {
                    LabelTexto[arrLabelTexto].Text = $"Pesquisar entre duas datas {modelocrud.formatarTexto(prop.Name)}: ";
                    LabelTexto[arrLabelTexto].Location = new Point(50, localizacao.Y + 50);
                    LabelTexto[arrLabelTexto].Height = 40;
                    LabelTexto[arrLabelTexto].Width = 200;
                    LabelTexto[arrLabelTexto].Font = new Font("Arial", 11);
                    TextBoxData[arrTextBoxData].Location = new Point(250,  localizacao.Y + 50);
                    TextBoxData[arrTextBoxData].Name = prop.Name;
                    TextBoxData[arrTextBoxData].Mask = "00/00/0000";
                    TextBoxData[arrTextBoxData].Font = new Font("Arial", 12);
                    TextBoxData[arrTextBoxData].Width = 100;
                    arrTextBoxData++;
                    TextBoxData[arrTextBoxData].Location = new Point(400,  localizacao.Y + 50);
                    TextBoxData[arrTextBoxData].Name = prop.Name + "campo2";
                    TextBoxData[arrTextBoxData].Mask = "00/00/0000";
                    TextBoxData[arrTextBoxData].Font = new Font("Arial", 12);
                    TextBoxData[arrTextBoxData].Width = 100;
                    localizacao = TextBoxData[arrTextBoxData].Location;
                    arrTextBoxData++;
                }

                if (prop.PropertyType == typeof(TimeSpan) || prop.PropertyType == typeof(TimeSpan?))
                {
                    LabelTexto[arrLabelTexto].Text = $"Pesquisar entre dois horários {modelocrud.formatarTexto(prop.Name)}: ";
                    LabelTexto[arrLabelTexto].Location = new Point(50, localizacao.Y + 50);
                    LabelTexto[arrLabelTexto].Height = 40;
                    LabelTexto[arrLabelTexto].Width = 200;
                    LabelTexto[arrLabelTexto].Font = new Font("Arial", 11);
                    TextBoxHora[arrTextBoxHora].Location = new Point(250,  localizacao.Y + 50);
                    TextBoxHora[arrTextBoxHora].Name = prop.Name;
                    TextBoxHora[arrTextBoxHora].Mask = "00:00";
                    TextBoxHora[arrTextBoxHora].Font = new Font("Arial", 12);
                    TextBoxHora[arrTextBoxHora].Width = 100;
                    arrTextBoxHora++;
                    TextBoxHora[arrTextBoxHora].Location = new Point(400,  localizacao.Y);
                    TextBoxHora[arrTextBoxHora].Name = prop.Name + "campo2";
                    TextBoxHora[arrTextBoxHora].Mask = "00:00";
                    TextBoxHora[arrTextBoxHora].Font = new Font("Arial", 12);
                    TextBoxHora[arrTextBoxHora].Width = 100;
                    localizacao = TextBoxHora[arrTextBoxHora].Location;
                    arrTextBoxHora++;
                }

                if (prop.PropertyType == typeof(string))
                {
                    LabelTexto[arrLabelTexto].Text = $"Pesquisar por texto {modelocrud.formatarTexto(prop.Name)}: ";
                    LabelTexto[arrLabelTexto].Location = new Point( 50, localizacao.Y + 50);
                    LabelTexto[arrLabelTexto].Height = 40;
                    LabelTexto[arrLabelTexto].Width = 200;
                    LabelTexto[arrLabelTexto].Font = new Font("Arial", 11);
                    TextBoxTexto[arrTextBoxTexto].Location = new Point(250, localizacao.Y + 50);
                    TextBoxTexto[arrTextBoxTexto].Name = prop.Name;
                    TextBoxTexto[arrTextBoxTexto].Width = 200;
                    TextBoxTexto[arrTextBoxTexto].Font = new Font("Arial", 12);
                    localizacao = TextBoxTexto[arrTextBoxTexto].Location;
                    arrTextBoxTexto++;
                }

                if (prop.PropertyType == typeof(bool))
                {
                    LabelTexto[arrLabelTexto].Text = $" Pesquisar por condição: ";
                    LabelTexto[arrLabelTexto].Location = new Point(50, localizacao.Y + 50);
                    LabelTexto[arrLabelTexto].Height = 40;
                    LabelTexto[arrLabelTexto].Width = 200;
                    LabelTexto[arrLabelTexto].Font = new Font("Arial", 11);
                    CheckBoxCondicao[arrCheckBoxCondicao].Location = new Point(250, localizacao.Y + 50);
                    CheckBoxCondicao[arrCheckBoxCondicao].Name = prop.Name;
                    CheckBoxCondicao[arrCheckBoxCondicao].Text = modelocrud.formatarTexto(prop.Name);
                    CheckBoxCondicao[arrCheckBoxCondicao].Font = new Font("Arial", 12);
                    CheckBoxCondicao[arrCheckBoxCondicao].Width = 150;
                    localizacao = CheckBoxCondicao[arrCheckBoxCondicao].Location;
                    arrCheckBoxCondicao++;
                }                
                arrLabelTexto++;                    
            }

            arrTextBoxNumero = 0;
            arrTextBoxData = 0;
            arrTextBoxHora = 0;
            arrTextBoxTexto = 0;
            arrCheckBoxCondicao = 0;
            arrLabelTexto = 0;
        } 
    }
}
