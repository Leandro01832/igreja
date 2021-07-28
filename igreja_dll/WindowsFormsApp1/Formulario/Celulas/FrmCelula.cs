using business.classes.Celulas;
using business.classes.Abstrato;
using System;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmCelula : FormularioListView
    {
        public FrmCelula(Type tipo) : base(tipo)
        {
            InitializeComponent();
            Tipo = tipo;
        }

        public Type Tipo { get; }

        private void FrmCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de";

            if (Tipo == typeof(Celula            )) this.Text += " todas as celulas";
            if (Tipo == typeof(Celula_Adolescente)) this.Text += " celuas para adolescentes";
            if (Tipo == typeof(Celula_Adulto     )) this.Text += " celuas para adultos";
            if (Tipo == typeof(Celula_Casado     )) this.Text += " celuas para casados";
            if (Tipo == typeof(Celula_Jovem      )) this.Text += " celuas para jovens";
            if (Tipo == typeof(Celula_Crianca    )) this.Text += " celuas para crianças";

            if (Tipo == typeof(Celula            )) this.BackColor = System.Drawing.Color.LightGray;
            if (Tipo == typeof(Celula_Adolescente)) this.BackColor = System.Drawing.Color.Aqua;
            if (Tipo == typeof(Celula_Adulto     )) this.BackColor = System.Drawing.Color.Aqua;
            if (Tipo == typeof(Celula_Casado     )) this.BackColor = System.Drawing.Color.Aqua;
            if (Tipo == typeof(Celula_Jovem      )) this.BackColor = System.Drawing.Color.Aqua;
            if (Tipo == typeof(Celula_Crianca    )) this.BackColor = System.Drawing.Color.Aqua;
        }
    }
}
