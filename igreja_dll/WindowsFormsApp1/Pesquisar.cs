using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : Form
    {
        public Pesquisar(Type tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        Type tipo { get; }
        List<modelocrud> Resultado = new List<modelocrud>();

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
            var modelo = (modelocrud) row.DataBoundItem;
            var value = int.Parse(modelo.Id.ToString());
            WFCrud form = null;
            
                var Modelo = modelocrud.Modelos.Where(m => m.GetType() == tipo
            || m.GetType().IsSubclassOf(tipo)).ToList().FirstOrDefault(i => i.Id == value);

                if(Modelo != null)
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
            ModificaDataGridView(Resultado);
            verifica();
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
    }
}
