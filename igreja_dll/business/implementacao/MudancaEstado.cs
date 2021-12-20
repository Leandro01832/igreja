﻿using business.classes.Abstrato;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.contrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;

namespace business.implementacao
{
    [Table("MudancaEstado")]
    public class MudancaEstado : modelocrud, IMudancaEstado
    {
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime Data { get; set; }
        public int Codigo { get; set; }
        

        public MudancaEstado() : base()
        {
            this.Data = DateTime.Now;
        }
        

        public void MudarEstado(int idVelhoEstado, modelocrud m)
        {
            string estado = "";

            if (m is Pessoa)
            {
                var model1 = new Visitante                (); var p1 = model1.recuperar(idVelhoEstado);
                var model2 = new VisitanteLgpd            (); var p2 = model2.recuperar(idVelhoEstado);
                var model3 = new Crianca                  (); var p3 = model3.recuperar(idVelhoEstado);
                var model4 = new CriancaLgpd              (); var p4 = model4.recuperar(idVelhoEstado);
                var model5 = new Membro_Aclamacao         (); var p5 = model5.recuperar(idVelhoEstado);
                var model6 = new Membro_AclamacaoLgpd     (); var p6 = model6.recuperar(idVelhoEstado);
                var model7 = new Membro_Batismo           (); var p7 = model7.recuperar(idVelhoEstado);
                var model8 = new Membro_BatismoLgpd       (); var p8 = model8.recuperar(idVelhoEstado);
                var model9 = new Membro_Reconciliacao     (); var p9 = model9.recuperar(idVelhoEstado);
                var model10 = new Membro_ReconciliacaoLgpd(); var p10 = model10.recuperar(idVelhoEstado);
                var model11 = new Membro_Transferencia    (); var p11 = model11.recuperar(idVelhoEstado);
                var model12 = new Membro_TransferenciaLgpd(); var p12 = model12.recuperar(idVelhoEstado);
                Pessoa p = null;
                if (p1) p = model1;
                if (p2) p = model2;
                if (p3) p = model3;
                if (p4) p = model4;
                if (p5) p = model5;
                if (p6) p = model6;
                if (p7) p = model7;
                if (p8) p = model8;
                if (p9) p = model9;
                if (p10) p = model10;
                if (p11) p = model11;
                if (p12) p = model12;
                estado = p.GetType().Name;

                p.excluir(idVelhoEstado);

                var model = Modelos.First(i => i.Id == p.Id);
                var valor = (Pessoa)model;
                p.Ministerio = valor.Ministerio;
                p.Reuniao = valor.Reuniao;

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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = pd.Historicos,
                            Imagem = pd.Imagem,
                            Falescimento = pd.Falescimento,
                            Nome = pd.Nome,
                            Reuniao = pd.Reuniao,
                            Rg = pd.Rg,
                            Ministerio = pd.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
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
                            Historicos = p.Historicos,
                            Imagem = p.Imagem,
                            Reuniao = p.Reuniao,
                            Ministerio = p.Ministerio,
                            Codigo = p.Codigo
                        };
                        v.salvar();
                    }
                }

                new MudancaEstado
                {
                    novoEstado = m.GetType().Name,
                    velhoEstado = estado,
                    Data = DateTime.Now,
                    Codigo = p.Codigo
                }.salvar();
            }

            if (m is Ministerio)
            {
                var model1 = new Lider_Celula                     (); var p1 = model1.recuperar(idVelhoEstado);
                var model2 = new Lider_Celula_Treinamento         (); var p2 = model2.recuperar(idVelhoEstado);
                var model3 = new Lider_Ministerio                 (); var p3 = model3.recuperar(idVelhoEstado);
                var model4 = new Lider_Ministerio_Treinamento     (); var p4 = model4.recuperar(idVelhoEstado);
                var model5 = new Supervisor_Celula                (); var p5 = model5.recuperar(idVelhoEstado);
                var model6 = new Supervisor_Celula_Treinamento    (); var p6 = model6.recuperar(idVelhoEstado);
                var model7 = new Supervisor_Ministerio            (); var p7 = model7.recuperar(idVelhoEstado);
                var model8 = new Supervisor_Ministerio_Treinamento(); var p8 = model8.recuperar(idVelhoEstado);
                Ministerio p = null;
                if (p1) p = model1;
                if (p2) p = model2;
                if (p3) p = model3;
                if (p4) p = model4;
                if (p5) p = model5;
                if (p6) p = model6;
                if (p7) p = model7;
                if (p8) p = model8;
                estado = p.GetType().Name;

                p.excluir(idVelhoEstado);

                var model = Modelos.First(i => i.Id == p.Id);
                var valor = (Ministerio)model;
                p.Celulas = valor.Celulas;
                p.Pessoa = valor.Pessoa;  
                
                if(m is Lider_Celula)
                {
                    var modelo = (Lider_Celula)m;
                    Lider_Celula minis = new Lider_Celula
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito                         
                    };
                    minis.salvar();
                }

                if (m is Lider_Celula_Treinamento)
                {
                    var modelo = (Lider_Celula_Treinamento)m;
                    Lider_Celula_Treinamento minis = new Lider_Celula_Treinamento
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito                         
                    };
                    minis.salvar();
                }

                if (m is Lider_Ministerio)
                {
                    var modelo = (Lider_Ministerio)m;
                    Lider_Ministerio minis = new Lider_Ministerio
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito                         
                    };
                    minis.salvar();
                }

                if (m is Lider_Ministerio_Treinamento)
                {
                    var modelo = (Lider_Ministerio_Treinamento)m;
                    Lider_Ministerio_Treinamento minis = new Lider_Ministerio_Treinamento
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito                         
                    };
                    minis.salvar();
                }

                if (m is Supervisor_Celula)
                {
                    var modelo = (Supervisor_Celula)m;
                    Supervisor_Celula minis = new Supervisor_Celula
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito,
                         Maximo_celula = modelo.Maximo_celula                          
                    };
                    minis.salvar();
                }

                if(m is Supervisor_Celula_Treinamento)
                {
                    var modelo = (Supervisor_Celula_Treinamento)m;
                    Supervisor_Celula_Treinamento minis = new Supervisor_Celula_Treinamento
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito,
                        Maximo_celula = modelo.Maximo_celula
                    };
                    minis.salvar();
                }

                if(m is Supervisor_Ministerio)
                {
                    var modelo = (Supervisor_Ministerio)m;
                    Supervisor_Ministerio minis = new Supervisor_Ministerio
                    {
                        Pessoa = p.Pessoa,
                        Celulas = p.Celulas,
                        Codigo = modelo.Codigo,
                        Ministro_ = modelo.Ministro_,
                        Maximo_pessoa = modelo.Maximo_pessoa,
                        Nome = modelo.Nome,
                        Proposito = modelo.Proposito,
                        Maximo_celula = modelo.Maximo_celula                         
                    };
                    minis.salvar();
                }

                new MudancaEstado
                {
                    novoEstado = m.GetType().Name,
                    velhoEstado = estado,
                    Data = DateTime.Now,
                    Codigo = p.Codigo
                }.salvar();
            }
        }
        
        public override string ToString()
        {
            return "ID da mudança: " + Id.ToString() + " ID da pessoa: " + this.Codigo;
        }
    }
}
