using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class CadastroVisitante : WFCrud
    {

        public CadastroVisitante() : base()
        {
            InitializeComponent();
        }
        
        private void CadastroVisitante_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de visitante.";

            if (modelo is Visitante)
            {
                Visitante p = null;
                if (modelo != null)
                    p = (Visitante)modelo;
                else
                    p = (Visitante)ModeloNovo;
                
                mask_data_visita.Text = p.Data_visita.ToString("dd/MM/yyyy");
                try { txt_condicao_religiosa.Text = p.Condicao_religiosa; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }

            if (modelo is VisitanteLgpd)
            {
                VisitanteLgpd p = null;
                if (modelo != null)
                    p = (VisitanteLgpd)modelo;
                else
                    p = (VisitanteLgpd)ModeloNovo;

                p.Validar(mask_data_visita.Text, "Data_visita");
                try { txt_condicao_religiosa.Text = p.Condicao_religiosa; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }

        }

        private void mask_data_visita_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_data_visita.Text = "";
        }

        private void txt_condicao_religiosa_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Visitante)
                {
                    var p = (Visitante)modelo;
                    try { p.Condicao_religiosa = txt_condicao_religiosa.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)modelo;
                    try { p.Condicao_religiosa = txt_condicao_religiosa.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Visitante)
                {
                    var p = (Visitante)ModeloNovo;
                    try { p.Condicao_religiosa = txt_condicao_religiosa.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (ModeloNovo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)ModeloNovo;
                    try { p.Condicao_religiosa = txt_condicao_religiosa.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
            }
        }

        private void mask_data_visita_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Visitante)
                {
                    var p = (Visitante)modelo;
                    p.Validar(mask_data_visita.Text, "Data_visita");
                }

                if (modelo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)modelo;
                    p.Validar(mask_data_visita.Text, "Data_visita");
                }

            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Visitante)
                {
                    var p = (Visitante)ModeloNovo;
                    p.Validar(mask_data_visita.Text, "Data_visita");
                }

                if (ModeloNovo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)ModeloNovo;
                    p.Validar(mask_data_visita.Text, "Data_visita");
                }
            }

        }
    }
}
