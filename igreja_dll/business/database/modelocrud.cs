using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace database
{
    public abstract class  modelocrud : IPesquisar
    {
        //construtor para Entity Framework
        public modelocrud()
        {
            this.bd = new BDcomum();
            Erro_Conexao = false;
        }


        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;

        [NotMapped]
        public static bool Erro_Conexao;
        [NotMapped]
        public static string textoPorcentagem = "0%";


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
        public abstract bool recuperar(int? id);

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
            else if(!ex.Message.Contains("transporte") && !ex.Message.Contains("servidor não está respondendo")
                && !ex.Message.Contains("índice estava fora do intervalo")
                && !ex.Message.Contains("não foi inicializada")
                && !ex.Message.Contains("conexão é fechada"))
                MessageBox.Show(ex.Message);

            else if(ex.Message.Contains("transporte") || ex.Message.Contains("servidor não está respondendo")
                || ex.Message.Contains("índice estava fora do intervalo")
                || ex.Message.Contains("não foi inicializada")
                || ex.Message.Contains("conexão é fechada"))
            {
                Erro_Conexao = true;
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


        public static int GeTotalRegistrosPessoas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Pessoa", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }


            return _TotalRegistros;
        }

        public static int GeTotalRegistrosCelulas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Celula", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosMinisterios()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Ministerio", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosReunioes()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Reuniao", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static int GeTotalRegistrosMudancaEstado()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM MudancaEstado", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

        public static void calcularPorcentagem()
        {
            try
            {
                var pessoas = GeTotalRegistrosPessoas();
                var celulas = GeTotalRegistrosCelulas();
                var ministerios = GeTotalRegistrosMinisterios();
                var reunioes = GeTotalRegistrosReunioes();
                var mudancas = GeTotalRegistrosMudancaEstado();
                var totalRegistros = pessoas + celulas + ministerios + reunioes + mudancas;

                var quantVisitante                 = 0;  var quamtCelula_Jovem       = 0;  var quantLider_Celula                      = 0;
                var quantCrianca                   = 0;  var quamtCelula_Adolescente = 0;  var quantLider_Celula_Treinamento          = 0;
                var quantMembro_Batismo            = 0;  var quamtCelula_Casado      = 0;  var quantLider_Ministerio                  = 0;
                var quantMembro_Aclamacao          = 0;  var quamtCelula_Crianca     = 0;  var quantLider_Ministerio_Treinamento      = 0;
                var quantMembro_Reconciliacao      = 0;  var quamtCelula_Adulto      = 0;  var quantSupervisor_Celula                 = 0;
                var quantMembro_Transferencia      = 0;                                    var quantSupervisor_Celula_Treinamento     = 0;
                var quantVisitanteLgpd             = 0;                                    var quantSupervisor_Ministerio             = 0;
                var quantCriancaLgpd               = 0;                                    var quantSupervisor_Ministerio_Treinamento = 0;
                var quantMembro_TransferenciaLgpd  = 0;  
                var quantMembro_BatismoLgpd       = 0;   
                var quantMembro_AclamacaoLgpd     = 0;   
                var quantMembro_ReconciliacaoLgpd = 0;

                var quantMudancas = 0;
                var quantReunioes = 0;

                if (Pessoa.visitantes                != null)  quantVisitante                 += Pessoa.visitantes                .Count;
                if(Pessoa.criancas                  != null)  quantCrianca                   += Pessoa.criancas                  .Count;
                if(Pessoa.membros_Aclamacao         != null) quantMembro_Aclamacao           += Pessoa.membros_Aclamacao         .Count;
                if(Pessoa.membros_Batismo           != null) quantMembro_Batismo             += Pessoa.membros_Batismo           .Count;
                if(Pessoa.membros_Reconciliacao     != null)  quantMembro_Reconciliacao      += Pessoa.membros_Reconciliacao     .Count;
                if(Pessoa.membros_Transferencia     != null)  quantMembro_Transferencia      += Pessoa.membros_Transferencia     .Count;
                if(Pessoa.visitantesLgpd            != null)  quantVisitanteLgpd             += Pessoa.visitantesLgpd            .Count;
                if(Pessoa.criancasLgpd              != null)  quantCriancaLgpd               += Pessoa.criancasLgpd              .Count;
                if(Pessoa.membros_AclamacaoLgpd     != null)  quantMembro_AclamacaoLgpd      += Pessoa.membros_AclamacaoLgpd     .Count;
                if(Pessoa.membros_BatismoLgpd       != null)  quantMembro_BatismoLgpd        += Pessoa.membros_BatismoLgpd       .Count;
                if(Pessoa.membros_ReconciliacaoLgpd != null)  quantMembro_ReconciliacaoLgpd  += Pessoa.membros_ReconciliacaoLgpd .Count;
                if (Pessoa.membros_TransferenciaLgpd != null) quantMembro_TransferenciaLgpd  += Pessoa.membros_TransferenciaLgpd.Count;

                if(Celula.celulasAdolescente != null) quamtCelula_Adolescente       +=  Celula.celulasAdolescente .Count;
                if(Celula.celulasAdulto      != null) quamtCelula_Adulto            +=  Celula.celulasAdulto      .Count;
                if(Celula.celulasCasado      != null) quamtCelula_Casado            +=  Celula.celulasCasado      .Count;
                if(Celula.celulasJovem       != null) quamtCelula_Jovem             +=  Celula.celulasJovem       .Count;
                if (Celula.celulasCrianca    != null) quamtCelula_Crianca           +=  Celula.celulasCrianca     .Count;

                if(Ministerio.lideresCelula                     != null) quantLider_Celula                      += Ministerio.lideresCelula                    .Count;
                if(Ministerio.LideresCelulaTreinamento          != null) quantLider_Celula_Treinamento          += Ministerio.LideresCelulaTreinamento         .Count;
                if(Ministerio.lideresMinisterio                 != null) quantLider_Ministerio                  += Ministerio.lideresMinisterio                .Count;
                if(Ministerio.lideresMinisterioTreinamento      != null) quantLider_Ministerio_Treinamento      += Ministerio.lideresMinisterioTreinamento     .Count;
                if(Ministerio.supervisoresCelula                != null) quantSupervisor_Celula                 += Ministerio.supervisoresCelula               .Count;
                if(Ministerio.supervisoresCelulaTreinamento     != null) quantSupervisor_Celula_Treinamento     += Ministerio.supervisoresCelulaTreinamento    .Count;
                if(Ministerio.supervisoresMinisterio            != null) quantSupervisor_Ministerio             += Ministerio.supervisoresMinisterio           .Count;
                if(Ministerio.supervisoresMinisterioTreinamento != null) quantSupervisor_Ministerio_Treinamento += Ministerio.supervisoresMinisterioTreinamento.Count;

                if(Reuniao.Reunioes != null) quantReunioes += Reuniao.Reunioes.Count;
                if(MudancaEstado.Mudancas != null) quantMudancas += MudancaEstado.Mudancas.Count;
                
                var quantidadeCarregada = quantMudancas + quantReunioes +
                quantVisitante                 + quantLider_Celula                      + quamtCelula_Jovem       +
                quantCrianca                   + quantLider_Celula_Treinamento          + quamtCelula_Adolescente +
                quantMembro_Batismo            + quantLider_Ministerio                  + quamtCelula_Casado      +
                quantMembro_Aclamacao          + quantLider_Ministerio_Treinamento      + quamtCelula_Crianca     +
                quantMembro_Reconciliacao      + quantSupervisor_Celula                 + quamtCelula_Adulto      +
                quantMembro_Transferencia      + quantSupervisor_Celula_Treinamento     +
                quantVisitanteLgpd             + quantSupervisor_Ministerio             +
                quantCriancaLgpd               + quantSupervisor_Ministerio_Treinamento +
                quantMembro_TransferenciaLgpd  +
                quantMembro_BatismoLgpd        +
                quantMembro_AclamacaoLgpd      +
                quantMembro_ReconciliacaoLgpd ; 


                var porcentagem = (int)((100 * quantidadeCarregada) / totalRegistros);

                textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch { }
        }
    }
}
