using business.classes;
using business.classes.Abstrato;
using business.classes.financeiro;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud : Form, IFormCrud
    {
        public MdiForm crudForm;
        public modelocrud modelo { get; set; }
        public modelocrud modeloErro { get; set; }
        public modelocrud ModeloNovo { get; set; }
        public modelocrud ModeloVelho { get; set; }
        public bool CondicaoDeletar { get; set; }
        public bool CondicaoAtualizar { get; set; }
        public bool CondicaoDetalhes { get; set; }

        List<Button> botaoSelecionarPessoa = new List<Button>();
        List<Button> botaoSelecionarCelula = new List<Button>();
        List<Button> botaoSelecionarReuniao = new List<Button>();
        List<Button> botaoSelecionarMinisterio = new List<Button>();

        [OpcoesButtonBase(Tipo = "*", Formatar = true)]
        public Button FazerMudanca { get; set; }
        [OpcoesButtonBase(Tipo = "*", Formatar = true)]
        public Button Proximo { get; set; }
        [OpcoesButtonBase(Tipo = "*", Formatar = true)]
        public Button Atualizar { get; set; }
        [OpcoesButtonBase(Tipo = "*", Formatar = true)]
        public Button FinalizarCadastro { get; set; }
        [OpcoesButtonBase(Tipo = "*", Formatar = true)]
        public Button Deletar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Dados = true)]
        public Button PessoaFrmCpfSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Dados = true)]
        public Button PessoaFrmEmailSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Formatar = true)]
        public Button PessoaFrmImagemSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Formatar = true)]
        public Button PessoaFrmEnderecoSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Formatar = true)]
        public Button PessoaFrmTelefoneSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Pessoa", Formatar = true)]
        public Button PessoaFrmMinisterioSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Celula", Formatar = true)]
        public Button CelulaFrmEnderecoCelulaSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Celula")]
        public Button CelulaFrmDia_semanaSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Celula", Formatar = true)]
        public Button CelulaFrmMinisteriosSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Celula", Dados = true)]
        public Button DadoCelulaSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Ministerio", Formatar = true)]
        public Button MinisterioFrmPessoaSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Ministerio")]
        public Button MinisterioFrmNomeSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Ministerio", Dados = true)]
        public Button DadoMinisterioSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Reuniao", Dados = true)]
        public Button ReuniaoFrmLocal_reuniaoSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Reuniao", Formatar = true)]
        public Button ReuniaoFrmPessoasSelecionar { get; set; }
        [OpcoesButtonBase(Tipo = "Classe", Dados = true)]
        public Button DadoClasse { get; set; }
        public Label InfoForm { get; set; }        

        Point ultimoBotaoRenderizado;
        int indice = 0;

        public WFCrud()
        {
            crudForm = new MdiForm();
            this.FormClosing += WFCrud_FormClosing;

            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);

            var props = this.GetType().GetProperties().Where(p => p.PropertyType == typeof(Button)).ToList();

            foreach (var item in props)
            {
                OpcoesButtonBase opc = (OpcoesButtonBase)item.GetCustomAttribute(typeof(OpcoesButtonBase));

                item.SetValue(this, new Button());
                var select = (Button)item.GetValue(this);
                select.Visible = false;
                select.Size = new Size(100, 50);
                if (opc.Dados)
                    select.Text = "Dados de " + opc.Tipo;

                if (opc.Formatar)
                {
                    select.Text = item.Name.Replace(opc.Tipo, "");
                    select.Text = select.Text.Replace("Frm", "");
                    select.Text = select.Text.Replace("Selecionar", "");
                    select.Text = select.Text.Replace("Selecionar", "");
                    select.Text = modelocrud.formatarTexto(select.Text);
                }

                this.Controls.Add(select);
            }

            var lista = props.Where(p => p.Name.Contains("Selecionar")).ToList();
            foreach (var item in lista)
            {
                OpcoesButtonBase opc = (OpcoesButtonBase)item.GetCustomAttribute(typeof(OpcoesButtonBase));
                var select = (Button)item.GetValue(this);
                if (opc.Tipo == "Reuniao")
                    botaoSelecionarReuniao.Add(select);
                if (opc.Tipo == "Pessoa")
                    botaoSelecionarPessoa.Add(select);
                if (opc.Tipo == "Ministerio")
                    botaoSelecionarMinisterio.Add(select);
                if (opc.Tipo == "Celula")
                    botaoSelecionarCelula.Add(select);
            }

            ultimoBotaoRenderizado = new Point(50, 50);
            foreach (var item in botaoSelecionarMinisterio)
                SetarLocation(item);
            ultimoBotaoRenderizado = new Point(50, 50);
            foreach (var item in botaoSelecionarReuniao)
                SetarLocation(item);
            ultimoBotaoRenderizado = new Point(50, 50);
            foreach (var item in botaoSelecionarPessoa)
                SetarLocation(item);
            ultimoBotaoRenderizado = new Point(50, 50);
            foreach (var item in botaoSelecionarCelula)
                SetarLocation(item);

            DadoCelulaSelecionar.Click += DadoCelulaSelecionar_Click;
            DadoMinisterioSelecionar.Click += DadoMinisterioSelecionar_Click;
            PessoaFrmCpfSelecionar.Click += PessoaFrmCpfSelecionar_Click;
            PessoaFrmEmailSelecionar.Click += PessoaFrmEmailSelecionar_Click;
            ReuniaoFrmLocal_reuniaoSelecionar.Click += ReuniaoFrmLocal_reuniaoSelecionar_Click;
            ReuniaoFrmPessoasSelecionar.Click += ReuniaoFrmPessoasSelecionar_Click;
            PessoaFrmEnderecoSelecionar.Click += PessoaFrmEnderecoSelecionar_Click;
            PessoaFrmTelefoneSelecionar.Click += PessoaFrmTelefoneSelecionar_Click;
            PessoaFrmMinisterioSelecionar.Click += PessoaFrmMinisterioSelecionar_Click;
            PessoaFrmImagemSelecionar.Click += PessoaFrmImagemSelecionar_Click;
            CelulaFrmEnderecoCelulaSelecionar.Click += CelulaFrmEnderecoCelulaSelecionar_Click;
            CelulaFrmMinisteriosSelecionar.Click += CelulaFrmMinisteriosSelecionar_Click;
            MinisterioFrmPessoaSelecionar.Click += MinisterioFrmPessoaSelecionar_Click;
            CelulaFrmDia_semanaSelecionar.Click += CelulaFrmDia_semanaSelecionar_Click;
            MinisterioFrmNomeSelecionar.Click += MinisterioFrmNomeSelecionar_Click;
            Proximo.Click += Proximo_Click;
            DadoClasse.Click += DadoClasse_Click;
            Deletar.Click += Deletar_Click;
            Atualizar.Click += Atualizar_Click;
            FinalizarCadastro.Click += FinalizarCadastro_Click;
            FazerMudanca.Click += FazerMudanca_Click;

            CelulaFrmDia_semanaSelecionar.Text = "Ministérios da celula";
            MinisterioFrmNomeSelecionar.Text = "Ministro do ministério";

            DadoClasse.Location = new Point(350, 270);
            Proximo.Location = new Point(650, 150);
            FazerMudanca.Location = new Point(650, 150);
            Deletar.Location = new Point(650, 250);
            Atualizar.Location = new Point(650, 350);
            FinalizarCadastro.Location = new Point(650, 250);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);
        }

        private void FazerMudanca_Click(object sender, EventArgs e)
        {
            if(ModeloNovo is Pessoa)
            {
                Pessoa p = (Pessoa)ModeloNovo;
                p.MudarEstado(ModeloVelho.Id, ModeloNovo);
            }

            if (ModeloNovo is Ministerio)
            {
                Ministerio p = (Ministerio)ModeloNovo;
                p.MudarEstado(ModeloVelho.Id, ModeloNovo);
            }
        }

        private void SetarLocation(Button select)
        {
            if (indice == 3)
            {
                indice = 0;
                ultimoBotaoRenderizado.X = 50;
                ultimoBotaoRenderizado = new Point(ultimoBotaoRenderizado.X, ultimoBotaoRenderizado.Y + 110);
            }
            select.Location = new Point(ultimoBotaoRenderizado.X, ultimoBotaoRenderizado.Y);
            ultimoBotaoRenderizado = new Point(select.Location.X + 150, select.Location.Y);
            indice++;
        }

        private void WFCrud_Load(object sender, EventArgs e)
        {
        }

        private void WFCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool deletar = false;

            if (CondicaoDeletar)
            {
                var p = (Pessoa)modelo;
                if (modelo.recuperar(modelo.Id)) deletar = true;
            }

            if (CondicaoAtualizar || CondicaoDetalhes || deletar)
            {
                modelocrud pes = null;
                var model = (modelocrud)Activator.CreateInstance(modelo.GetType());
                model.Id = modelo.Id;
                model.Select_padrao = $"select * from {model.GetType().Name} as C where C.Id='{modelo.Id}'";
                model.Delete_padrao = $" delete from {model.GetType().Name} where Id='{modelo.Id}' ";
                model.stringConexao = BDcomum.conecta1;
                if (model.recuperar(modelo.Id)) pes = model;

                modelocrud.Modelos.Remove(modelocrud.Modelos.Where(m => m.GetType() == modelo.GetType())
                .ToList().First(i => i.Id == modelo.Id));
                modelocrud.Modelos.Add(pes);
            }

            this.Dispose();
        }

        public void ReuniaoFrmLocal_reuniaoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmLocal_reuniaoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void ReuniaoFrmPessoasSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmPessoasSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void DadoCelulaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void CelulaFrmEnderecoCelulaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmEnderecoCelulaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void CelulaFrmDia_semanaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void CelulaFrmMinisteriosSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmMinisteriosSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void DadoMinisterioSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void MinisterioFrmPessoaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmPessoaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void MinisterioFrmNomeSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmMinisterioSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmMinisterioSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmTelefoneSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmTelefoneSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmEnderecoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEnderecoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmCpfSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmCpfSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmEmailSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEmailSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void PessoaFrmImagemSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmImagemSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }

        public void LoadCrudForm()
        {
            FrmPrincipal.LoadForm(this);

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes && modelo != null && modelo.anular)
            {
                modelocrud.anularDados(modelo);
                modelo.anular = false;
                modelo.stringConexao = BDcomum.conecta1;
            }

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes && ModeloNovo != null && ModeloNovo.anular)
            {
                modelocrud.anularDados(ModeloNovo);
                ModeloNovo.anular = false;
                ModeloNovo.stringConexao = BDcomum.conecta1;
            }

            if (modelo == null) modeloErro = ModeloNovo;
            else modeloErro = modelo;

            if (CondicaoAtualizar || CondicaoDeletar || CondicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizarCadastro.Visible = false;

                var propNome = modelo.GetType().GetProperty("Nome");
                var propEmail = modelo.GetType().GetProperty("Email");
                var propCodigo = modelo.GetType().GetProperty("Codigo");
                var propId = modelo.GetType().GetProperty("Id");

                if (propNome != null && propCodigo != null)
                    InfoForm.Text = "Identificação: " + propCodigo.GetValue(modelo).ToString() +
                    " - " + propNome.GetValue(modelo).ToString();
                else
                if (propCodigo != null && propEmail != null)
                    InfoForm.Text = "Identificação: " + propCodigo.GetValue(modelo).ToString() +
                            " - " + propEmail.GetValue(modelo).ToString();
                else
                if (propNome != null)
                    InfoForm.Text = "Identificação: " + propId.GetValue(modelo).ToString() +
                    " - " + propNome.GetValue(modelo).ToString();
                else
                    InfoForm.Text = "Identificação: " + propId.GetValue(modelo).ToString() +
                    " - " + modelo.GetType().Name;
            }

            if (modelo is Pessoa && this is Formulario.Pessoas.FormCrudPessoa.FrmPessoa ||
                ModeloNovo is Pessoa && this is Formulario.Pessoas.FormCrudPessoa.FrmPessoa)
            {
                DadoClasse.Visible = true;
                PessoaFrmMinisterioSelecionar.Visible = true;
                PessoaFrmImagemSelecionar.Visible = true;
                if ( modelo is PessoaDado || ModeloNovo is PessoaDado)
                {
                    PessoaFrmEnderecoSelecionar.Visible = true;
                    PessoaFrmTelefoneSelecionar.Visible = true;
                    PessoaFrmCpfSelecionar.Visible = true;
                    PessoaFrmEmailSelecionar.Visible = false;
                }
                else
                if ( modelo is PessoaLgpd || ModeloNovo is PessoaLgpd)
                {
                    PessoaFrmCpfSelecionar.Visible = false;
                    PessoaFrmEmailSelecionar.Visible = true;
                }
            }

            if ( modelo is Ministerio && this is Formulario.FormularioMinisterio.FrmMinisterio ||
                ModeloNovo is Ministerio && this is Formulario.FormularioMinisterio.FrmMinisterio)
            {
                DadoMinisterioSelecionar.Visible = true;
                MinisterioFrmPessoaSelecionar.Visible = true;
                MinisterioFrmNomeSelecionar.Visible = true;
            }

            if (modelo is Celula && this is FrmCelula)
            {
                DadoCelulaSelecionar.Visible = true;
                CelulaFrmEnderecoCelulaSelecionar.Visible = true;
                CelulaFrmDia_semanaSelecionar.Visible = true;
                CelulaFrmMinisteriosSelecionar.Visible = true;
            }

            if (modelo is Reuniao && this is FrmReuniao)
            {
                ReuniaoFrmLocal_reuniaoSelecionar.Visible = true;
                ReuniaoFrmPessoasSelecionar.Visible = true;
            }

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes)
                Proximo.Visible = true;

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is FrmCelula ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is Formulario.FormularioMinisterio.FrmMinisterio ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is Formulario.Pessoas.FormCrudPessoa.FrmPessoa ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is FrmReuniao || modelo != null &&  modelo.GetType().IsSubclassOf(typeof(Movimentacao)) &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes ||
                this is FrmFonte &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes)
            {
                Proximo.Visible = false;
                if (modelo != null)
                    FinalizarCadastro.Visible = true;
                else if (ModeloNovo != null)
                    FazerMudanca.Visible = true;
            }

            if (CondicaoAtualizar)
                Atualizar.Visible = true;


            if (CondicaoDeletar)
                Deletar.Visible = true;

            if (CondicaoDetalhes)
            {
                foreach (var item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        var t = (TextBox)item;
                        t.ReadOnly = true;
                    }
                    if (item is MaskedTextBox)
                    {
                        var t = (MaskedTextBox)item;
                        t.ReadOnly = true;
                    }

                    if (item is Button && !(this is Formulario.FormularioMinisterio.FrmMinisterio) &&
                        !(this is Formulario.Pessoas.FormCrudPessoa.FrmPessoa) && !(this is FrmCelula) &&
                        !(this is FrmReuniao))
                    {
                        var t = (Button)item;
                        t.Enabled = false;
                    }
                }
            }
        }

        private void LoadForm()
        {
            LoadFormCrud(modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar, this);
        }

        private async void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizarCadastro.Enabled = false;

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa), BDcomum.conecta1);
                p.Codigo = ultimoRegistro + 1;
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio), BDcomum.conecta1);
                p.Codigo = ultimoRegistro + 1;
                p.Maximo_pessoa = 50;
            }

            FormProgressBar2 frm = new FormProgressBar2();
            try
            {
                if (BDcomum.TestarConexao())
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Aguarde o processamento ...";
                    frm.Show();
                    await new FrmPrincipal().AtualizarDadosRemotos();
                    modelo.salvar();
                    frm.Dispose();
                    modelocrud.Modelos.Add(modelo);
                }
                else
                {
                    if (!frm.IsDisposed)
                        frm.Dispose();
                    MessageBox.Show("Conecte-se a internet.");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (!frm.IsDisposed)
                    frm.Dispose();
                MessageBox.Show(modelo.exibirMensagemErro(ex, 1));
                FinalizarCadastro.Enabled = true;
                return;
            }

            if (modelo is Pessoa && !BDcomum.BancoEnbarcado)
            {
                var p = (Pessoa)modelo;
                {
                    try
                    {
                        var photoRequest = new PhotoRequest
                        {
                            Id = p.Id,
                            Array = p.ImgArrayBytes
                        };
                        var resultado = await p.EnviarFoto(photoRequest);

                        if (!resultado) MessageBox.Show("Foto não enviada.");
                        else
                        {
                            p.Imagem = "/Content/Imagens/" + p.Id.ToString() + ".jpg";
                            p.alterar(p.Id);
                        }

                    }
                    catch { MessageBox.Show("Foto não enviada."); }
                }
            }

            MessageBox.Show("Cadastro realiado com sucesso.");
            this.Close();
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, this);
        }

        public void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false)
        {
            crudForm.Clicar(form, function, Modelo, detalhes, deletar, atualizar);
        }
    }
}
