using business.classes.Celulas;
using database;
using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class ReunioesMinisteriosPessoa : Formulario.FormCrudPessoa
    {
        public ReunioesMinisteriosPessoa()
        {
            InitializeComponent();
        }

        public ReunioesMinisteriosPessoa(bool Deletar, bool Atualizar, bool Detalhes,
        modelocrud modeloVelho, modelocrud modeloNovo)
           : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        public ReunioesMinisteriosPessoa(modelocrud p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
            txt_ministerios.Leave += Txt_ministerios_Leave;
            txt_reunioes.Leave += Txt_reunioes_Leave;
            txt_celula.Leave += Txt_celula_Leave;
        }

        private void Txt_celula_Leave(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            bool condicao = false;

            try
            {
                if (new Celula_Adolescente().recuperar(int.Parse(txt_celula.Text)).Count > 0) condicao = true;
                if (new Celula_Adulto().recuperar(int.Parse(txt_celula.Text)).Count > 0) condicao = true;
                if (new Celula_Jovem().recuperar(int.Parse(txt_celula.Text)).Count > 0) condicao = true;
                if (new Celula_Crianca().recuperar(int.Parse(txt_celula.Text)).Count > 0) condicao = true;
                if (new Celula_Casado().recuperar(int.Parse(txt_celula.Text)).Count > 0) condicao = true;
            }
            catch { p.celula_ = null; }

            if (condicao)
                p.celula_ = int.Parse(txt_celula.Text);
            else
                p.celula_ = null;
        }

        private void Txt_reunioes_Leave(object sender, EventArgs e)
        {
            AddNaListaPessoaReunioes = txt_reunioes.Text;
        }

        private void Txt_ministerios_Leave(object sender, EventArgs e)
        {
            AddNaListaPessoaMinsterios = txt_ministerios.Text;
        }

        private void ReunioesMinisteriosPessoa_Load(object sender, EventArgs e)
        {
            this.Text = "Reuniões, celula e ministérios da pessoa.";
            var pessoa = (business.classes.Abstrato.Pessoa)modelo;
            if(pessoa != null)
            if (pessoa.IdPessoa == 0)
            {
                txt_reunioes.Text = AddNaListaPessoaReunioes;
                txt_ministerios.Text = AddNaListaPessoaMinsterios;

                txt_celula.Text = pessoa.celula_.ToString();
            }
            else
            {
                
                var ministerios = pessoa.Ministerios;
                if (ministerios != null)
                    foreach (var item in ministerios)
                    {
                        var mini = listaMinisterios.First(i => i.IdMinisterio == item.MinisterioId);
                        txt_ministerios.Text += mini.IdMinisterio.ToString() + ", ";
                    }

                var reunioes = pessoa.Reuniao;
                if (reunioes != null)
                    foreach (var item in reunioes)
                    {
                        var reu = listaReuniao.First(i => i.IdReuniao == item.ReuniaoId);
                        txt_reunioes.Text += reu.IdReuniao.ToString() + ", ";
                    }
                        

                txt_celula.Text = pessoa.celula_.ToString();
            }


        }

        private void txt_reunioes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var arr = txt_reunioes.Text.Replace(" ", "").Split(',');

                try { int teste = int.Parse(arr[0]); }
                catch
                {
                    AddNaListaPessoaReunioes = "";
                    txt_reunioes.Text = "";
                    txt_reunioes.Focus();
                    MessageBox.Show("Informe numeros de identificação de reuniões.");
                }

                if (arr[arr.Length - 1] == "")
                foreach (var valor in arr)
                {                        
                    if (valor != "")
                    {
                            int teste = int.Parse(valor);
                            try
                            {
                                var v = listaReuniao.First(i => i.IdReuniao == int.Parse(valor));
                                AddNaListaPessoaReunioes = v.IdReuniao.ToString() + ", ";
                            }
                            catch (Exception)
                            {
                                AddNaListaPessoaReunioes = "";
                                txt_reunioes.Text = "";
                                var numero = GeTotalRegistrosReunioes();
                                if(numero != listaReuniao.Count)
                                MessageBox.Show("Aguarde o processamento.");
                                else
                                MessageBox.Show("Este registro não existe no banco de dados");
                            }
                    }
                }
                
            }
            catch (Exception)
            {
                AddNaListaPessoaReunioes = "";
                txt_reunioes.Text = "";
                MessageBox.Show("Informe numeros de identificação de reuniões.");
            }
        }

        private void txt_ministerios_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddNaListaPessoaMinsterios = "";
                var arr = txt_ministerios.Text.Replace(" ", "").Split(',');

                try { int teste = int.Parse(arr[0]); }
                catch
                {
                    AddNaListaPessoaMinsterios = "";
                    txt_ministerios.Text = "";
                    txt_ministerios.Focus();
                    MessageBox.Show("Informe numeros de identificação de ministérios.");
                }

                if (arr[arr.Length - 1] == "")
                foreach (var valor in arr)
                {
                    if (valor != "")
                    {
                            int teste = int.Parse(valor);
                            try
                            {
                                var v = listaMinisterios.First(i => i.IdMinisterio == int.Parse(valor));
                                AddNaListaPessoaMinsterios += v.IdMinisterio.ToString() + ", ";
                            }
                            catch (Exception)
                            {
                                AddNaListaPessoaMinsterios = "";
                                var numero = GeTotalRegistrosMinisterios();
                                if (numero != listaMinisterios.Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                            }
                    }

                }
                
            }
            catch (Exception)
            {
                AddNaListaPessoaMinsterios = "";
                txt_ministerios.Text = "";
                MessageBox.Show("Informe numeros de identificação de ministérios.");
            }
        }

        private void txt_celula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (modelo is business.classes.Abstrato.Pessoa)
                {
                    var p = (business.classes.Abstrato.Pessoa)modelo;
                    p.celula_ = int.Parse(txt_celula.Text);
                }

            }
            catch (Exception)
            {
                txt_celula.Text = "";
                MessageBox.Show("Informe um numero de identificação de celula.");
            }
        }

        private void listareuniao_Click(object sender, EventArgs e)
        {
            FrmReuniao form = new FrmReuniao();
            form.MdiParent = this.MdiParent;
            form.Text = "lista de reuniões";
            form.Show();
        }

        private void listaministerios_Click(object sender, EventArgs e)
        {
            FrmMinisterio form = new FrmMinisterio();
            form.MdiParent = this.MdiParent;
            form.Text = "lista de ministérios";
            form.Show();
        }

        private void listacelulas_Click(object sender, EventArgs e)
        {
            FrmCelula form = new FrmCelula();
            form.MdiParent = this.MdiParent;
            form.Text = "Lista de Celulas";
            form.Show();
        }
    }
}
