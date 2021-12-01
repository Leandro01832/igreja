using business.classes.Abstrato;
using business.contrato;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using business.implementacao;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : Form, IPesquisar
    {
        public Pesquisar(Type tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            pesquisar = new Query();
        }
        Type tipo { get; }
        List<modelocrud> Resultado = new List<modelocrud>();
        private Query pesquisar;

        private CheckBox Id { get; set; }
        private CheckBox NomeMae { get; set; }
        private CheckBox NomePai { get; set; }
        private CheckBox Email { get; set; }
        private CheckBox Nome { get; set; }

        private CheckBox DataReuniao { get; set; }
        private CheckBox DataVisita { get; set; }
        private CheckBox DataMudancaEstado { get; set; }
        private CheckBox AnoBatismo { get; set; }
        private CheckBox HorarioCelula { get; set; }
        private CheckBox HorarioInicioReuniao { get; set; }
        private CheckBox HorarioFinalReuniao { get; set; }

        private void FormataDataGrid(bool Pessoa, bool Ministerio, bool Celula, bool Reuniao, bool Mudanca)
        {
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
            dgdados.Font = new Font("Arial", 18);
        }

        private void ModificaDataGridView(List<modelocrud> models)
        {

        }

        private Type ReturnBase(Type type)
        {
            if (type.BaseType != typeof(modelocrud))
                ReturnBase(type.BaseType);
            return type;
        }

        private void dgdados_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewRow row = dgdados.CurrentRow;
            var modelo = (modelocrud)row.DataBoundItem;
            var value = int.Parse(modelo.Id.ToString());
            WFCrud form = null;

            var Modelo = modelocrud.Modelos.Where(m => m.GetType() == tipo
        || m.GetType().IsSubclassOf(tipo)).ToList().FirstOrDefault(i => i.Id == value);

            if (Modelo != null)
            {
                var lista = modelocrud.listTypesSon(typeof(WFCrud));
                var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));

                if (Modelo.GetType().BaseType == typeof(modelocrud))
                    foreach (var item in listaTypes)
                        foreach (var item2 in lista)
                            if ("Frm" + Modelo.GetType().Name == item2.Name)
                                form = (WFCrud)Activator.CreateInstance(item2);

                if (Modelo.GetType().BaseType != typeof(modelocrud))
                {
                    Type BaseModel = ReturnBase(Modelo.GetType());

                    foreach (var item in listaTypes)
                        foreach (var item2 in lista)
                            if ("Frm" + BaseModel.Name == item2.Name)
                                form = (WFCrud)Activator.CreateInstance(item2);
                }

                form.modelo = Modelo;
                form.CondicaoAtualizar = false;
                form.CondicaoDeletar = false;
                form.CondicaoDetalhes = true;
                form.MdiParent = this.MdiParent;
                form.Show();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verifica();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            var query1 = FrmFiltro.TextBoxTexto;
            var query2 = FrmFiltro.TextBoxData;
            var query3 = FrmFiltro.TextBoxHora;
            var query4 = FrmFiltro.TextBoxNumero;

            if (query1 != null)
            {
                if (query1.Where(q => !string.IsNullOrWhiteSpace(q.Text)).ToList().Count > 0)
                    foreach (var item in query1)
                        if (!string.IsNullOrWhiteSpace(item.Text))                        
                            Resultado = PesquisarPorTexto(Resultado, item.Text, item.Name, tipo);

                if (query4.Where(q => !string.IsNullOrWhiteSpace(q.Text)).ToList().Count > 0)
                    foreach (var item in query1)
                        if (!string.IsNullOrWhiteSpace(item.Text))
                        {
                            TextBox text = query4.First(q => q.Name == item.Name);
                            TextBox text2 = query4.First(q => q.Name == item.Name + "campo2");
                            Resultado = PesquisarPorNumero(Resultado, int.Parse(text.Text), int.Parse(text2.Text), item.Name, tipo);
                        }                        

                if (query2.Where(q => Convert.ToDateTime(q.Text).ToString("dd/MM/yyyy") !=
                    new DateTime(0001, 01, 01).ToString("dd/MM/yyyy")).ToList().Count > 0)
                    foreach (var item in query1)
                        if (Convert.ToDateTime(item.Text).ToString("dd/MM/yyyy") !=
                            new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                        {
                            MaskedTextBox text = query2.First( q => q.Name == item.Name);
                            MaskedTextBox text2 = query2.First( q => q.Name == item.Name + "campo2");

                            Resultado = PesquisarPorData(Resultado, Convert.ToDateTime(text.Text),
                                Convert.ToDateTime(text2.Text), text.Name, tipo);
                        }

                if (query3.Where(q => TimeSpan.Parse(q.Text) != new TimeSpan(0, 0, 0)).ToList().Count > 0)
                    foreach (var item in query1)
                        if (TimeSpan.Parse(item.Text) != new TimeSpan(0, 0, 0))
                        {
                            MaskedTextBox text = query2.First(q => q.Name == item.Name);
                            MaskedTextBox text2 = query2.First(q => q.Name == item.Name + "campo2");

                            Resultado = PesquisarPorHorario(Resultado, TimeSpan.Parse(text.Text),
                                TimeSpan.Parse(text2.Text), text.Name, tipo);
                        }

                ModificaDataGridView(Resultado);
             verifica();
            }
        }

        private void verifica()
        {
            Resultado.Clear();
            Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().Where(m => m.GetType() == tipo
            || m.GetType().IsSubclassOf(tipo)).ToList());
            ModificaDataGridView(Resultado);
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            Resultado.Clear();
            Resultado.AddRange(modelocrud.Modelos.Where(m => m.GetType() == Resultado[0].GetType()
            || m.GetType().IsSubclassOf(Resultado[0].GetType())).ToList());
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            FrmFiltro form = new FrmFiltro(tipo.GetProperties().ToList());
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorData(modelos, comecar, terminar, campo, tipo);
        }
        

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos, int comecar, int terminar, string campo, Type tipo)
        {
            return PesquisarPorNumero(modelos, comecar, terminar, campo, tipo);
        }


        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorTexto(modelos, texto, campo, tipo);
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo, Type tipo)
        {
            return pesquisar.PesquisarPorHorario(modelos, comecar, terminar, campo, tipo);
        }


    }
}
