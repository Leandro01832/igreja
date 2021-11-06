using business.classes.Abstrato;
using business.classes.Ministerio;
using System;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class ListMinisterio : FormularioListView
    {

        public ListMinisterio(Type tipo) : base(tipo)
        {
            InitializeComponent();
            Tipo = tipo;
        }

        public Type Tipo { get; }

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de";

            if (Tipo == typeof(Ministerio                       )) this.Text += " todos os ministérios";
            if (Tipo == typeof(Lider_Celula                     )) this.Text += " ministérios de Líderes de celula";
            if (Tipo == typeof(Lider_Celula_Treinamento         )) this.Text += " ministérios de Líderes de celula em treinamento";
            if (Tipo == typeof(Lider_Ministerio                 )) this.Text += " ministérios de Líderes de ministério";
            if (Tipo == typeof(Lider_Ministerio_Treinamento     )) this.Text += " ministérios de Líderes de ministério em treinamento";
            if (Tipo == typeof(Supervisor_Celula                )) this.Text += " ministérios de Supervisores de célula";
            if (Tipo == typeof(Supervisor_Celula_Treinamento    )) this.Text += " ministérios de Supervisores de célula em treinamento";
            if (Tipo == typeof(Supervisor_Ministerio            )) this.Text += " ministérios de Supervisores de ministério";
            if (Tipo == typeof(Supervisor_Ministerio_Treinamento)) this.Text += " ministérios de Supervisores de ministério em treinamento";

            if (Tipo == typeof(Ministerio                       )) this.BackColor = System.Drawing.Color.LightGray;
            if (Tipo == typeof(Lider_Celula                     )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Lider_Celula_Treinamento         )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Lider_Ministerio                 )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Lider_Ministerio_Treinamento     )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Supervisor_Celula                )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Supervisor_Celula_Treinamento    )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Supervisor_Ministerio            )) this.BackColor = System.Drawing.Color.LightGreen;
            if (Tipo == typeof(Supervisor_Ministerio_Treinamento)) this.BackColor = System.Drawing.Color.LightGreen;
        }
    }
}
