using business.classes.Abstrato;
using business.contrato;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using business.implementacao;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : Form, IPesquisar, IFormCrud
    {
        public Pesquisar(Type tipo)
        {
            InitializeComponent();
            crudForm = new CrudForm();

            this.tipo = tipo;
            pesquisar = new Query();
            props = tipo.GetProperties().Where(p => !p.PropertyType.IsSubclassOf(typeof(modelocrud)) &&
            p.PropertyType.Name != "List`1").ToList();

            

            dgdados.Columns.Clear();
            foreach (var item in props)
                dgdados.Columns.Add(item.Name, modelocrud.formatarTexto(item.Name));
        }
        CrudForm crudForm;
        List<PropertyInfo> props;

        Type tipo { get; }
        List<modelocrud> Resultado = new List<modelocrud>();
        private Query pesquisar;

        private void FormataDataGrid(bool Pessoa, bool Ministerio, bool Celula, bool Reuniao, bool Mudanca)
        {
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            if (FormPadrao.executar)
                Resultado = modelocrud.Modelos.Where(m => m.GetType() == tipo || m.GetType().IsSubclassOf(tipo)).ToList();
            else
                MessageBox.Show("Aguarde o processamento!!!");
            dgdados.Font = new Font("Arial", 18);
            
            preencherRow(Resultado);
            dgdados.SelectionChanged += Dgdados_SelectionChanged;
        }

        private void preencherRow(List<modelocrud> models)
        {
            object[] arr = new object[props.Count];

            foreach (var item in models)
                for (int i = 0; i < props.Count; i++)
                {
                    arr[i] = props[i].GetValue(item);
                    if (i == props.Count - 1)
                        dgdados.Rows.Add(arr);

                }
        }

        private void Dgdados_SelectionChanged(object sender, EventArgs e)
        {
            modelocrud modelo = null;
            int value = 0;
            DataGridViewRow row = dgdados.CurrentRow;
            var cel = row.Cells["Id"];
            value = int.Parse(cel.FormattedValue.ToString());
            modelo = modelocrud.Modelos.First(m => m.GetType() == tipo && m.Id == value ||
            m.GetType().IsSubclassOf(tipo) && m.Id == value);

            if (modelo != null)
                LoadFormCrud(modelo, true, false, false, this);
            
        }

        private void ModificaDataGridView(List<modelocrud> models)
        {
            dgdados.Rows.Clear();

            preencherRow(models);
        }


        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            var query1 = FrmFiltro.TextBoxTexto;
            var query2 = FrmFiltro.TextBoxData;
            var query3 = FrmFiltro.TextBoxHora;
            var query4 = FrmFiltro.TextBoxNumero;            

            if (query1 != null && FormPadrao.executar)
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
                            MaskedTextBox text = query2.First(q => q.Name == item.Name);
                            MaskedTextBox text2 = query2.First(q => q.Name == item.Name + "campo2");

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
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            verifica();
            ModificaDataGridView(Resultado);

            var query1 = FrmFiltro.TextBoxTexto;
            var query2 = FrmFiltro.TextBoxData;
            var query3 = FrmFiltro.TextBoxHora;
            var query4 = FrmFiltro.TextBoxNumero;

            if (query1 != null)
                foreach (var item in query1)
                    item.Text = "";

            if (query2 != null)
                foreach (var item in query2)
                    item.Text = "";

            if (query3 != null)
                foreach (var item in query3)
                    item.Text = "";

            if (query4 != null)
                foreach (var item in query4)
                    item.Text = "";

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

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, Atual);
        }

        public void Clicar(Form form, string function)
        {
            crudForm.Clicar(form, function);
        }
    }
}
