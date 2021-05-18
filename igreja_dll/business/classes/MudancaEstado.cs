using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public MudancaEstado() :base()
        {
            this.DataMudanca = DateTime.Now;
        }

        public void MudarEstado(int idVelhoEstado, modelocrud m)
        {
            string estado = "";
            var lista = Pessoa.recuperarTodos();
            List<Pessoa> lista2 = new List<Pessoa>();
            foreach (var item in lista)
            lista2.Add((Pessoa)item);
            Pessoa p = lista2.First(i => i.IdPessoa == idVelhoEstado);
            estado = p.GetType().Name;
            p = (Pessoa)p.recuperar(p.IdPessoa)[0];

            p.excluir(idVelhoEstado);

            var addMinisterios = "";
            var minis = p.Ministerios;
            if(minis != null)
            foreach(var itemMinisterio in minis)
            addMinisterios += itemMinisterio.Ministerio.IdMinisterio.ToString() + ", ";
            if (minis != null)
            if(minis.Count != 0)
            p.AdicionarNaLista("PessoaMinsterio", p, minis[0], addMinisterios);

            var addReunioes = "";
            var reu = p.Reuniao;
            if (reu != null)
            foreach (var itemReuniao in reu)
            addReunioes += itemReuniao.Reuniao.IdReuniao.ToString() + ", ";
            if (reu != null)
            if(reu.Count != 0)
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
                        Codigo = pd.Codigo
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
                        Codigo = pd.Codigo
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
                        Codigo = pd.Codigo
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
                        Codigo = pd.Codigo
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
                        Codigo = pd.Codigo
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
                        Codigo = pd.Codigo
                    };
                    v.salvar();
                } 
            }

            if (m is PessoaLgpd)
            {
                if (m is Membro_AclamacaoLgpd)
                {
                    var modelo = (Membro_AclamacaoLgpd)m;
                    var pd = (PessoaLgpd)p;
                    Membro_AclamacaoLgpd membro = new Membro_AclamacaoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Denominacao = modelo.Denominacao,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_BatismoLgpd)
                {
                    var modelo = (Membro_BatismoLgpd)m;
                    var pd = (PessoaLgpd)p;
                    Membro_BatismoLgpd membro = new Membro_BatismoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_ReconciliacaoLgpd)
                {
                    var modelo = (Membro_ReconciliacaoLgpd)m;
                    var pd = (PessoaLgpd)p;
                    Membro_ReconciliacaoLgpd membro = new Membro_ReconciliacaoLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Data_reconciliacao = modelo.Data_reconciliacao,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
                    };
                    membro.salvar();
                }

                if (m is Membro_TransferenciaLgpd)
                {
                    var modelo = (Membro_TransferenciaLgpd)m;
                    var pd = (PessoaLgpd)p;
                    Membro_TransferenciaLgpd membro = new Membro_TransferenciaLgpd
                    {
                        Data_batismo = modelo.Data_batismo,
                        Desligamento = modelo.Desligamento,
                        Motivo_desligamento = modelo.Motivo_desligamento,
                        Estado_transferencia = modelo.Estado_transferencia,
                        Nome_cidade_transferencia = modelo.Nome_cidade_transferencia,
                        Nome_igreja_transferencia = modelo.Nome_igreja_transferencia,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
                    };
                    membro.salvar();
                }

                if (m is CriancaLgpd)
                {
                    var modelo = (CriancaLgpd)m;
                    var pd = (PessoaLgpd)p;
                    CriancaLgpd c = new CriancaLgpd
                    {
                        Nome_mae = modelo.Nome_mae,
                        Nome_pai = modelo.Nome_pai,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
                    };
                    c.salvar();
                }

                if (m is VisitanteLgpd)
                {
                    var modelo = (VisitanteLgpd)m;
                    var pd = (PessoaLgpd)p;
                    VisitanteLgpd v = new VisitanteLgpd
                    {
                        Condicao_religiosa = modelo.Condicao_religiosa,
                        Data_visita = modelo.Data_visita,
                        celula_ = pd.celula_,
                        Chamada = pd.Chamada,
                        Email = pd.Email,
                        Falta = pd.Falta,
                        Historico = pd.Historico,
                        Img = pd.Img,
                        Reuniao = pd.Reuniao,
                        Ministerios = pd.Ministerios,
                        Codigo = pd.Codigo
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

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from MudancaEstado ";
            if(id != null) Select_padrao += $" as P where  P.IdMudanca='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
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
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    bd.obterconexao().Close();
                }

                modelos.Add(this);
                return modelos;
            }
            else
            {
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        MudancaEstado m = new MudancaEstado();
                        m.IdMudanca = int.Parse(Convert.ToString(dr["IdMudanca"]));
                        modelos.Add(m);
                    }

                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (MudancaEstado)m;
                        var c = new MudancaEstado();
                        c = (MudancaEstado)m.recuperar(cel.IdMudanca)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    bd.obterconexao().Close();
                }

                return modelos;
            }

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
