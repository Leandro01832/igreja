using business.classes;
using business.classes.Abstrato;
using business.classes.Esboco;
using business.classes.Esboco.Abstrato;
using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public class CrudForm : IFormCrud
    {
        public WFCrud Form { get; set; }
        public Form Mdi { get; set; }
        public static int quantidade = 0;
        public static bool contagem = true;

        ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);

        public void Clicar(Form form, string function)
        {
            Type T = Mdi.GetType();
            var lista = modelocrud.listTypesAll(typeof(modelocrud));


            foreach (var item in lista)
                if (item.Name + "Imprimir" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        ir.imprimir(item);
                        MessageBox.Show(function + " foi executada!!!");
                        break;
                    }
                }
                else if (item.Name + "Cadastrar" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        Form frm = null;
                        var modelo = (modelocrud)Activator.CreateInstance(item);
                        if (modelo is Celula) frm = new DadoCelula();
                        if (modelo is Ministerio) frm = new DadoMinisterio();
                        if (modelo is Reuniao) frm = new DadoReuniao();
                        if (modelo is PessoaDado) frm = new DadoPessoal();
                        if (modelo is PessoaLgpd) frm = new DadoPessoalLgpd();
                        if (modelo is Fonte) frm = new FrmDadoFonte();
                        if (modelo is Mensagem) frm = new FrmCadastrarMensagem();

                        LoadFormCrud(modelo, false, false, false, frm);
                        break;
                    }
                }
                else if (item.Name + "Pesquisar" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        Pesquisar query = new Pesquisar(item);
                        query.MdiParent = form;
                        query.Text = "Pesquisar " + item.Name;
                        query.Show();
                        break; 
                    }
                }
                else if (item.Name + "Listar" + "_Click" == function)
                {
                    quantidade += 4;
                    if (!contagem)
                    {
                        FormularioListView frm = new FormularioListView(item);
                        frm.MdiParent = form;
                        frm.Text = "Listar " + item.Name;
                        frm.Show();
                        break; 
                    }
                }
                else
                {
                    if (item.Name + "Cadastrar" + "_Click" == function ||
                        item.Name + "Imprimir" + "_Click" == function ||
                        item.Name + "Listar" + "_Click" == function ||
                        item.Name + "Pesquisar" + "_Click" == function)
                    {
                        quantidade++;
                        if (!contagem)
                        {
                            MessageBox.Show($"Não foi executado a {item.Name + "_Click"}!!!");
                            break;
                        }

                    }
                }

        }


        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            if (!detalhes && !deletar && !atualizar && Atual.IsMdiContainer)
                Form.MdiParent = Atual;
            else
                Form.MdiParent = Atual.MdiParent;

            if (detalhes || deletar || atualizar)
            {
                try
                {
                    var lista = modelocrud.listTypesSon(typeof(WFCrud));
                    var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));

                    Type BaseModel = modelocrud.ReturnBase(modelo.GetType());

                    foreach (var item in listaTypes)
                    {
                        foreach (var item2 in lista)
                            if ("Frm" + BaseModel.Name == item2.Name)
                            {
                                Form = (WFCrud)Activator.CreateInstance(item2);
                                break;
                            }
                            else if ("Frm" + modelo.GetType().Name == item2.Name)
                            {
                                Form = (WFCrud)Activator.CreateInstance(item2);
                                break;
                            }
                        if (Form != null) break;
                    }

                }
                catch { }
            }

            Form.modelo = modelo;
            Form.CondicaoDetalhes = detalhes;
            Form.CondicaoDeletar = deletar;
            Form.CondicaoAtualizar = atualizar;
            Form.LoadCrudForm();
            Form.Show();
        }



    }
}
