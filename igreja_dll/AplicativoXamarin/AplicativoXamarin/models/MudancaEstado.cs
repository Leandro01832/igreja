using AplicativoXamarin.models.Interface;
using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.models.PessoasLgpd;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicativoXamarin.models
{
    public class MudancaEstado :  IMudancaEstado
    {
        public int Id { get; set; }
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime DataMudanca { get; set; }
        public int CodigoPessoa { get; set; }

        public ApiServices Api { get; set; }

        public MudancaEstado() :base()
        {
            this.DataMudanca = DateTime.Now;
            Api = new ApiServices();

        }

        public async void MudarEstado(int idVelhoEstado, Pessoa m)
        {
            string estado = "";
            List<Pessoa> lista = await recuperarTodos();
            List<Pessoa> lista2 = new List<Pessoa>();
            foreach (var item in lista)
            lista2.Add((Pessoa)item);
            Pessoa p = await ApiServices.GetPessoa();
            estado = p.GetType().Name;

            excluirPessoaVelha(idVelhoEstado);            

            var data = new DataAccess();
            var user = data.First();

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
                   var pes = await salvar(membro);
                    membro.Endereco.Id = pes.IdPessoa;
                     salvarEndereco(membro.Endereco);
                    membro.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(membro.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    membro.Endereco.Id = pes.IdPessoa;
                    salvarEndereco(membro.Endereco);
                    membro.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(membro.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    membro.Endereco.Id = pes.IdPessoa;
                    salvarEndereco(membro.Endereco);
                    membro.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(membro.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    membro.Endereco.Id = pes.IdPessoa;
                    salvarEndereco(membro.Endereco);
                    membro.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(membro.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(c);
                    c.Endereco.Id = pes.IdPessoa;
                    salvarEndereco(c.Endereco);
                    c.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(c.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(v);
                    v.Endereco.Id = pes.IdPessoa;
                    salvarEndereco(v.Endereco);
                    v.Telefone.Id = pes.IdPessoa;
                    salvarTelefone(v.Telefone);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(membro);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(c);
                    user.IdPessoa = pes.IdPessoa;
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
                    var pes = await salvar(v);
                    user.IdPessoa = pes.IdPessoa;
                }
            }

            data.Update(user);

            var minis = p.Ministerios;
            if (minis != null)
                foreach (var itemMinisterio in minis)
                {
                    PessoaMinisterio item = await retornaPessoaMinsterio(itemMinisterio.Id);
                    Api.ParticiparMinisterio(item.Ministerio);
                }

            var reu = p.Reuniao;
            if (reu != null)
                foreach (var itemReuniao in reu)
                {
                    ReuniaoPessoa item = await retornaReuniaoPessoa(itemReuniao.Id);
                    Api.ParticiparReuniao(item.Reuniao);
                }


            var mudanca =  new MudancaEstado
            {
                novoEstado = m.GetType().Name,
                velhoEstado = estado,
                DataMudanca = DateTime.Now,
                CodigoPessoa = p.Codigo
            };
            salvarMudanca(mudanca);
        }

        private void salvarTelefone(Telefone telefone)
        {
            Api.salvarTelefone(telefone);
        }

        private  void salvarEndereco(Endereco endereco)
        {
            Api.salvarEndereco(endereco);
        }

        private async Task<ReuniaoPessoa> retornaReuniaoPessoa(int Id)
        {
            return await Api.retornaReuniaoPessoa(Id);
        }

        private async Task<PessoaMinisterio> retornaPessoaMinsterio(int Id)
        {
           return  await Api.retornaPessoaMinsterio(Id);
        }

        private void salvarMudanca(MudancaEstado mudanca)
        {
             Api.salvarMudancaEstado(mudanca);
        }

        private async Task<Pessoa> salvar(modelocrud pessoa)
        {
          return  await Api.salvarPessoaMudancaEstado(pessoa);
        }

        private  void excluirPessoaVelha(int idVelhoEstado)
        {
              Api.ExcluirPessoa(idVelhoEstado);
        }

        private async Task<List<Pessoa>> recuperarTodos()
        {
           return await  Api.RecuperarTodasPessoas();
        }

        
    }
}
