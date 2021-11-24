using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class MDI : Form, IFormCrud
    {
        private int childFormNumber = 1;
        private CrudForm crudForm;

        public MDI()
        {
            crudForm = new CrudForm();
            crudForm.Mdi = this;
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }  

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childFormNumber = 1;
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this, "Gerenciamento de pessoas");
            toolStrip.Visible = false;
            visitanteToolStripMenuItem1.BackColor = Color.Aqua;
            criançaToolStripMenuItem1.BackColor = Color.Bisque;
            membroPorAclamaçãoToolStripMenuItem1.BackColor = Color.Brown;
            membroPorBatismoToolStripMenuItem1.BackColor = Color.Chocolate;
            membroPorReconciliaçãoToolStripMenuItem1.BackColor = Color.DarkBlue;
            membroPorTransferênciaToolStripMenuItem1.BackColor = Color.DeepPink;
        }

        

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e){ }

        public void     Membro_AclamacaoLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_AclamacaoLgpdCadastrar_Click"); }
        public void     Membro_BatismoLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_BatismoLgpdCadastrar_Click"); }
        public void     Membro_ReconciliacaoLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_ReconciliacaoLgpdCadastrar_Click"); }
        public void     Membro_TransferenciaLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_TransferenciaLgpdCadastrar_Click"); }
        public void     VisitanteLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "VisitanteLgpdCadastrar_Click"); }
        public void     CriancaLgpdCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CriancaLgpdCadastrar_Click"); }
        public void     VisitanteCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "VisitanteCadastrar_Click"); }
        public void     CriancaCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CriancaCadastrar_Click"); }
        public void     Membro_AclamacaoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_AclamacaoCadastrar_Click"); }
        public void     Membro_BatismoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_BatismoCadastrar_Click"); }
        public void     Membro_ReconciliacaoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_ReconciliacaoCadastrar_Click"); }
        public void     Membro_TransferenciaCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_TransferenciaCadastrar_Click"); }
        public void     Celula_AdultoCadastrar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Celula_AdultoCadastrar_Click"); }
        public void     Lider_CelulaCadastrar_Click(object sender, EventArgs e)                      
        { Clicar(this, "Lider_CelulaCadastrar_Click"); }
        public void     Lider_Celula_TreinamentoCadastrar_Click(object sender, EventArgs e)          
        { Clicar(this, "Lider_Celula_TreinamentoCadastrar_Click"); }
        public void     Lider_MinisterioCadastrar_Click(object sender, EventArgs e)                  
        { Clicar(this, "Lider_MinisterioCadastrar_Click"); }
        public void     Lider_Ministerio_TreinamentoCadastrar_Click(object sender, EventArgs e)      
        { Clicar(this, "Lider_Ministerio_TreinamentoCadastrar_Click"); }
        public void     Supervisor_CelulaCadastrar_Click(object sender, EventArgs e)                 
        { Clicar(this, "Supervisor_CelulaCadastrar_Click"); }
        public void     Supervisor_Celula_TreinamentoCadastrar_Click(object sender, EventArgs e)     
        { Clicar(this, "Supervisor_Celula_TreinamentoCadastrar_Click"); }
        public void     Supervisor_MinisterioCadastrar_Click(object sender, EventArgs e)             
        { Clicar(this, "Supervisor_MinisterioCadastrar_Click"); }
        public void     Supervisor_Ministerio_TreinamentoCadastrar_Click(object sender, EventArgs e) 
        { Clicar(this, "Supervisor_Ministerio_TreinamentoCadastrar_Click"); }
        public void     Celula_CriancaCadastrar_Click(object sender, EventArgs e)                    
        { Clicar(this, "Celula_CriancaCadastrar_Click"); }
        public void     Celula_AdolescenteCadastrar_Click(object sender, EventArgs e)                
        { Clicar(this, "Celula_AdolescenteCadastrar_Click"); }
        public void     Celula_JovemCadastrar_Click(object sender, EventArgs e)                      
        { Clicar(this, "Celula_JovemCadastrar_Click"); }
        public void     ReuniaoCadastrar_Click(object sender, EventArgs e)                           
        { Clicar(this, "ReuniaoCadastrar_Click"); }
        public void     Celula_CasadoCadastrar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Celula_CasadoCadastrar_Click"); }
        public void     PessoaImprimir_Click(object sender, EventArgs e)                             
        { Clicar(this, "PessoaImprimir_Click"); }
        public void     CelulaImprimir_Click(object sender, EventArgs e)                             
        { Clicar(this, "CelulaImprimir_Click"); }
        public void     Celula_AdolescenteImprimir_Click(object sender, EventArgs e)                 
        { Clicar(this, "Celula_AdolescenteImprimir_Click"); }
        public void     Celula_AdultoImprimir_Click(object sender, EventArgs e)                      
        { Clicar(this, "Celula_AdultoImprimir_Click"); }
        public void     Celula_JovemImprimir_Click(object sender, EventArgs e)                       
        { Clicar(this, "Celula_JovemImprimir_Click"); }
        public void     Celula_CriancaImprimir_Click(object sender, EventArgs e)                     
        { Clicar(this, "Celula_CriancaImprimir_Click"); }
        public void     Celula_CasadoImprimir_Click(object sender, EventArgs e)                      
        { Clicar(this, "Celula_CasadoImprimir_Click"); }
        public void     MinisterioImprimir_Click(object sender, EventArgs e)                         
        { Clicar(this, "MinisterioImprimir_Click"); }
        public void     Lider_CelulaImprimir_Click(object sender, EventArgs e)                       
        { Clicar(this, "Lider_CelulaImprimir_Click"); }
        public void     Lider_Celula_TreinamentoImprimir_Click(object sender, EventArgs e)           
        { Clicar(this, "Lider_Celula_TreinamentoImprimir_Click"); }
        public void     Lider_MinisterioImprimir_Click(object sender, EventArgs e)                   
        { Clicar(this, "Lider_MinisterioImprimir_Click"); }
        public void     Lider_Ministerio_TreinamentoImprimir_Click(object sender, EventArgs e)       
        { Clicar(this, "Lider_Ministerio_TreinamentoImprimir_Click"); }
        public void     Supervisor_CelulaImprimir_Click(object sender, EventArgs e)                  
        { Clicar(this, "Supervisor_CelulaImprimir_Click"); }
        public void     Supervisor_Celula_TreinamentoImprimir_Click(object sender, EventArgs e)      
        { Clicar(this, "Supervisor_Celula_TreinamentoImprimir_Click"); }
        public void     Supervisor_MinisterioImprimir_Click(object sender, EventArgs e)              
        { Clicar(this, "Supervisor_MinisterioImprimir_Click"); }
        public void     Supervisor_Ministerio_TreinamentoImprimir_Click(object sender, EventArgs e)  
        { Clicar(this, "Supervisor_Ministerio_TreinamentoImprimir_Click"); }
        public void     MudancaEstadoImprimir_Click(object sender, EventArgs e)                      
        { Clicar(this, "MudancaEstadoImprimir_Click"); }
        public void     ReuniaoImprimir_Click(object sender, EventArgs e)                            
        { Clicar(this, "ReuniaoImprimir_Click"); }
        public void     PessoaLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaLgpdImprimir_Click"); }
        public void     PessoaDadoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaDadoImprimir_Click"); }
        public void     CriancaLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "CriancaLgpdImprimir_Click"); }
        public void     VisitanteLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "VisitanteLgpdImprimir_Click"); }
        public void     MembroLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "MembroLgpdImprimir_Click"); }
        public void     Membro_AclamacaoLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_AclamacaoLgpdImprimir_Click"); }
        public void     Menbro_BatismoLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Menbro_BatismoLgpdImprimir_Click"); }
        public void     Membro_TransferenciaLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_TransferenciaLgpdImprimir_Click"); }
        public void     Membro_ReconciliacaoLgpdImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_ReconciliacaoLgpdImprimir_Click"); }
        public void     CriancaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "CriancaImprimir_Click"); }
        public void     VisitanteImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "VisitanteImprimir_Click"); }
        public void     MembroImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "MembroImprimir_Click"); }
        public void     Membro_AclamacaoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_AclamacaoImprimir_Click"); }
        public void     Membro_BatismoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_BatismoImprimir_Click"); }
        public void     Membro_TransferenciaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_TransferenciaImprimir_Click"); }
        public void     Membro_ReconciliacaoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_ReconciliacaoImprimir_Click"); }
        public void     MinisterioPesquisar_Click(object sender, EventArgs e)                        
        { Clicar(this, "MinisterioPesquisar_Click"); }
        public void     Lider_CelulaPesquisar_Click(object sender, EventArgs e)                      
        { Clicar(this, "Lider_CelulaPesquisar_Click"); }
        public void     Lider_Celula_TreinamentoPesquisar_Click(object sender, EventArgs e)          
        { Clicar(this, "Lider_Celula_TreinamentoPesquisar_Click"); }
        public void     Lider_MinisterioPesquisar_Click(object sender, EventArgs e)                  
        { Clicar(this, "Lider_MinisterioPesquisar_Click"); }
        public void     Lider_Ministerio_TreianamentoPesquisar_Click(object sender, EventArgs e)     
        { Clicar(this, "Lider_Ministerio_TreianamentoPesquisar_Click"); }
        public void     Supervisor_CelulaPesquisar_Click(object sender, EventArgs e)                 
        { Clicar(this, "Supervisor_CelulaPesquisar_Click"); }
        public void     Supervisor_Celula_TreinamentoPesquisar_Click(object sender, EventArgs e)     
        { Clicar(this, "Supervisor_Celula_TreinamentoPesquisar_Click"); }
        public void     Supervisor_MinisterioPesquisar_Click(object sender, EventArgs e)             
        { Clicar(this, "Supervisor_MinisterioPesquisar_Click"); }
        public void     Supervisor_Ministerio_TreinamentoPesquisar_Click(object sender, EventArgs e) 
        { Clicar(this, "Supervisor_Ministerio_TreinamentoPesquisar_Click"); }
        public void     ReuniaoPesquisar_Click(object sender, EventArgs e)                           
        { Clicar(this, "ReuniaoPesquisar_Click"); }
        public void     CelulaPesquisar_Click(object sender, EventArgs e)                            
        { Clicar(this, "CelulaPesquisar_Click"); }
        public void     Celula_AdolescentePesquisar_Click(object sender, EventArgs e)                
        { Clicar(this, "Celula_AdolescentePesquisar_Click"); }
        public void     Celula_AdultoPesquisar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Celula_AdultoPesquisar_Click"); }
        public void     Celula_JovemPesquisar_Click(object sender, EventArgs e)                      
        { Clicar(this, "Celula_JovemPesquisar_Click"); }
        public void     Celula_CasadoPesquisar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Celula_CasadoPesquisar_Click"); }
        public void     Celula_CriancaPesquisar_Click(object sender, EventArgs e)                    
        { Clicar(this, "Celula_CriancaPesquisar_Click"); }
        public void     PessoaPesquisar_Click(object sender, EventArgs e)                            
        { Clicar(this, "PessoaPesquisar_Click"); }
        public void     PessoaLgpdPesquisar_Click(object sender, EventArgs e)                        
        { Clicar(this, "PessoaLgpdPesquisar_Click"); }
        public void     PessoaDadoPesquisar_Click(object sender, EventArgs e)                        
        { Clicar(this, "PessoaDadoPesquisar_Click"); }
        public void     VisitanteLgpdPesquisar_Click(object sender, EventArgs e)                     
        { Clicar(this, "VisitanteLgpdPesquisar_Click"); }
        public void     MenbroLgpdPesquisar_Click(object sender, EventArgs e)                        
        { Clicar(this, "MenbroLgpdPesquisar_Click"); }
        public void     CriancaLgpdPesquisar_Click(object sender, EventArgs e)                       
        { Clicar(this, "CriancaLgpdPesquisar_Click"); }
        public void     Membro_AclamacaoLgpdPesquisar_Click(object sender, EventArgs e)              
        { Clicar(this, "Membro_AclamacaoLgpdPesquisar_Click"); }
        public void     Membro_BatismoLgpdPesquisar_Click(object sender, EventArgs e)                
        { Clicar(this, "Membro_BatismoLgpdPesquisar_Click"); }
        public void     Membro_ReconciliacaoLgpdPesquisar_Click(object sender, EventArgs e)          
        { Clicar(this, "Membro_ReconciliacaoLgpdPesquisar_Click"); }
        public void     Membro_TransferenciaLgpdPesquisar_Click(object sender, EventArgs e)          
        { Clicar(this, "Membro_TransferenciaLgpdPesquisar_Click"); }
        public void     VisitantePesquisar_Click(object sender, EventArgs e)                         
        { Clicar(this, "VisitantePesquisar_Click"); }
        public void     CriancaPesquisar_Click(object sender, EventArgs e)                           
        { Clicar(this, "CriancaPesquisar_Click"); }
        public void     MembroPesquisar_Click(object sender, EventArgs e)                            
        { Clicar(this, "MembroPesquisar_Click"); }
        public void     Membro_AclamacaoPesquisar_Click(object sender, EventArgs e)                  
        { Clicar(this, "Membro_AclamacaoPesquisar_Click"); }
        public void     Membro_BatismoPesquisar_Click(object sender, EventArgs e)                    
        { Clicar(this, "Membro_BatismoPesquisar_Click"); }
        public void     Membro_ReconciliacaoPesquisar_Click(object sender, EventArgs e)              
        { Clicar(this, "Membro_ReconciliacaoPesquisar_Click"); }
        public void     Membro_TransferenciaPesquisar_Click(object sender, EventArgs e)              
        { Clicar(this, "Membro_TransferenciaPesquisar_Click"); }
        public void     ReuniaoListar_Click(object sender, EventArgs e)                              
        { Clicar(this, "ReuniaoListar_Click"); }
        public void     MudancaEstadoListar_Click(object sender, EventArgs e)                        
        { Clicar(this, "MudancaEstadoListar_Click"); }
        public void     Lider_CelulaListar_Click(object sender, EventArgs e)                         
        { Clicar(this, "Lider_CelulaListar_Click"); }
        public void     Lider_Celula_TreinamentoListar_Click(object sender, EventArgs e)             
        { Clicar(this, "Lider_Celula_TreinamentoListar_Click"); }
        public void     Lider_MinisterioListar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Lider_MinisterioListar_Click"); }
        public void     Lider_Ministerio_TreinamentoListar_Click(object sender, EventArgs e)         
        { Clicar(this, "Lider_Ministerio_TreinamentoListar_Click"); }
        public void     Supervisor_CelulaListar_Click(object sender, EventArgs e)                    
        { Clicar(this, "Supervisor_CelulaListar_Click"); }
        public void     Supervisor_Celula_TreinamentoListar_Click(object sender, EventArgs e)        
        { Clicar(this, "Supervisor_Celula_TreinamentoListar_Click"); }
        public void     Supervisor_MinisterioListar_Click(object sender, EventArgs e)                
        { Clicar(this, "Supervisor_MinisterioListar_Click"); }
        public void     Supervisor_Ministerio_TreinamentoListar_Click(object sender, EventArgs e)    
        { Clicar(this, "Supervisor_Ministerio_TreinamentoListar_Click"); }
        public void     Celula_AdolescenteListar_Click(object sender, EventArgs e)                   
        { Clicar(this, "Celula_AdolescenteListar_Click"); }
        public void     Celula_AdultoListar_Click(object sender, EventArgs e)                        
        { Clicar(this, "Celula_AdultoListar_Click"); }
        public void     Celula_JovemListar_Click(object sender, EventArgs e)                         
        { Clicar(this, "Celula_JovemListar_Click"); }
        public void     Celula_CasadoListar_Click(object sender, EventArgs e)                        
        { Clicar(this, "Celula_CasadoListar_Click"); }
        public void     PessoaDadoListar_Click(object sender, EventArgs e)                           
        { Clicar(this, "PessoaDadoListar_Click"); }
        public void     PessoaLgpdListar_Click(object sender, EventArgs e)                           
        { Clicar(this, "PessoaLgpdListar_Click"); }
        public void     PessoaListar_Click(object sender, EventArgs e)                               
        { Clicar(this, "PessoaListar_Click"); }
        public void     VisitanteLgpdListar_Click(object sender, EventArgs e)                        
        { Clicar(this, "VisitanteLgpdListar_Click"); }
        public void     Celula_CriancaListar_Click(object sender, EventArgs e)                       
        { Clicar(this, "Celula_CriancaListar_Click"); }
        public void     MembroLgpdListar_Click(object sender, EventArgs e)                           
        { Clicar(this, "MembroLgpdListar_Click"); }
        public void     CriancaLgpdListar_Click(object sender, EventArgs e)                          
        { Clicar(this, "CriancaLgpdListar_Click"); }
        public void     Membro_AclamacaoLgpdListar_Click(object sender, EventArgs e)                 
        { Clicar(this, "Membro_AclamacaoLgpdListar_Click"); }
        public void     Membro_BatismoLgpdListar_Click(object sender, EventArgs e)                   
        { Clicar(this, "Membro_BatismoLgpdListar_Click"); }
        public void     Membro_ReconciliacaoLgpdListar_Click(object sender, EventArgs e)             
        { Clicar(this, "Membro_ReconciliacaoLgpdListar_Click"); }
        public void     Membro_TransferenciaLgpdListar_Click(object sender, EventArgs e)             
        { Clicar(this, "Membro_TransferenciaLgpdListar_Click"); }
        public void     VisitanteListar_Click(object sender, EventArgs e)                            
        { Clicar(this, "VisitanteListar_Click"); }
        public void     MembroListar_Click(object sender, EventArgs e)                               
        { Clicar(this, "MembroListar_Click"); }
        public void     CriancaListar_Click(object sender, EventArgs e)                              
        { Clicar(this, "CriancaListar_Click"); }
        public void     Membro_AclamacaoListar_Click(object sender, EventArgs e)                     
        { Clicar(this, "Membro_AclamacaoListar_Click"); }
        public void     Membro_BatismoListar_Click(object sender, EventArgs e)                       
        { Clicar(this, "Membro_BatismoListar_Click"); }
        public void     Membro_ReconciliacaoListar_Click(object sender, EventArgs e)                 
        { Clicar(this, "Membro_ReconciliacaoListar_Click"); }
        public void     Membro_TransferenciaListar_Click(object sender, EventArgs e)
        { Clicar(this, "Membro_TransferenciaListar_Click"); }
        public void     MinisterioListar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioListar_Click"); }
        public void     CelulaListar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaListar_Click"); }


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
