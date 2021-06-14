using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;

namespace business.classes
{
    [Table("MudancaEstado")]
    public class MudancaEstado : modelocrud, IMudancaEstado
    {
        [Key]
        public int IdMudanca { get; set; }
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime DataMudanca { get; set; }
        public int CodigoPessoa { get; set; }

        [NotMapped]
        public static List<MudancaEstado> Mudancas { get; set; }

        public MudancaEstado() : base()
        {
            this.DataMudanca = DateTime.Now;
        }

        public void MudarEstado(int idVelhoEstado, modelocrud m)
        {
            string estado = "";
            var model1  = new Visitante()               ; var p1 =  model1  .recuperar(idVelhoEstado);
            var model2  = new VisitanteLgpd()           ; var p2 =  model2  .recuperar(idVelhoEstado);
            var model3  = new Crianca()                 ; var p3 =  model3  .recuperar(idVelhoEstado);
            var model4  = new CriancaLgpd()             ; var p4 =  model4  .recuperar(idVelhoEstado);
            var model5  = new Membro_Aclamacao()        ; var p5 =  model5  .recuperar(idVelhoEstado);
            var model6  = new Membro_AclamacaoLgpd()    ; var p6 =  model6  .recuperar(idVelhoEstado);
            var model7  = new Membro_Batismo()          ; var p7 =  model7  .recuperar(idVelhoEstado);
            var model8  = new Membro_BatismoLgpd()      ; var p8 =  model8  .recuperar(idVelhoEstado);
            var model9  = new Membro_Reconciliacao()    ; var p9 =  model9  .recuperar(idVelhoEstado);
            var model10 = new Membro_ReconciliacaoLgpd(); var p10 = model10 .recuperar(idVelhoEstado);
            var model11 = new Membro_Transferencia()    ; var p11 = model11 .recuperar(idVelhoEstado);
            var model12 = new Membro_TransferenciaLgpd(); var p12 = model12.recuperar(idVelhoEstado);
            Pessoa p = null;
            if (p1) p =  model1;
            if (p2) p =  model2 ;
            if (p3) p =  model3 ;
            if (p4) p =  model4 ;
            if (p5) p =  model5 ;
            if (p6) p =  model6 ;
            if (p7) p =  model7 ;
            if (p8) p =  model8 ;
            if (p9) p =  model9 ;
            if (p10) p = model10;
            if (p11) p = model11;
            if (p12) p = model12;
            estado = p.GetType().Name;

            p.excluir(idVelhoEstado);

            var addMinisterios = "";
            var minis = p.Ministerios;
            if (minis != null)
                foreach (var itemMinisterio in minis)
                    addMinisterios += itemMinisterio.Ministerio.IdMinisterio.ToString() + ", ";
            if (minis != null)
                if (minis.Count != 0)
                    p.AdicionarNaLista("PessoaMinsterio", p, minis[0], addMinisterios);

            var addReunioes = "";
            var reu = p.Reuniao;
            if (reu != null)
                foreach (var itemReuniao in reu)
                    addReunioes += itemReuniao.Reuniao.IdReuniao.ToString() + ", ";
            if (reu != null)
                if (reu.Count != 0)
                    p.AdicionarNaLista("ReuniaoPessoa", p, reu[0], addReunioes);

            if (m is PessoaDado)
            {
                if (m is Membro_Aclamacao)
                {
                    var modelo = (Membro_Aclamacao)m;
                    var pd = modelo;
                    Membro_Aclamacao membro = new Membro_Aclamacao
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Denominacao = modelo.Denominacao,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_Batismo)
                {
                    var modelo = (Membro_Batismo)m;
                    var pd = modelo;
                    Membro_Batismo membro = new Membro_Batismo
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_Reconciliacao)
                {
                    var modelo = (Membro_Reconciliacao)m;
                    var pd = modelo;
                    Membro_Reconciliacao membro = new Membro_Reconciliacao
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Data_reconciliacao = modelo.Data_reconciliacao,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_Transferencia)
                {
                    var modelo = (Membro_Transferencia)m;
                    var pd = modelo;
                    Membro_Transferencia membro = new Membro_Transferencia
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Estado_transferencia = modelo.Estado_transferencia,
                        Nome_cidade_transferencia = modelo.Nome_cidade_transferencia,
                        Nome_igreja_transferencia = modelo.Nome_igreja_transferencia,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Crianca)
                {
                    var modelo = (Crianca)m;
                    var pd = modelo;
                    Crianca c = new Crianca
                    {
                        Nome_mae = modelo.Nome_mae,
                        Nome_pai = modelo.Nome_pai,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    c.salvar();
                }

                if (m is Visitante)
                {
                    var modelo = (Visitante)m;
                    var pd = modelo;
                    Visitante v = new Visitante
                    {
                        Condicao_religiosa = modelo.Condicao_religiosa,
                        Data_visita = modelo.Data_visita,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Cpf = pd.Cpf,
                        Data_nascimento = pd.Data_nascimento,
                        Email = pd.Email,
                        Endereco = pd.Endereco,
                        Estado_civil = pd.Estado_civil,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Falescimento = pd.Falescimento,
                        NomePessoa = pd.NomePessoa,
                        Reuniao = pd.Reuniao,
                        Rg = pd.Rg,
                        Ministerios = pd.Ministerios,
                        Sexo_feminino = pd.Sexo_feminino,
                        Sexo_masculino = pd.Sexo_masculino,
                        Telefone = pd.Telefone,
                        Status = pd.Status,
                        Codigo = p.Codigo
                    };
                    v.salvar();
                }
            }

            if (m is PessoaLgpd)
            {
                if (m is Membro_AclamacaoLgpd)
                {
                    var modelo = (Membro_AclamacaoLgpd)m;
                    var pd = p;
                    Membro_AclamacaoLgpd membro = new Membro_AclamacaoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Denominacao = modelo.Denominacao,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_BatismoLgpd)
                {
                    var modelo = (Membro_BatismoLgpd)m;
                    var pd = p;
                    Membro_BatismoLgpd membro = new Membro_BatismoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_ReconciliacaoLgpd)
                {
                    var modelo = (Membro_ReconciliacaoLgpd)m;
                    var pd = p;
                    Membro_ReconciliacaoLgpd membro = new Membro_ReconciliacaoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Data_reconciliacao = modelo.Data_reconciliacao,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_TransferenciaLgpd)
                {
                    var modelo = (Membro_TransferenciaLgpd)m;
                    var pd = p;
                    Membro_TransferenciaLgpd membro = new Membro_TransferenciaLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Estado_transferencia = modelo.Estado_transferencia,
                        Nome_cidade_transferencia = modelo.Nome_cidade_transferencia,
                        Nome_igreja_transferencia = modelo.Nome_igreja_transferencia,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    membro.salvar();
                }

                if (m is CriancaLgpd)
                {
                    var modelo = (CriancaLgpd)m;
                    var pd = p;
                    CriancaLgpd c = new CriancaLgpd
                    {
                        Nome_mae = modelo.Nome_mae,
                        Nome_pai = modelo.Nome_pai,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    c.salvar();
                }

                if (m is VisitanteLgpd)
                {
                    var modelo = (VisitanteLgpd)m;
                    var pd = p;
                    VisitanteLgpd v = new VisitanteLgpd
                    {
                        Condicao_religiosa = modelo.Condicao_religiosa,
                        Data_visita = modelo.Data_visita,
                        celula_ = p.celula_,
                        Chamada = p.Chamada,
                        Email = p.Email,
                        Falta = p.Falta,
                        Historico = p.Historico,
                        Img = p.Img,
                        Reuniao = p.Reuniao,
                        Ministerios = p.Ministerios,
                        Codigo = p.Codigo
                    };
                    v.salvar();
                }
            }

            new MudancaEstado
            {
                novoEstado = m.GetType().Name,
                velhoEstado = estado,
                DataMudanca = DateTime.Now,
                CodigoPessoa = p.Codigo
            }.salvar();
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update MudancaEstado set velhoEstado='{velhoEstado}', " +
           $" novoEstado='{novoEstado}', DataMudanca='{DataMudanca}', CodigoPessoa='{CodigoPessoa}' " +
           $"  where IdMudanca='{id}' ";

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from MudancaEstado as M where M.IdMudanca='{id}'";

            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from MudancaEstado ";
            if (id != null) Select_padrao += $" as P where  P.IdMudanca='{id}'";

            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {

                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return false;
                        }

                        dr.Read();

                        this.velhoEstado = Convert.ToString(dr["velhoEstado"]);
                        this.CodigoPessoa = int.Parse(Convert.ToString(dr["CodigoPessoa"]));
                        this.IdMudanca = int.Parse(Convert.ToString(dr["IdMudanca"]));
                        this.novoEstado = Convert.ToString(dr["novoEstado"]);
                        this.DataMudanca = Convert.ToDateTime(dr["DataMudanca"]);
                        dr.Close();
                    }

                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                        return false;
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }
                    
                    return true;
                }
                else
                {
                    try
                    {

                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return false;
                        }

                        List<modelocrud> modelos = new List<modelocrud>();
                        while (dr.Read())
                        {
                            MudancaEstado m = new MudancaEstado();
                            m.IdMudanca = int.Parse(Convert.ToString(dr["IdMudanca"]));
                            modelos.Add(m);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        Mudancas = new List<MudancaEstado>();
                        foreach (var m in modelos)
                        {
                            var cel = (MudancaEstado)m;
                            var c = new MudancaEstado();
                            if(c.recuperar(cel.IdMudanca))
                            Mudancas.Add(c); //não deu erro de conexao
                            else
                            {
                                Mudancas = null;
                                break;
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                        return false;
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }

                    return true;
                } 
            }
            if (id == null)
                Mudancas = null;

                return false;
        }

        public override string salvar()
        {
            Insert_padrao = "insert into MudancaEstado (velhoEstado, novoEstado, DataMudanca, CodigoPessoa) " +
                $" values ('{velhoEstado}', '{novoEstado}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{CodigoPessoa}')";

            bd.SalvarModelo(this);
            return Insert_padrao;
        }

        public override string ToString()
        {
            return "ID da mudança: " + IdMudanca.ToString() + " ID da pessoa: " + this.CodigoPessoa;
        }
    }
}
