using business.classes;
using business.classes.Abstrato;
using business.classes.financeiro;
using business.classes.Intermediario;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud : FormPadrao
    {

        private Label InfoForm;
        private WFCrud frm = null;

        // botões para crud
        private Button proximo;
        private Button Deletar;
        private Button atualizar;
        private Button finalizarCadastro;


        // botões para select: PESSOA
        private Button dadoPessoal;
        private Button dadoFoto;
        private Button dadoEnderecoPessoa;
        private Button dadoContato;
        private Button dadoClasse;
        private Button dadoMinisteriosPessoa;

        //botões para select: CELULA
        private Button dadoCelula;
        private Button dadoEnderecoCelula;
        private Button dadoCelulaMinisterio;
        private Button dadoCelulaPessoas;

        //botões para select: MINISTERIO
        private Button dadoMinisterio;
        private Button dadoMinisterioPessoas;
        private Button dadoMinistro;

        //botoes para select: Reuniao
        private Button dadoReuniao;
        private Button dadoReuniaoPessoas;

        public modelocrud modelo { get; set; }
        private modelocrud modeloVelho;
        private modelocrud modeloNovo;
        public bool CondicaoDeletar { get => condicaoDeletar; set => condicaoDeletar = value; }
        public bool CondicaoAtualizar { get => condicaoAtualizar; set => condicaoAtualizar = value; }
        public bool CondicaoDetalhes { get => condicaoDetalhes; set => condicaoDetalhes = value; }
        public static string AddNaListaCelulaMinisterios
        { get => addNaListaCelulaMinisterios; set => addNaListaCelulaMinisterios = value; }
        public static string AddNaListaMinisterioPessoas
        { get => addNaListaMinisterioPessoas; set => addNaListaMinisterioPessoas = value; }
        public static string AddNaListaMinisterioCelulas
        { get => addNaListaMinisterioCelulas; set => addNaListaMinisterioCelulas = value; }
        public static string AddNaListaPessoaMinsterios
        { get => addNaListaPessoaMinsterios; set => addNaListaPessoaMinsterios = value; }
        public static string AddNaListaPessoaReunioes
        { get => addNaListaPessoaReunioes; set => addNaListaPessoaReunioes = value; }
        public static string AddNaListaReuniaoPessoas
        { get => addNaListaReuniaoPessoas; set => addNaListaReuniaoPessoas = value; }
        public Button Proximo { get => proximo; set => proximo = value; }
        public Button Atualizar { get => atualizar; set => atualizar = value; }
        public modelocrud ModeloNovo { get => modeloNovo; set => modeloNovo = value; }
        public modelocrud ModeloVelho { get => modeloVelho; set => modeloVelho = value; }
        public Button FinalizaCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }

        private bool condicaoDeletar;
        private bool condicaoAtualizar;
        private bool condicaoDetalhes;
        private static string addNaListaCelulaMinisterios;
        private static string addNaListaMinisterioCelulas;
        private static string addNaListaMinisterioPessoas;
        private static string addNaListaPessoaMinsterios;
        private static string addNaListaPessoaReunioes;
        private static string addNaListaReuniaoPessoas;


        public WFCrud()
        {

            this.FormClosing += WFCrud_FormClosing;

            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);

            dadoReuniao = new Button();
            dadoReuniao.Location = new Point(50, 50);
            dadoReuniao.Size = new Size(100, 50);
            dadoReuniao.Text = "Dados da reunião";
            dadoReuniao.Click += DadoReuniao_Click;
            dadoReuniao.Visible = false;

            dadoReuniaoPessoas = new Button();
            dadoReuniaoPessoas.Location = new Point(200, 50);
            dadoReuniaoPessoas.Size = new Size(100, 50);
            dadoReuniaoPessoas.Text = "pessoas da reunião";
            dadoReuniaoPessoas.Click += DadoReuniaoPessoas_Click;
            dadoReuniaoPessoas.Visible = false;

            dadoPessoal = new Button();
            dadoPessoal.Location = new Point(50, 50);
            dadoPessoal.Size = new Size(100, 50);
            dadoPessoal.Text = "Dados Pessoais";
            dadoPessoal.Click += DadoPessoal_Click;
            dadoPessoal.Visible = false;

            dadoEnderecoPessoa = new Button();
            dadoEnderecoPessoa.Location = new Point(200, 50);
            dadoEnderecoPessoa.Size = new Size(100, 50);
            dadoEnderecoPessoa.Text = "Endereço da pessoa";
            dadoEnderecoPessoa.Click += DadoEnderecoPessoa_Click;
            dadoEnderecoPessoa.Visible = false;

            dadoContato = new Button();
            dadoContato.Location = new Point(200, 160);
            dadoContato.Size = new Size(100, 50);
            dadoContato.Text = "Contatos";
            dadoContato.Click += DadoContato_Click;
            dadoContato.Visible = false;

            dadoClasse = new Button();
            dadoClasse.Location = new Point(50, 160);
            dadoClasse.Size = new Size(100, 50);
            dadoClasse.Text = "Dados de classe";
            dadoClasse.Click += DadoClasse_Click;
            dadoClasse.Visible = false;

            dadoMinisteriosPessoa = new Button();
            dadoMinisteriosPessoa.Location = new Point(50, 270);
            dadoMinisteriosPessoa.Size = new Size(100, 50);
            dadoMinisteriosPessoa.Text = "Ministerios da pessoa";
            dadoMinisteriosPessoa.Click += DadoMinisterioPessoas_Click1;
            dadoMinisteriosPessoa.Visible = false;

            dadoFoto = new Button();
            dadoFoto.Location = new Point(200, 270);
            dadoFoto.Size = new Size(100, 50);
            dadoFoto.Text = "Foto da pessoa";
            dadoFoto.Click += DadoFoto_Click;
            dadoFoto.Visible = false;

            dadoCelula = new Button();
            dadoCelula.Location = new Point(50, 50);
            dadoCelula.Size = new Size(100, 50);
            dadoCelula.Text = "Dados de celula";
            dadoCelula.Click += DadoCelula_Click;
            dadoCelula.Visible = false;

            dadoEnderecoCelula = new Button();
            dadoEnderecoCelula.Location = new Point(200, 50);
            dadoEnderecoCelula.Size = new Size(100, 50);
            dadoEnderecoCelula.Text = "Endereço da celula";
            dadoEnderecoCelula.Click += DadoEnderecoCelula_Click;
            dadoEnderecoCelula.Visible = false;

            dadoCelulaMinisterio = new Button();
            dadoCelulaMinisterio.Location = new Point(200, 160);
            dadoCelulaMinisterio.Size = new Size(100, 50);
            dadoCelulaMinisterio.Text = "Ministérios da celula";
            dadoCelulaMinisterio.Click += DadoCelulaMinisterio_Click;
            dadoCelulaMinisterio.Visible = false;

            dadoCelulaPessoas = new Button();
            dadoCelulaPessoas.Location = new Point(50, 160);
            dadoCelulaPessoas.Size = new Size(100, 50);
            dadoCelulaPessoas.Text = "Pessoas da celula";
            dadoCelulaPessoas.Click += DadoCelulaPessoas_Click;
            dadoCelulaPessoas.Visible = false;

            dadoMinisterio = new Button();
            dadoMinisterio.Location = new Point(50, 50);
            dadoMinisterio.Size = new Size(100, 50);
            dadoMinisterio.Text = "Dados do Ministério";
            dadoMinisterio.Click += DadoMinisterio_Click;
            dadoMinisterio.Visible = false;

            dadoMinisterioPessoas = new Button();
            dadoMinisterioPessoas.Location = new Point(200, 50);
            dadoMinisterioPessoas.Size = new Size(100, 50);
            dadoMinisterioPessoas.Text = "Pessoas do ministério";
            dadoMinisterioPessoas.Click += DadoMinisterioPessoas_Click;
            dadoMinisterioPessoas.Visible = false;

            dadoMinistro = new Button();
            dadoMinistro.Location = new Point(200, 160);
            dadoMinistro.Size = new Size(100, 50);
            dadoMinistro.Text = "Ministro do ministério";
            dadoMinistro.Click += DadoMinistro_Click;
            dadoMinistro.Visible = false;

            Proximo = new Button();
            Proximo.Click += Proximo_Click;
            Proximo.Text = "Proximo";
            Proximo.Location = new Point(650, 150);
            Proximo.Size = new Size(100, 50);

            Deletar = new Button();
            Deletar.Click += Deletar_Click;
            Deletar.Text = "Deletar";
            Deletar.Location = new Point(650, 250);
            Deletar.Size = new Size(100, 50);
            Deletar.Visible = false;

            Atualizar = new Button();
            Atualizar.Click += Atualizar_Click;
            Atualizar.Text = "Atualizar";
            Atualizar.Location = new Point(650, 350);
            Atualizar.Size = new Size(100, 50);
            Atualizar.Visible = false;

            FinalizaCadastro = new Button();
            FinalizaCadastro.Click += FinalizarCadastro_Click;
            FinalizaCadastro.Text = "Finalizar Cadastro";
            FinalizaCadastro.Location = new Point(650, 250);
            FinalizaCadastro.Size = new Size(100, 50);
            FinalizaCadastro.Visible = false;

            this.Controls.Add(Proximo);
            this.Controls.Add(Deletar);
            this.Controls.Add(Atualizar);
            this.Controls.Add(FinalizaCadastro);

            this.Controls.Add(dadoPessoal);
            this.Controls.Add(dadoEnderecoPessoa);
            this.Controls.Add(dadoClasse);
            this.Controls.Add(dadoContato);
            this.Controls.Add(dadoMinisteriosPessoa);
            this.Controls.Add(dadoFoto);

            this.Controls.Add(dadoCelula);
            this.Controls.Add(dadoEnderecoCelula);
            this.Controls.Add(dadoCelulaMinisterio);
            this.Controls.Add(dadoCelulaPessoas);

            this.Controls.Add(dadoMinisterio);
            this.Controls.Add(dadoMinisterioPessoas);
            this.Controls.Add(dadoMinistro);

            this.Controls.Add(dadoReuniao);
            this.Controls.Add(dadoReuniaoPessoas);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);


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
                if (model.recuperar(modelo.Id)) pes = model;
                modelocrud.Modelos.Remove(modelocrud.Modelos.Where(m => m.GetType() == modelo.GetType())
                .ToList().First(i => i.Id == modelo.Id));
                modelocrud.Modelos.Add(pes);
            }

            this.Dispose();
        }

        private void DadoReuniao_Click(object sender, EventArgs e)
        {
            DadoReuniao frm = new DadoReuniao();
            LoadFormCrud();
        }

        private void DadoReuniaoPessoas_Click(object sender, EventArgs e)
        {
            frm = new PessoasReuniao();
            LoadFormCrud();
        }

        public WFCrud(modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
        }

        public WFCrud(bool deletar, bool atualizar, bool detalhes,
        modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
            condicaoDeletar = deletar;
            condicaoAtualizar = atualizar;
            condicaoDetalhes = detalhes;

            Proximo = new Button();
            Proximo.Click += Proximo_Click;
            Proximo.Text = "Proximo";
            Proximo.Location = new Point(650, 150);
            Proximo.Size = new Size(100, 50);

            this.Controls.Add(Proximo);
        }

        private void WFCrud_Load(object sender, EventArgs e)
        {

        }

        private void DadoCelula_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCrud();
        }

        private void DadoEnderecoCelula_Click(object sender, EventArgs e)
        {
            frm = new FrmEnderecoCelula();
            LoadFormCrud();
        }

        private void DadoCelulaMinisterio_Click(object sender, EventArgs e)
        {
            frm = new MinisteriosCelula();
            LoadFormCrud();
        }

        private void DadoCelulaPessoas_Click(object sender, EventArgs e)
        {
            frm = new MinisteriosCelula();
            LoadFormCrud();
        }

        private void DadoMinisterio_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCrud();
        }

        private void DadoMinisterioPessoas_Click(object sender, EventArgs e)
        {
            frm = new PessoasCelulasMinisterio();
            LoadFormCrud();
        }

        private void DadoMinistro_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCrud();
        }

        private void DadoMinisterioPessoas_Click1(object sender, EventArgs e)
        {
            frm = new ReunioesMinisteriosPessoa();
            LoadFormCrud();
        }

        private void DadoContato_Click(object sender, EventArgs e)
        {
            frm = new Contato();
            LoadFormCrud();
        }

        private void DadoEnderecoPessoa_Click(object sender, EventArgs e)
        {
            frm = new FrmEndereco();
            LoadFormCrud();
        }

        private void DadoPessoal_Click(object sender, EventArgs e)
        {
            if (modelo is PessoaDado)
                frm = new DadoPessoal();
            if (modelo is PessoaLgpd)
                frm = new DadoPessoalLgpd();
            LoadFormCrud();
        }

        public void LoadForm()
        {
            if (condicaoAtualizar || condicaoDeletar || condicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizaCadastro.Visible = false;

                if (modelo is PessoaDado)
                {
                    var pessoa = (PessoaDado)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() +
                    " - " + pessoa.NomePessoa;
                }
                else
                if (modelo is PessoaLgpd)
                {
                    var pessoa = (PessoaLgpd)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() +
                        " - " + pessoa.Email;
                }
                else
                if (modelo is Celula)
                {
                    var celula = (Celula)modelo;
                    InfoForm.Text = "Identificação: " + celula.Id.ToString() +
                    " - " + celula.Nome;
                }
                else if (modelo is Ministerio)
                {
                    var m = (Ministerio)modelo;
                    InfoForm.Text = "Identificação: " + m.Id.ToString() +
                    " - " + m.Nome;
                }
                else if (modelo is Reuniao)
                {
                    var p = (Reuniao)modelo;
                    InfoForm.Text = "Identificação: " + p.Id.ToString() + " - ";
                }

            }

            if (modelo is Pessoa && this is FrmPessoa)
            {
                dadoPessoal.Visible = true;
                dadoClasse.Visible = true;
                dadoMinisteriosPessoa.Visible = true;
                dadoFoto.Visible = true;
                if (modelo is PessoaDado)
                {
                    dadoEnderecoPessoa.Visible = true;
                    dadoContato.Visible = true;
                }
            }

            if (modelo is Ministerio && this is FrmMinisterio)
            {
                dadoMinisterio.Visible = true;
                dadoMinisterioPessoas.Visible = true;
                dadoMinistro.Visible = true;
            }

            if (modelo is Celula && this is FrmCelula)
            {
                dadoCelula.Visible = true;
                dadoEnderecoCelula.Visible = true;
                dadoCelulaMinisterio.Visible = true;
                dadoCelulaPessoas.Visible = true;
            }

            if (modelo is Reuniao && this is FrmReuniao)
            {
                dadoReuniao.Visible = true;
                dadoReuniaoPessoas.Visible = true;
            }

            if (!CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes)
                Proximo.Visible = true;

            if (!CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FrmCelula ||
                !CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FrmMinisterio ||
                !CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FrmPessoa ||
                !CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FrmReuniao || modelo.GetType().IsSubclassOf(typeof(Movimentacao)) &&
                !CondicaoAtualizar && !condicaoDeletar && !condicaoDetalhes)
            {
                Proximo.Visible = false;
                FinalizaCadastro.Visible = true;
            }

            if (CondicaoAtualizar)
                Atualizar.Visible = true;


            if (condicaoDeletar)
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

                    if (item is Button && !(this is FrmMinisterio) &&
                        !(this is FrmPessoa) && !(this is FrmCelula) &&
                        !(this is FrmReuniao))
                    {
                        var t = (Button)item;
                        t.Enabled = false;
                    }
                }
            }
        }

        private void LoadFormCrud()
        {
            frm.modelo = modelo;
            frm.CondicaoDetalhes = CondicaoDetalhes;
            frm.CondicaoDeletar = CondicaoDeletar;
            frm.CondicaoAtualizar = CondicaoAtualizar;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private async void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizaCadastro.Enabled = false;

            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    p.Ministerios = new List<MinisterioCelula>();
                    foreach (var item in arr)
                    {
                        p.Ministerios.Add(new MinisterioCelula { CelulaId = p.Id, MinisterioId = int.Parse(item), Celula = p });
                        p.Ministerios = p.Ministerios;
                    }
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                {
                    var arr = AddNaListaMinisterioPessoas.Replace(" ", "").Split(',');
                    p.Pessoas = new List<PessoaMinisterio>();
                    foreach (var item in arr)
                    {
                        p.Pessoas.Add(new PessoaMinisterio { PessoaId = int.Parse(item), MinisterioId = p.Id, Ministerio = p });
                        p.Pessoas = p.Pessoas;
                    }
                }

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                {
                    var arr = AddNaListaMinisterioCelulas.Replace(" ", "").Split(',');
                    p.Celulas = new List<MinisterioCelula>();
                    foreach (var item in arr)
                    {
                        p.Celulas.Add(new MinisterioCelula { CelulaId = int.Parse(item), MinisterioId = p.Id, Ministerio = p });
                        p.Celulas = p.Celulas;
                    }
                }
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                {
                    var arr = AddNaListaPessoaMinsterios.Replace(" ", "").Split(',');
                    p.Ministerios = new List<PessoaMinisterio>();
                    foreach (var item in arr)
                    {
                        p.Ministerios.Add(new PessoaMinisterio { PessoaId = p.Id, MinisterioId = int.Parse(item), Pessoa = p });
                        p.Ministerios = p.Ministerios;
                    }
                }

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                {
                    var arr = AddNaListaPessoaReunioes.Replace(" ", "").Split(',');
                    p.Reuniao = new List<ReuniaoPessoa>();
                    foreach (var item in arr)
                    {
                        p.Reuniao.Add(new ReuniaoPessoa { PessoaId = p.Id, ReuniaoId = int.Parse(item), Pessoa = p });
                        p.Reuniao = p.Reuniao;
                    }
                }

                var ultimoRegistro = new BDcomum().GetUltimoRegistroPessoa();
                p.Codigo = ultimoRegistro + 1;
            }

            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                {
                    var arr = AddNaListaReuniaoPessoas.Replace(" ", "").Split(',');
                    p.Pessoas = new List<ReuniaoPessoa>();
                    foreach (var item in arr)
                    {
                        p.Pessoas.Add(new ReuniaoPessoa { PessoaId = int.Parse(item), ReuniaoId = p.Id });
                        p.Pessoas = p.Pessoas;
                    }
                }
            }

            try { modelo.salvar(); }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 1));
                FinalizaCadastro.Enabled = true;
                return;
            }

            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (p.Ministerios != null)
                    foreach (var item in p.Ministerios)
                    {
                        if (item.CelulaId == 0) item.CelulaId = item.Celula.Id;
                        if (item.MinisterioId == 0) item.MinisterioId = item.Ministerio.Id;
                        item.salvar();
                    }
            }
            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (p.Pessoas != null)
                    foreach (var item in p.Pessoas)
                    {
                        if (item.PessoaId == 0) item.PessoaId = item.Pessoa.Id;
                        if (item.MinisterioId == 0) item.MinisterioId = item.Ministerio.Id;
                        item.salvar();
                    }
                if (p.Celulas != null)
                    foreach (var item in p.Celulas)
                    {
                        if (item.CelulaId == 0) item.CelulaId = item.Celula.Id;
                        if (item.MinisterioId == 0) item.MinisterioId = item.Ministerio.Id;
                        item.salvar();
                    }
            }
            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (p.Ministerios != null)
                    foreach (var item in p.Ministerios)
                    {
                        if (item.PessoaId == 0) item.PessoaId = item.Pessoa.Id;
                        if (item.MinisterioId == 0) item.MinisterioId = item.Ministerio.Id;
                        item.salvar();
                    }
                if (p.Reuniao != null)
                    foreach (var item in p.Reuniao)
                    {
                        if (item.PessoaId == 0) item.PessoaId = item.Pessoa.Id;
                        if (item.ReuniaoId == 0) item.ReuniaoId = item.Reuniao.Id;
                        item.salvar();
                    }
            }
            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                if (p.Pessoas != null)
                    foreach (var item in p.Pessoas)
                    {
                        if (item.PessoaId == 0) item.PessoaId = item.Pessoa.Id;
                        if (item.ReuniaoId == 0) item.ReuniaoId = item.Reuniao.Id;
                        item.salvar();
                    }
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
                            p.Img = "/Content/Imagens/" + p.Id.ToString() + ".jpg";
                            p.alterar(p.Id);
                        }

                    }
                    catch { MessageBox.Show("Foto não enviada."); }
                }
            }

            MessageBox.Show("Cadastro realiado com sucesso.");
            this.Close();

        }
    }
}
