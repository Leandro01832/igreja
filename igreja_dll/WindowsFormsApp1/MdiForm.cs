using business.classes;
using business.classes.Abstrato;
using business.classes.Esboco.Abstrato;
using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public class MdiForm : IFormCrud
    {
        public WFCrud Form { get; set; }
        private WFCrud formCadastro;
        public static int quantidade = 0;
        public static bool contagem = true;

        ImprimirRelatorio ir = new ImprimirRelatorio();

        public void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false)
        {
            var lista = modelocrud.listTypesAll(typeof(modelocrud));


            foreach (var item in lista)
                if (item.Name + "Imprimir" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        if (FrmPrincipal.executar)
                        {
                            ir.imprimir(item);
                            MessageBox.Show(function + " foi executada!!!");
                        }
                        else
                            MessageBox.Show("aguarde o processamento!!!");

                        break;
                    }
                }
                else if (item.Name + "Cadastrar" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        if (FrmPrincipal.executar)
                        {
                            var modelo = (modelocrud)Activator.CreateInstance(item);
                            if (modelo is Celula) formCadastro = new FrmDia_semana();
                            else
                            if (modelo is Ministerio) formCadastro = new FrmNome();
                            else
                            if (modelo is Reuniao) formCadastro = new DadoReuniao();
                            else
                            if (modelo is PessoaDado) formCadastro = new FrmCpf();
                            else
                            if (modelo is PessoaLgpd) formCadastro = new DadoPessoalLgpd();
                            else
                            if (modelo is Fonte) formCadastro = new FrmDadoFonte();
                            else
                            if (item.BaseType == typeof(modelocrud))
                            {
                                var list = modelocrud.listTypesSon(typeof(WFCrud));

                                foreach (var it in list)
                                    if ("Frm" + item.Name == it.Name)
                                    {
                                        formCadastro = (WFCrud)Activator.CreateInstance(it);
                                        break;
                                    }
                            }

                            LoadFormCrud(modelo, detalhes, deletar, atualizar, form);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Aguarde o processamento");
                            break;
                        }
                    }
                }
                else if (item.Name + "Pesquisar" + "_Click" == function)
                {
                    quantidade++;
                    if (!contagem)
                    {
                        if (FrmPrincipal.executar)
                        {
                            Pesquisar query = new Pesquisar(item);
                            query.MdiParent = form;
                            query.Text = "Pesquisar " + item.Name;
                            query.Show();
                        }
                        else
                            MessageBox.Show("aguarde o processamento!!!");
                        break;
                    }
                }
                else if (item.Name + "Listar" + "_Click" == function)
                {
                    quantidade += 4;
                    if (!contagem)
                    {
                        if (FrmPrincipal.executar)
                        {
                            FormularioListView frm = new FormularioListView(item);
                            frm.MdiParent = form;
                            frm.Text = "Listar " + item.Name;
                            frm.Show();
                        }
                        else
                            MessageBox.Show("aguarde o processamento!!!");

                        break;
                    }
                }
                else if (function.Contains("Selecionar"))
                {
                    if (!contagem)
                    {
                        Type BaseModel = modelocrud.ReturnBase(Modelo.GetType());
                        var props = Modelo.GetType().GetProperties();
                        var listaForm = modelocrud.listTypesAll(typeof(WFCrud));
                        bool teste = false;
                        foreach (var item2 in props)
                            if (BaseModel.Name + "Frm" + item2.Name + "Selecionar" + "_Click" == function)
                            {
                                teste = true;
                                foreach (var item3 in listaForm)
                                {
                                    if ("Frm" + item2.Name == item3.Name)
                                    {
                                        Form = (WFCrud)Activator.CreateInstance(item3);
                                        LoadFormCrud(Modelo, detalhes, deletar, atualizar, Form);
                                        break;
                                    }
                                }
                                break;
                            }

                        if (teste) break;
                    }
                }
                else
                    if (function.Contains("Cadastrar") && item != typeof(modelocrud) ||
                        function.Contains("Imprimir") && item != typeof(modelocrud) ||
                        function.Contains("Listar") && item != typeof(modelocrud) ||
                        function.Contains("Selecionar") && item != typeof(modelocrud) ||
                        function.Contains("Pesquisar") && item != typeof(modelocrud))
                {
                    if (!contagem && 1 == 2)
                    {
                        quantidade++;
                        MessageBox.Show($"Não foi executado a {function}!!!");
                        break;
                    }

                }
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {

            if (!detalhes && !deletar && !atualizar && Atual.IsMdiContainer)
            {
                Form = formCadastro;
                Form.MdiParent = Atual;
            }
            else
            if (detalhes && Form == null ||
                deletar && Form == null ||
                atualizar && Form == null)
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
                        if (Form != null)
                        {
                            Form.MdiParent = Atual.MdiParent;
                            break;
                        }
                    }

                }
                catch { MessageBox.Show("Erro ao abrir form crud!!!"); }

            }
            else
            {
                Form.MdiParent = Atual.MdiParent;
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
