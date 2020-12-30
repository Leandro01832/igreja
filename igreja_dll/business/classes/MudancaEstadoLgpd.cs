using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;

namespace business.classes.Abstrato
{
    public class MudancaEstadoLgpd : modelocrud, IMudancaEstadoLgpd
    {
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime DataMudanca { get; set; }
        public int Pessoa_ { get; set; }
        [ForeignKey("Pessoa_")]
        public virtual PessoaLgpd Pessoa { get; set; }

        public MudancaEstadoLgpd() :base()
        {
            this.DataMudanca = DateTime.Now;
        }

        public void MudarEstado(int idVelhoEstado, modelocrud m)
        {
            string estado = "";
            PessoaLgpd p = (PessoaLgpd)m.recuperar(idVelhoEstado)[0];

            if (new Membro_TransferenciaLgpd().recuperar(idVelhoEstado) != null)
            {
                new Membro_TransferenciaLgpd().excluir(idVelhoEstado);
                estado = "Membro_Transferencia";
            }

            if (new Membro_ReconciliacaoLgpd().recuperar(idVelhoEstado) != null)
            {
                new Membro_ReconciliacaoLgpd().excluir(idVelhoEstado);
                estado = "Membro_Reconciliacao";
            }               

            if (new Membro_BatismoLgpd().recuperar(idVelhoEstado) != null)
            {
                new Membro_BatismoLgpd().excluir(idVelhoEstado);
                estado = "Membro_Batismo";
            }               

            if (new Membro_AclamacaoLgpd().recuperar(idVelhoEstado) != null)
            {
                new Membro_AclamacaoLgpd().excluir(idVelhoEstado);
                estado = "Membro_Aclamacao";
            }                

            if (new VisitanteLgpd().recuperar(idVelhoEstado) != null)
            {
                new Visitante().excluir(idVelhoEstado);
                estado = "Visitante";
            }                

            if (new CriancaLgpd().recuperar(idVelhoEstado) != null)
            {
                new CriancaLgpd().excluir(idVelhoEstado);
                estado = "Crianca";
            }                

            if (m.GetType().Name == "Membro_Aclamacao")
            {
                var modelo = (Membro_AclamacaoLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                membro.salvar();
            }

            if (m.GetType().Name == "Membro_Batismo")
            {
                var modelo = (Membro_BatismoLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                membro.salvar();
            }

            if (m.GetType().Name == "Membro_Reconciliacao")
            {
                var modelo = (Membro_ReconciliacaoLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                membro.salvar();
            }

            if (m.GetType().Name == "Membro_Transferencia")
            {
                var modelo = (Membro_TransferenciaLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                membro.salvar();
            }

            if (m.GetType().Name == "Crianca")
            {
                var modelo = (CriancaLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                c.salvar();
            }

            if (m.GetType().Name == "Visitante")
            {
                var modelo = (VisitanteLgpd)m;
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
                    Ministerios = p.Ministerios
                };
                v.salvar();
            }

            new MudancaEstado
            {
                novoEstado = m.GetType().Name,
                velhoEstado = estado,
                DataMudanca = DateTime.Now,
                Pessoa_ = m.recuperar(null).Last().Id
            }.salvar();
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update MudancaEstado set velhoEstado='{velhoEstado}', " +
           $" novoEstado='{novoEstado}', DataMudanca='{DataMudanca}', Pessoa_='{Pessoa_}' " +
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
                        this.Pessoa_ = int.Parse(Convert.ToString(dr["Pessoa_"]));
                        this.velhoEstado = Convert.ToString(dr["velhoEstado"]);
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
                            this.Pessoa_ = int.Parse(Convert.ToString(dr["Pessoa_"]));
                            this.velhoEstado = Convert.ToString(dr["velhoEstado"]);
                            this.novoEstado = Convert.ToString(dr["novoEstado"]);
                            this.DataMudanca = Convert.ToDateTime(dr["DataMudanca"]);
                            modelos.Add(this);
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
            Insert_padrao = "insert into MudancaEstado (velhoEstado, novoEstado, DataMudanca, Pessoa_) " +
                $" values ('{velhoEstado}', '{novoEstado}', '{DateTime.Now.ToString()}', '{Pessoa_}')";
            
            bd.SalvarModelo(this);
            return Insert_padrao;
        }
    }
}
