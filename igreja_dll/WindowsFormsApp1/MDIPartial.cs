using database;
using System;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;

namespace WindowsFormsApp1
{
    public partial class MDI 
    {

        ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);

        private void OpenListPessoa(Type tipo)
        {
            FormularioListView frm = new ListPessoa(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }
        private void OpenListMinisterio(Type tipo)
        {
            FormularioListView frm = new ListMinisterio(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }
        private void OpenListCelula(Type tipo)
        {
            FormularioListView frm = new ListCelula(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void OpenQuery(Type tipo)
        {
            Pesquisar query = new Pesquisar(tipo);
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void LoadFormCreate(modelocrud modelo)
        {
            crudForm.LoadFormCrud(modelo, false, false, false, this);
        }

        private void Membro_AclamacaoLgpdCadastrar_Click(object sender, EventArgs e)     { Clicar(this); }
        private void Membro_BatismoLgpdCadastrar_Click(object sender, EventArgs e)       { Clicar(this); }
        private void Membro_ReconciliacaoLgpdCadastrar_Click(object sender, EventArgs e) { Clicar(this); }
        private void Membro_TransferenciaLgpdCadastrar_Click(object sender, EventArgs e) { Clicar(this); }
        private void VisitanteLgpdCadastrar_Click(object sender, EventArgs e)            { Clicar(this); }
        private void CriancaLgpdCadastrar_Click(object sender, EventArgs e)              { Clicar(this); }
        private void VisitanteCadastrar_Click(object sender, EventArgs e)                { Clicar(this); }
        private void CriancaCadastrar_Click(object sender, EventArgs e)                  { Clicar(this); }
        private void Membro_AclamacaoCadastrar_Click(object sender, EventArgs e)         { Clicar(this); }
        private void Membro_BatismoCadastrar_Click(object sender, EventArgs e)           { Clicar(this); }
        private void Membro_ReconciliacaoCadastrar_Click(object sender, EventArgs e)     { Clicar(this); }
        private void Membro_TransferenciaCadastrar_Click(object sender, EventArgs e)     { Clicar(this); }
        private void PessoaLgpdImprimir_Click(object sender, EventArgs e)                { Clicar(this); }
        private void PessoaDadoImprimir_Click(object sender, EventArgs e)                { Clicar(this); }
        private void CriancaLgpdImprimir_Click(object sender, EventArgs e)               { Clicar(this); }
        private void VisitanteLgpdImprimir_Click(object sender, EventArgs e)             { Clicar(this); }
        private void MembroLgpdImprimir_Click(object sender, EventArgs e)                { Clicar(this); }
        private void Membro_AclamacaoLgpdImprimir_Click(object sender, EventArgs e)      { Clicar(this); }
        private void Menbro_BatismoLgpdImprimir_Click(object sender, EventArgs e)        { Clicar(this); }
        private void Membro_TransferenciaLgpdImprimir_Click(object sender, EventArgs e)  { Clicar(this); }
        private void Membro_ReconciliacaoLgpdImprimir_Click(object sender, EventArgs e)  { Clicar(this); }
        private void CriancaImprimir_Click(object sender, EventArgs e)                   { Clicar(this); }
        private void VisitanteImprimir_Click(object sender, EventArgs e)                 { Clicar(this); }
        private void MembroImprimir_Click(object sender, EventArgs e)                    { Clicar(this); }
        private void Membro_AclamacaoImprimir_Click(object sender, EventArgs e)          { Clicar(this); }
        private void Membro_BatismoImprimir_Click(object sender, EventArgs e)            { Clicar(this); }
        private void Membro_TransferenciaImprimir_Click(object sender, EventArgs e)      { Clicar(this); }
        private void Membro_ReconciliacaoImprimir_Click(object sender, EventArgs e)      { Clicar(this); }

    }
}
