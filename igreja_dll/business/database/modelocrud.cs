using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using database.banco;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
     public abstract class  modelocrud : IPesquisar
    {
        //construtor para Entity Framework
        public modelocrud()
        {
            this.bd = new BDcomum();
        }


        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;
        
        [NotMapped]
        public string Insert_padrao { get => insert_padrao; set => insert_padrao = value; }
        [NotMapped]
        public string Update_padrao { get => update_padrao; set => update_padrao = value; }
        [NotMapped]
        public string Delete_padrao { get => delete_padrao; set => delete_padrao = value; }
        [NotMapped]
        public string Select_padrao { get => select_padrao; set => select_padrao = value; }

        public BDcomum bd;

        public abstract string salvar();
        public abstract string alterar( int id);
        public abstract string excluir(int id);
        public abstract List<modelocrud> recuperar(int? id);

        public bool retornoDados(SqlDataReader dr, string pesquisa)
        {
            try
            {
                int valor = int.Parse(Convert.ToString(dr[pesquisa]));
                return true;
            }
            catch (Exception)
            {
              return  false;
            }
        }

        public void TratarExcessao(Exception ex)
        {
            if (ex.Message.Contains("instância"))
            {
                BDcomum.podeAbrir = false;
            }
            else if (ex.Message.Contains("reader"))
            {

                MessageBox.Show("A leitura dos dados não esta sendo realizada. Verifique sua conexão!!! " + this.GetType().Name);
            }
            else if(!ex.Message.Contains("transporte") && !ex.Message.Contains("servidor não esta respondendo")
                && !ex.Message.Contains("índice estava fora do intervalo"))
                MessageBox.Show(ex.Message);

            else if(ex.Message.Contains("transporte") && ex.Message.Contains("servidor não esta respondendo"))
            {
              //  if (this.GetType().Name == "Visitante"           ) Pessoa.visitantes                = null;
              //  if (this.GetType().Name == "Crianca"             ) Pessoa.criancas                  = null;
              //  if (this.GetType().Name == "Membro_Aclamacao"    ) Pessoa.membros_Aclamacao         = null;
              //  if (this.GetType().Name == "Membro_Batismo"      ) Pessoa.membros_Batismo           = null;
              //  if (this.GetType().Name == "Membro_Reconciliacao") Pessoa.membros_Reconciliacao     = null;
              //  if (this.GetType().Name == "Membro_Transferencia") Pessoa.membros_Transferencia     = null;
              //
              //  if (this.GetType().Name == "VisitanteLgpd"           ) Pessoa.visitantesLgpd            = null;
              //  if (this.GetType().Name == "CriancaLgpd"             ) Pessoa.criancasLgpd              = null;
              //  if (this.GetType().Name == "Membro_AclamacaoLgpd"    ) Pessoa.membros_AclamacaoLgpd     = null;
              //  if (this.GetType().Name == "Membro_BatismoLgpd"      ) Pessoa.membros_BatismoLgpd       = null;
              //  if (this.GetType().Name == "Membro_ReconciliacaoLgpd") Pessoa.membros_ReconciliacaoLgpd = null;
              //  if (this.GetType().Name == "Membro_TransferenciaLgpd") Pessoa.membros_TransferenciaLgpd = null;
              //
              //  if (this.GetType().Name == "Lider_Celula") Ministerio.lideresCelula = null;
              //  if (this.GetType().Name == "Lider_Celula_Treinamento") Ministerio.LideresCelulaTreinamento = null;
              //  if (this.GetType().Name == "Lider_Ministerio") Ministerio.lideresMinisterio = null;
              //  if (this.GetType().Name == "Lider_Ministerio_Treinamento") Ministerio.lideresMinisterioTreinamento = null;
              //  if (this.GetType().Name == "Supervisor_Celula") Ministerio.supervisoresCelula = null;
              //  if (this.GetType().Name == "Supervisor_Celula_Treinamento") Ministerio.supervisoresCelulaTreinamento = null;
              //  if (this.GetType().Name == "Supervisor_Ministerio") Ministerio.supervisoresMinisterio = null;
              //  if (this.GetType().Name == "Supervisor_Ministerio_Treinamento") Ministerio.supervisoresMinisterioTreinamento = null;
              //
              //  if (this.GetType().Name == "Celula_Adolescente") Celula.celulasAdolescente = null;
              //  if (this.GetType().Name == "Celula_Adulto") Celula.celulasAdulto = null;
              //  if (this.GetType().Name == "Celula_Casado") Celula.celulasCasado = null;
              //  if (this.GetType().Name == "Celula_Crianca") Celula.celulasCrianca = null;
              //  if (this.GetType().Name == "Celula_Jovem") Celula.celulasJovem = null;
            }
        }

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos,DateTime comecar, DateTime terminar, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Data_reuniao")
                q = modelos.OfType<Reuniao>().Where(i => i.Data_reuniao >= comecar && i.Data_reuniao <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<PessoaDado>().ToList().Count > 0 && campo == "Data_nascimento")
                q = modelos.OfType<PessoaDado>().Where(i => i.Data_nascimento >= comecar && i.Data_nascimento <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<MudancaEstado>().ToList().Count > 0 && campo == "DataMudanca")
                q = modelos.OfType<MudancaEstado>().Where(i => i.DataMudanca >= comecar && i.DataMudanca <= terminar).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorData(List<modelocrud> modelos,DateTime apenasUmDia, string campo)
        {
            List<modelocrud> q = null;
            return q;
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos,int comecar, int terminar, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "IdReuniao")
                q = modelos.OfType<Reuniao>().Where(i => i.IdReuniao >= comecar && i.IdReuniao <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "IdPessoa")
                q = modelos.OfType<Pessoa>().Where(i => i.IdPessoa >= comecar && i.IdPessoa <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "IdCelula")
                q = modelos.OfType<Celula>().Where(i => i.IdCelula >= comecar && i.IdCelula <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "IdMinisterio")
                q = modelos.OfType<Ministerio>().Where(i => i.IdMinisterio >= comecar && i.IdMinisterio <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Membro>().ToList().Count > 0 && campo == "Data_batismo")
                q = modelos.OfType<Membro>().Where(i => i.Data_batismo >= comecar && i.Data_batismo <= terminar).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorNumero(List<modelocrud> modelos,int apenasUmNumero, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "IdReuniao")
                q = modelos.OfType<Reuniao>().Where(i => i.IdReuniao >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "IdPessoa")
                q = modelos.OfType<Pessoa>().Where(i => i.IdPessoa >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "IdCelula")
                q = modelos.OfType<Celula>().Where(i => i.IdCelula >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "IdMinisterio")
                q = modelos.OfType<Ministerio>().Where(i => i.IdMinisterio >= apenasUmNumero).Cast<modelocrud>().ToList();

            if (modelos.OfType<Membro>().ToList().Count > 0 && campo == "Data_batismo")
                q = modelos.OfType<Membro>().Where(i => i.Data_batismo >= apenasUmNumero).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorTexto(List<modelocrud> modelos, string texto, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Crianca>().ToList().Count > 0 && campo == "Nome_pai")
                q = modelos.OfType<Crianca>().Where(p => p.Nome_pai.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Crianca>().ToList().Count > 0 && campo == "Nome_mae")
                q = modelos.OfType<Crianca>().Where(p => p.Nome_mae.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "Email")
                q = modelos.OfType<Pessoa>().Where(p => p.Email.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Pessoa>().ToList().Count > 0 && campo == "NomePessoa")
                q = modelos.OfType<Pessoa>().Where(p => p.NomePessoa.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Nome")
                q = modelos.OfType<Celula>().Where(p => p.Nome.Contains(texto)).Cast<modelocrud>().ToList();

            if (modelos.OfType<Ministerio>().ToList().Count > 0 && campo == "Nome")
                q = modelos.OfType<Ministerio>().Where(p => p.Nome.Contains(texto)).Cast<modelocrud>().ToList();
            return q;
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_fim")
            q = modelos.OfType<Reuniao>().Where(i => i.Horario_fim >= comecar && i.Horario_fim <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_inicio")
            q = modelos.OfType<Reuniao>().Where(i => i.Horario_inicio >= comecar && i.Horario_inicio <= terminar).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Horario")
            q = modelos.OfType<Celula>().Where(i => i.Horario >= comecar && i.Horario <= terminar).Cast<modelocrud>().ToList();

            return q;         
        }

        public List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan apenasUmHorario, string campo)
        {
            List<modelocrud> q = null;
            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_fim")
            q = modelos.OfType<Reuniao>().Where(i => i.Horario_fim == apenasUmHorario).Cast<modelocrud>().ToList();

            if (modelos.OfType<Reuniao>().ToList().Count > 0 && campo == "Horario_inicio")
                q = modelos.OfType<Reuniao>().Where(i => i.Horario_inicio == apenasUmHorario).Cast<modelocrud>().ToList();

            if (modelos.OfType<Celula>().ToList().Count > 0 && campo == "Horario_inicio")
                q = modelos.OfType<Celula>().Where(i => i.Horario == apenasUmHorario).Cast<modelocrud>().ToList();
            return q;
        }
    }
}
