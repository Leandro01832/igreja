using business.classes.Abstrato;
using database;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.FormularioMinisterio;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class MinisteriosCelula : FormularioCrudCelula
    {
        public MinisteriosCelula() : base()
        {
            InitializeComponent();
            txt_ministerio.Leave += Txt_ministerio_Leave;
        }

        private void Txt_ministerio_Leave(object sender, EventArgs e)
        {
            var arr = txt_ministerio.Text.Replace(" ", "").Split(',');
            try
            {
                int teste = int.Parse(arr[arr.Length - 1]);
                AddNaListaCelulaMinisterios = txt_ministerio.Text;
            }
            catch
            {
                txt_ministerio.Text = "";
                AddNaListaCelulaMinisterios = "";
            }
        }

        private void MinisteriosCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Ministérios da celula";

            var c = (Celula)modelo;
            if (c.Id == 0)
            {
                txt_ministerio.Text = AddNaListaCelulaMinisterios;
            }
            else
            {
                var lista = modelocrud.Modelos.OfType<Pessoa>().Where(p => p.celula_ == c.Id).ToList();
                if (lista != null) lbl_pessoas.Text = "Pessoas: ";
                foreach (var numero in lista)
                {
                    lbl_pessoas.Text += numero.ToString() + ", ";
                }

                var minis = c.Ministerios;
                foreach (var item in minis)
                {
                    var m = modelocrud.Modelos.OfType<Ministerio>().ToList().First(i => i.Id == item.MinisterioId);
                    txt_ministerio.Text += m.Id.ToString() + ", ";
                }
            }

        }

        private void txt_ministerio_TextChanged(object sender, EventArgs e)
        {
            AddNaListaCelulaMinisterios = "";
            var arr = txt_ministerio.Text.Replace(" ", "").Split(',');

            try { int teste = int.Parse(arr[0]); }
            catch
            {
                AddNaListaCelulaMinisterios = "";
                txt_ministerio.Text = "";
                txt_ministerio.Focus();
                MessageBox.Show("Informe numeros de identificação de ministérios.");
            }

            if (arr[arr.Length - 1] == "")
                foreach (var item in arr)
                {
                    try
                    {
                        if (item != "")
                        {
                            int numero = int.Parse(item);
                            try
                            {
                                var modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().FirstOrDefault(i => i.Id == numero);
                                AddNaListaCelulaMinisterios += modelo.Id.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaCelulaMinisterios = "";
                                var num = Ministerio.TotalRegistro();
                                if (num != modelocrud.Modelos.OfType<Ministerio>().ToList().Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                            }
                        }
                    }
                    catch
                    {
                        if (item != "")
                        {
                            AddNaListaCelulaMinisterios = "";
                            txt_ministerio.Text = "";
                            txt_ministerio.Focus();
                            MessageBox.Show("Informe numeros de identificação de ministérios.");
                        }
                    }
                }
        }

        private void ListaMinisterios_Click(object sender, EventArgs e)
        {
            ListMinisterio form = new ListMinisterio(typeof(Ministerio));
            form.MdiParent = this.MdiParent;
            form.Text = "lista de ministérios";
            form.Show();
        }
    }
}
