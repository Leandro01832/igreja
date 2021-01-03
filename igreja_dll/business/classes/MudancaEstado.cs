using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using business.classes.Pessoas;
using database;
using database.banco;

namespace business.classes.Abstrato
{
    [Table("MudancaEstado")]
    public class MudancaEstado : modelocrud, IMudancaEstado
    {
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
            Pessoa p = (Pessoa) Pessoa.recuperarPessoa(idVelhoEstado);
            estado = p.GetType().Name;
            if (p is Visitante)
                p = (Pessoa) new Visitante(idVelhoEstado, true).recuperar(idVelhoEstado)[0];
            if (p is Crianca)
                p = (Pessoa)new Crianca(idVelhoEstado, true).recuperar(idVelhoEstado)[0];
            if (p is Membro_Batismo)
                p = (Pessoa)new Membro_Batismo(idVelhoEstado, true).recuperar(idVelhoEstado)[0];
            if (p is Membro_Reconciliacao)
                p = (Pessoa)new Membro_Reconciliacao(idVelhoEstado, true).recuperar(idVelhoEstado)[0];
            if (p is Membro_Transferencia)
                p = (Pessoa)new Membro_Transferencia(idVelhoEstado, true).recuperar(idVelhoEstado)[0];
            if (p is Membro_Aclamacao)
                p = (Pessoa)new Membro_Aclamacao(idVelhoEstado, true).recuperar(idVelhoEstado)[0];

            p.excluir(idVelhoEstado);
            

            if (m is Membro_Aclamacao)
            {
                var modelo = (Membro_Aclamacao)m;
                Membro_Aclamacao membro = new Membro_Aclamacao
                {
                    Data_batismo = modelo.Data_batismo,
                    Desligamento = modelo.Desligamento,
                    Motivo_desligamento = modelo.Motivo_desligamento,
                    Denominacao = modelo.Denominacao,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                membro.salvar();
            }

            if (m is Membro_Batismo)
            {
                var modelo = (Membro_Batismo)m;
                Membro_Batismo membro = new Membro_Batismo
                {
                    Data_batismo = modelo.Data_batismo,
                    Desligamento = modelo.Desligamento,
                    Motivo_desligamento = modelo.Motivo_desligamento,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                membro.salvar();
            }

            if (m is Membro_Reconciliacao)
            {
                var modelo = (Membro_Reconciliacao)m;
                Membro_Reconciliacao membro = new Membro_Reconciliacao
                {
                    Data_batismo = modelo.Data_batismo,
                    Desligamento = modelo.Desligamento,
                    Motivo_desligamento = modelo.Motivo_desligamento,
                    Data_reconciliacao = modelo.Data_reconciliacao,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                membro.salvar();
            }

            if (m is Membro_Transferencia)
            {
                var modelo = (Membro_Transferencia)m;
                Membro_Transferencia membro = new Membro_Transferencia
                {
                    Data_batismo = modelo.Data_batismo,
                    Desligamento = modelo.Desligamento,
                    Motivo_desligamento = modelo.Motivo_desligamento,
                    Estado_transferencia = modelo.Estado_transferencia,
                    Nome_cidade_transferencia = modelo.Nome_cidade_transferencia,
                    Nome_igreja_transferencia = modelo.Nome_igreja_transferencia,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                membro.salvar();
            }

            if (m is Crianca)
            {
                var modelo = (Crianca)m;
                Crianca c = new Crianca
                {
                    Nome_mae = modelo.Nome_mae,
                    Nome_pai = modelo.Nome_pai,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                c.salvar();
            }

            if (m is Visitante)
            {
                var modelo = (Visitante)m;
                Visitante v = new Visitante
                {
                    Condicao_religiosa = modelo.Condicao_religiosa,
                    Data_visita = modelo.Data_visita,
                    celula_ = p.celula_,
                    Chamada = p.Chamada,
                    Cpf = p.Cpf,
                    Data_nascimento = p.Data_nascimento,
                    Email = p.Email,
                    Endereco = p.Endereco,
                    Estado_civil = p.Estado_civil,
                    Falta = p.Falta,
                    Historico = p.Historico,
                    Img = p.Img,
                    Falescimento = p.Falescimento,
                    Nome = p.Nome,
                    Reuniao = p.Reuniao,
                    Rg = p.Rg,
                    Ministerios = p.Ministerios,
                    Sexo_feminino = p.Sexo_feminino,
                    Sexo_masculino = p.Sexo_masculino,
                    Telefone = p.Telefone,
                    Status = p.Status,
                    Codigo = p.Codigo
                };
                v.salvar();
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
           $"  where Id='{id}' ";
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from MudancaEstado as M where M.Id='{id}'";
            
            bd.Excluir(this);
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from MudancaEstado ";
            if(id != null) Select_padrao += $" as P where  P.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
                if (dr.HasRows == false)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        dr.Read();
                        
                        this.velhoEstado = Convert.ToString(dr["velhoEstado"]);
                        this.CodigoPessoa = int.Parse(Convert.ToString(dr["CodigoPessoa"]));
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
            }
            else
            {


                if (dr.HasRows == false)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        while (dr.Read())
                        {
                            MudancaEstado m = new MudancaEstado();
                            m.CodigoPessoa = int.Parse(Convert.ToString(dr["CodigoPessoa"]));
                            m.velhoEstado = Convert.ToString(dr["velhoEstado"]);
                            m.novoEstado = Convert.ToString(dr["novoEstado"]);
                            m.DataMudanca = Convert.ToDateTime(dr["DataMudanca"]);
                            modelos.Add(m);
                        }

                        dr.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    return modelos;
                }

            }

        }

        public override string salvar()
        {
            Insert_padrao = "insert into MudancaEstado (velhoEstado, novoEstado, DataMudanca, CodigoPessoa) " +
                $" values ('{velhoEstado}', '{novoEstado}', '{DateTime.Now.ToString()}', '{CodigoPessoa}')";
            
            bd.SalvarModelo(this);
            return Insert_padrao;
        }
    }
}
