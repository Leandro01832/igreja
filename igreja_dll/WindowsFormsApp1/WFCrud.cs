using business.classes;
using business.classes.Abstrato;
using business.classes.financeiro;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud : Form, IFormCrud
    {
        public MdiForm crudForm;

        private Label infoForm;

        // botões para crud
        private Button proximo;
        private Button deletar;
        private Button atualizar;
        private Button finalizarCadastro;


        // botões para select: PESSOA
        private Button dadoPessoal;
        private Button dadoPessoalLgpd;
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
        

        public Button Proximo { get => proximo; set => proximo = value; }
        public Button Atualizar { get => atualizar; set => atualizar = value; }
        public Button FinalizaCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }
        public Button Deletar { get => deletar; set => deletar = value; }
        public modelocrud ModeloNovo { get => modeloNovo; set => modeloNovo = value; }
        public modelocrud ModeloVelho { get => modeloVelho; set => modeloVelho = value; }
        public Button PessoaFrmCpfSelecionar { get => dadoPessoal; set => dadoPessoal = value; }
        public Button PessoaFrmEmailSelecionar { get => dadoPessoalLgpd; set => dadoPessoalLgpd = value; }
        public Button PessoaFrmImgSelecionar { get => dadoFoto; set => dadoFoto = value; }
        public Button PessoaFrmEnderecoSelecionar { get => dadoEnderecoPessoa; set => dadoEnderecoPessoa = value; }
        public Button PessoaFrmTelefoneSelecionar { get => dadoContato; set => dadoContato = value; }
        public Button DadoClasse { get => dadoClasse; set => dadoClasse = value; }
        public Button PessoaFrmMinisterioSelecionar { get => dadoMinisteriosPessoa; set => dadoMinisteriosPessoa = value; }
        public Button DadoCelula { get => dadoCelula; set => dadoCelula = value; }
        public Button CelulaFrmEnderecoCelulaSelecionar { get => dadoEnderecoCelula; set => dadoEnderecoCelula = value; }
        public Button CelulaFrmDia_semanaSelecionar { get => dadoCelulaMinisterio; set => dadoCelulaMinisterio = value; }
        public Button CelulaFrmMinisteriosSelecionar { get => dadoCelulaPessoas; set => dadoCelulaPessoas = value; }
        public Button DadoMinisterio { get => dadoMinisterio; set => dadoMinisterio = value; }
        public Button MinisterioFrmPessoaSelecionar { get => dadoMinisterioPessoas; set => dadoMinisterioPessoas = value; }
        public Button MinisterioFrmNomeSelecionar { get => dadoMinistro; set => dadoMinistro = value; }
        public Button ReuniaoFrmLocal_reuniaoSelecionar { get => dadoReuniao; set => dadoReuniao = value; }
        public Button ReuniaoFrmPessoasSelecionar { get => dadoReuniaoPessoas; set => dadoReuniaoPessoas = value; }
        public Label InfoForm { get => infoForm; set => infoForm = value; }
        
        private bool condicaoDeletar;
        private bool condicaoAtualizar;
        private bool condicaoDetalhes;


        public WFCrud()
        {
            crudForm = new MdiForm();
            this.FormClosing += WFCrud_FormClosing;

            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);
            
            ReuniaoFrmLocal_reuniaoSelecionar = new Button();
            ReuniaoFrmLocal_reuniaoSelecionar.Location = new Point(50, 50);
            ReuniaoFrmLocal_reuniaoSelecionar.Size = new Size(100, 50);
            ReuniaoFrmLocal_reuniaoSelecionar.Text = "Dados da reunião";
            ReuniaoFrmLocal_reuniaoSelecionar.Click += ReuniaoFrmLocal_reuniaoSelecionar_Click;
            ReuniaoFrmLocal_reuniaoSelecionar.Visible = false;

            ReuniaoFrmPessoasSelecionar = new Button();
            ReuniaoFrmPessoasSelecionar.Location = new Point(200, 50);
            ReuniaoFrmPessoasSelecionar.Size = new Size(100, 50);
            ReuniaoFrmPessoasSelecionar.Text = "pessoas da reunião";
            ReuniaoFrmPessoasSelecionar.Click += ReuniaoFrmPessoasSelecionar_Click;
            ReuniaoFrmPessoasSelecionar.Visible = false;

            PessoaFrmCpfSelecionar = new Button();
            PessoaFrmCpfSelecionar.Location = new Point(50, 50);
            PessoaFrmCpfSelecionar.Size = new Size(100, 50);
            PessoaFrmCpfSelecionar.Text = "Dados Pessoais";
            PessoaFrmCpfSelecionar.Click += PessoaFrmCpfSelecionar_Click;
            PessoaFrmCpfSelecionar.Visible = false;

            PessoaFrmEmailSelecionar = new Button();
            PessoaFrmEmailSelecionar.Location = new Point(50, 50);
            PessoaFrmEmailSelecionar.Size = new Size(100, 50);
            PessoaFrmEmailSelecionar.Text = "Dados Pessoais LGPD";
            PessoaFrmEmailSelecionar.Click += PessoaFrmEmailSelecionar_Click;
            PessoaFrmEmailSelecionar.Visible = false;

            PessoaFrmEnderecoSelecionar = new Button();
            PessoaFrmEnderecoSelecionar.Location = new Point(200, 50);
            PessoaFrmEnderecoSelecionar.Size = new Size(100, 50);
            PessoaFrmEnderecoSelecionar.Text = "Endereço da pessoa";
            PessoaFrmEnderecoSelecionar.Click += PessoaFrmEnderecoSelecionar_Click;
            PessoaFrmEnderecoSelecionar.Visible = false;

            PessoaFrmTelefoneSelecionar = new Button();
            PessoaFrmTelefoneSelecionar.Location = new Point(200, 160);
            PessoaFrmTelefoneSelecionar.Size = new Size(100, 50);
            PessoaFrmTelefoneSelecionar.Text = "Contatos";
            PessoaFrmTelefoneSelecionar.Click += PessoaFrmTelefoneSelecionar_Click;
            PessoaFrmTelefoneSelecionar.Visible = false;

            PessoaFrmMinisterioSelecionar = new Button();
            PessoaFrmMinisterioSelecionar.Location = new Point(50, 270);
            PessoaFrmMinisterioSelecionar.Size = new Size(100, 50);
            PessoaFrmMinisterioSelecionar.Text = "Ministerios da pessoa";
            PessoaFrmMinisterioSelecionar.Click += PessoaFrmMinisterioSelecionar_Click;
            PessoaFrmMinisterioSelecionar.Visible = false;

            PessoaFrmImgSelecionar = new Button();
            PessoaFrmImgSelecionar.Location = new Point(200, 270);
            PessoaFrmImgSelecionar.Size = new Size(100, 50);
            PessoaFrmImgSelecionar.Text = "Foto da pessoa";
            PessoaFrmImgSelecionar.Click += PessoaFrmImgSelecionar_Click;
            PessoaFrmImgSelecionar.Visible = false;

            CelulaFrmEnderecoCelulaSelecionar = new Button();
            CelulaFrmEnderecoCelulaSelecionar.Location = new Point(200, 50);
            CelulaFrmEnderecoCelulaSelecionar.Size = new Size(100, 50);
            CelulaFrmEnderecoCelulaSelecionar.Text = "Endereço da celula";
            CelulaFrmEnderecoCelulaSelecionar.Click += CelulaFrmEnderecoCelulaSelecionar_Click;
            CelulaFrmEnderecoCelulaSelecionar.Visible = false;

            CelulaFrmDia_semanaSelecionar = new Button();
            CelulaFrmDia_semanaSelecionar.Location = new Point(200, 160);
            CelulaFrmDia_semanaSelecionar.Size = new Size(100, 50);
            CelulaFrmDia_semanaSelecionar.Text = "Ministérios da celula";
            CelulaFrmDia_semanaSelecionar.Click += CelulaFrmDia_semanaSelecionar_Click;
            CelulaFrmDia_semanaSelecionar.Visible = false;

            CelulaFrmMinisteriosSelecionar = new Button();
            CelulaFrmMinisteriosSelecionar.Location = new Point(50, 160);
            CelulaFrmMinisteriosSelecionar.Size = new Size(100, 50);
            CelulaFrmMinisteriosSelecionar.Text = "Pessoas da celula";
            CelulaFrmMinisteriosSelecionar.Click += CelulaFrmMinisteriosSelecionar_Click;
            CelulaFrmMinisteriosSelecionar.Visible = false;

            MinisterioFrmPessoaSelecionar = new Button();
            MinisterioFrmPessoaSelecionar.Location = new Point(200, 50);
            MinisterioFrmPessoaSelecionar.Size = new Size(100, 50);
            MinisterioFrmPessoaSelecionar.Text = "Pessoas do ministério";
            MinisterioFrmPessoaSelecionar.Click += MinisterioFrmPessoaSelecionar_Click;
            MinisterioFrmPessoaSelecionar.Visible = false;

            MinisterioFrmNomeSelecionar = new Button();
            MinisterioFrmNomeSelecionar.Location = new Point(200, 160);
            MinisterioFrmNomeSelecionar.Size = new Size(100, 50);
            MinisterioFrmNomeSelecionar.Text = "Ministro do ministério";            
            MinisterioFrmNomeSelecionar.Click += MinisterioFrmNomeSelecionar_Click;
            MinisterioFrmNomeSelecionar.Visible = false;

            DadoCelula = new Button();
            DadoCelula.Location = new Point(50, 50);
            DadoCelula.Size = new Size(100, 50);
            DadoCelula.Text = "Dados de celula";
            DadoCelula.Click += DadoCelula_Click;
            DadoCelula.Visible = false;

            DadoMinisterio = new Button();
            DadoMinisterio.Location = new Point(50, 50);
            DadoMinisterio.Size = new Size(100, 50);
            DadoMinisterio.Text = "Dados do Ministério";
            DadoMinisterio.Click += DadoMinisterio_Click;
            DadoMinisterio.Visible = false;

            DadoClasse = new Button();
            DadoClasse.Location = new Point(50, 160);
            DadoClasse.Size = new Size(100, 50);
            DadoClasse.Text = "Dados de classe";
            DadoClasse.Click += DadoClasse_Click;
            DadoClasse.Visible = false;

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

            this.Controls.Add(PessoaFrmCpfSelecionar);
            this.Controls.Add(PessoaFrmEnderecoSelecionar);
            this.Controls.Add(DadoClasse);
            this.Controls.Add(PessoaFrmTelefoneSelecionar);
            this.Controls.Add(PessoaFrmMinisterioSelecionar);
            this.Controls.Add(PessoaFrmImgSelecionar);

            this.Controls.Add(DadoCelula);
            this.Controls.Add(CelulaFrmEnderecoCelulaSelecionar);
            this.Controls.Add(CelulaFrmDia_semanaSelecionar);
            this.Controls.Add(CelulaFrmMinisteriosSelecionar);

            this.Controls.Add(DadoMinisterio);
            this.Controls.Add(MinisterioFrmPessoaSelecionar);
            this.Controls.Add(MinisterioFrmNomeSelecionar);

            this.Controls.Add(ReuniaoFrmLocal_reuniaoSelecionar);
            this.Controls.Add(ReuniaoFrmPessoasSelecionar);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);
            
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
                if (model.recuperar(modelo.Id)) pes = model;
                
                modelocrud.Modelos.Remove(modelocrud.Modelos.Where(m => m.GetType() == modelo.GetType())
                .ToList().First(i => i.Id == modelo.Id));
                modelocrud.Modelos.Add(pes);
            }

            this.Dispose();
        }

        public void    ReuniaoFrmLocal_reuniaoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmLocal_reuniaoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    ReuniaoFrmPessoasSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmPessoasSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    DadoCelula_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    CelulaFrmEnderecoCelulaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmEnderecoCelulaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void     CelulaFrmDia_semanaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this,  "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    CelulaFrmMinisteriosSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmMinisteriosSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    DadoMinisterio_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    MinisterioFrmPessoaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmPessoaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    MinisterioFrmNomeSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmMinisterioSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmMinisterioSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmTelefoneSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmTelefoneSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmEnderecoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEnderecoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmCpfSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmCpfSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmEmailSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEmailSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        public void    PessoaFrmImgSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmImgSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }

        public void LoadCrudForm()
        {
            FrmPrincipal.LoadForm(this);

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes && modelo.anular)
            {
                modelocrud.anularDados(modelo);
                modelo.anular = false;
                modelo.stringConexao = BDcomum.conecta1;
            }

            if(modelo is PessoaDado)
            {
                PessoaFrmCpfSelecionar.Visible = true;
                PessoaFrmEmailSelecionar.Visible = false;
            }
            else
            if (modelo is PessoaLgpd)
            {
                PessoaFrmCpfSelecionar.Visible = false;
                PessoaFrmEmailSelecionar.Visible = true;
            }

            if (CondicaoAtualizar || CondicaoDeletar || CondicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizaCadastro.Visible = false;

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
                    InfoForm.Text = "Identificação: " + propId.GetValue(modelo).ToString();
            }

            if (modelo is Pessoa && this is Formulario.Pessoas.FormCrudPessoa.FrmPessoa)
            {
                PessoaFrmCpfSelecionar.Visible = true;
                DadoClasse.Visible = true;
                PessoaFrmMinisterioSelecionar.Visible = true;
                PessoaFrmImgSelecionar.Visible = true;
                if (modelo is PessoaDado)
                {
                    PessoaFrmEnderecoSelecionar.Visible = true;
                    PessoaFrmTelefoneSelecionar.Visible = true;
                }
            }

            if (modelo is Ministerio && this is Formulario.FormularioMinisterio.FrmMinisterio)
            {
                DadoMinisterio.Visible = true;
                MinisterioFrmPessoaSelecionar.Visible = true;
                MinisterioFrmNomeSelecionar.Visible = true;
            }

            if (modelo is Celula && this is FrmCelula)
            {
                DadoCelula.Visible = true;
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
                this is FrmReuniao || modelo.GetType().IsSubclassOf(typeof(Movimentacao)) &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes ||
                this is FrmFonte &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes)
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
            LoadFormCrud( modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar, this);
        }

        private async void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizaCadastro.Enabled = false;            

            if(modelo is Pessoa)
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
            }

            try
            {
                if (BDcomum.TestarConexao())
                {
                    await new FrmPrincipal().AtualizarDadosRemotos();
                    modelo.salvar();
                    modelocrud.Modelos.Add(modelo);
                }
                else
                {
                    MessageBox.Show("Conecte-se a internet.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 1));
                FinalizaCadastro.Enabled = true;
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

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud( modelo, detalhes, deletar, atualizar, this);
        }

        public void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false)
        {
            crudForm.Clicar(form, function, Modelo, detalhes, deletar, atualizar);
        }
    }
}
