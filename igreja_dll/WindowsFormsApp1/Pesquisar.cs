using database;
using System;
using System.Drawing;
using System.Windows.Forms;
using business.classes.PessoasLgpd;
using business.classes.Pessoas;
using business.classes.Ministerio;
using business.classes.Abstrato;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using business.classes;
using WindowsFormsApp1.Formulario.Reuniao;
using business.classes.Celulas;
using business.implementacao;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Celulas;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : FormPadrao
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
            dgdados.Font = new Font("Arial", 18);
        }

        private void ModificaDataGridView(List<modelocrud> models)
        {
            
        }
        
        private void dgdados_SelectionChanged(object sender, EventArgs e)
        {
            
            var id = dgdados.CurrentRow.Cells[0];
            var value = int.Parse(id.Value.ToString());
            WFCrud form = null;
            if (tipo.IsAbstract)
            {
                if (tipo == typeof(Pessoa))
                {
                    var Modelo = modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(i => i.Codigo == value);
                    if (Modelo != null)
                    form = new FormPessoa();
                    
                }

                if (tipo == typeof(Ministerio))
                {
                    var Modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().FirstOrDefault(i => i.Id == value);
                    if (Modelo != null)
                    form = new FrmMinisterio();                        
                    
                }

                if (tipo == typeof(Celula))
                {
                    var Modelo = modelocrud.Modelos.OfType<Celula>().ToList().FirstOrDefault(i => i.Id == value);
                    if (Modelo != null)
                        form = new FrmCelula();  
                    
                }                
            }

            else if (tipo.IsSubclassOf(typeof(Pessoa)))
            {
                var Modelo = modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(i => i.Codigo == value);
                if (Modelo != null)
                    form = new FormPessoa();
            }
            else if (tipo.IsSubclassOf(typeof(Ministerio)))
            {
                var Modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().FirstOrDefault(i => i.Id == value);
                if (Modelo != null)
                    form = new FrmMinisterio();
            }
            else if (tipo.IsSubclassOf(typeof(Celula)))
            {
                var Modelo = modelocrud.Modelos.OfType<Celula>().ToList().FirstOrDefault(i => i.Id == value);
                if (Modelo != null)
                    form = new FrmCelula();
            }

            else if (tipo == typeof(Reuniao))
            {
                var Modelo = modelocrud.Modelos.OfType<Reuniao>().ToList().FirstOrDefault(i => i.Id == value);
                if (Modelo != null)
                    form = new FrmReuniao();
            }

            else if (tipo == typeof(MudancaEstado))
            {
                var Modelo = modelocrud.Modelos.OfType<MudancaEstado>().ToList().FirstOrDefault(i => i.Id == value);
                if (Modelo != null)
                    form = new DetalhesMudancaEstado();
            }

            form.CondicaoAtualizar = false;
            form.CondicaoDeletar = false;
            form.CondicaoDetalhes = true;
            form.MdiParent = this.MdiParent;
            form.Show();
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
            if (tipo == typeof(VisitanteLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<VisitanteLgpd>().ToList());
                ModificaDataGridView(Resultado);
            }

            if (tipo == typeof(CriancaLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<CriancaLgpd>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_AclamacaoLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_AclamacaoLgpd>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_BatismoLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_BatismoLgpd>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_ReconciliacaoLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_ReconciliacaoLgpd>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_TransferenciaLgpd))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_TransferenciaLgpd>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Visitante))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Visitante>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Crianca))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Crianca>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_Aclamacao))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_Aclamacao>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_Batismo))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_Batismo>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_Reconciliacao))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_Reconciliacao>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Membro_Transferencia))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro_Transferencia>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Lider_Celula))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Lider_Celula>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Lider_Celula_Treinamento))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Lider_Celula_Treinamento>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Lider_Ministerio))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Lider_Ministerio>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Lider_Ministerio_Treinamento))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Lider_Ministerio_Treinamento>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Supervisor_Celula))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Supervisor_Celula>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Supervisor_Celula_Treinamento))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Supervisor_Celula_Treinamento>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Supervisor_Ministerio))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Supervisor_Ministerio>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Supervisor_Ministerio_Treinamento))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Supervisor_Ministerio_Treinamento>().ToList());
                ModificaDataGridView(Resultado);
            }

            if (tipo == typeof(Celula_Adolescente))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Celula_Adolescente>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Celula_Adulto))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Celula_Adulto>().ToList());
                ModificaDataGridView(  Resultado);
            }

            if (tipo == typeof(Celula_Jovem))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Celula_Jovem>().ToList());
                ModificaDataGridView(  Resultado);
            }

            if (tipo == typeof(Celula_Crianca))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Celula_Crianca>().ToList());
                ModificaDataGridView( Resultado);
            }

            if (tipo == typeof(Celula_Casado))
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList().OfType<Celula_Casado>().ToList());
                ModificaDataGridView( Resultado);
            }
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            if (Resultado[0] is Pessoa)
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Pessoa>().ToList());
            }

            if (Resultado[0] is Celula)
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Celula>().ToList());
            }

            if (Resultado[0] is Ministerio)
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Ministerio>().ToList());
            }

            if (Resultado[0] is MudancaEstado)
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<MudancaEstado>().ToList());
            }

            if (Resultado[0] is Reuniao)
            {
                Resultado.Clear();
                Resultado.AddRange(modelocrud.Modelos.OfType<Reuniao>().ToList());
            }
        }
    }
}
