using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DdataGridViews
{
   public class Pesquisar :  IPesquisar
    {

        public List<modelocrud> BuscarPorRestricao(modelocrud modelo, string tipo, string comando)
        {
            var comand = "";
            var innerjoin = "";
            DataTable dtable = new DataTable();            

            if (modelo is business.classes.Abstrato.Membro)
                innerjoin = " inner join Membro as MEM  on M.Id=MEM.Id inner join PessoaDado as PD on MEM.Id=P.Id"
                    + " inner join Pessoa as P on PD.Id=P.Id";

            if (modelo is business.classes.Abstrato.MembroLgpd)
                innerjoin = " inner join MembroLgpd as MEM  on M.Id=MEM.Id inner join PessoaLgpd as PL on MEM.Id=P.Id"
                    + " inner join Pessoa as P on PD.Id=P.Id";

             if (modelo is PessoaDado)
                innerjoin = " inner join PessoaDado as PD on M.Id=P.Id inner join Pessoa as P on PD.Id=P.Id ";

             if (modelo is PessoaLgpd)
                innerjoin = " inner join PessoaLgpd as PD on M.Id=P.Id inner join Pessoa as P on PD.Id=P.Id ";

            if (modelo != null)
                comand = $"select * from {modelo.GetType().Name} as M {innerjoin} ";

            if (modelo == null)
                comand = $"select * from {tipo} as M {innerjoin} ";

            if (comando != "")
                comand += $" where {comando} ";

            SqlCommand c = new SqlCommand(comand, new BDcomum().obterconexao());
            SqlDataAdapter objadp = new SqlDataAdapter(c);
            objadp.Fill(dtable);

            if (modelo == null && tipo == "Pessoa" ||
                modelo == null && tipo == "PessoaLgpd" ||
                modelo is Visitante ||
                modelo is Crianca ||
                modelo is Membro_Aclamacao ||
                modelo is Membro_Batismo ||
                modelo is Membro_Reconciliacao ||
                modelo is Membro_Transferencia ||
                modelo is business.classes.PessoasLgpd.VisitanteLgpd ||
                modelo is business.classes.PessoasLgpd.CriancaLgpd ||
                modelo is business.classes.PessoasLgpd.Membro_AclamacaoLgpd ||
                modelo is business.classes.PessoasLgpd.Membro_BatismoLgpd ||
                modelo is business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd ||
                modelo is business.classes.PessoasLgpd.Membro_TransferenciaLgpd)
            {
                List<modelocrud> l = new List<modelocrud>();
                var listaPessoa = business.classes.Abstrato.Pessoa.recuperarTodos()
                    .OfType<business.classes.Abstrato.Pessoa>().ToList();
                var lista = new List<modelocrud>();
                foreach(var itemlista in listaPessoa)
                {
                    lista.Add(itemlista.recuperar(itemlista.IdPessoa)[0]);
                }

                foreach (var item in dtable.Select(""))
                {
                    l.Add(lista.OfType<business.classes.Abstrato.Pessoa>()
                     .First(i => i.IdPessoa == int.Parse(item["IdPessoa"].ToString())));
                }
                return l;
            }

            if (modelo == null && tipo == "Ministerio" || modelo is business.classes.Ministerio.Lider_Celula ||
                modelo is business.classes.Ministerio.Lider_Celula_Treinamento ||
                modelo is business.classes.Ministerio.Lider_Ministerio ||
                modelo is business.classes.Ministerio.Lider_Ministerio_Treinamento ||
                modelo is business.classes.Ministerio.Supervisor_Celula ||
                modelo is business.classes.Ministerio.Supervisor_Celula_Treinamento ||
                modelo is business.classes.Ministerio.Supervisor_Ministerio ||
                modelo is business.classes.Ministerio.Supervisor_Ministerio_Treinamento)
            {
                List<modelocrud> l = new List<modelocrud>();
                var listaMinisterio = business.classes.Abstrato.Ministerio.recuperarTodosMinisterios()
                    .OfType<business.classes.Abstrato.Ministerio>().ToList();
                var lista = new List<modelocrud>();
                foreach (var itemlista in listaMinisterio)
                {
                    lista.Add(itemlista.recuperar(itemlista.IdMinisterio)[0]);
                }

                foreach (var item in dtable.Select(""))
                {
                    l.Add(lista.OfType<business.classes.Abstrato.Ministerio>()
                        .First(i => i.IdMinisterio == int.Parse(item["IdMinisterio"].ToString())));
                }
                return l;
            }

            if (modelo == null && tipo == "Celula" ||
                modelo is business.classes.Celulas.Celula_Adolescente ||
                modelo is business.classes.Celulas.Celula_Adulto ||
                modelo is business.classes.Celulas.Celula_Casado ||
                modelo is business.classes.Celulas.Celula_Crianca ||
                modelo is business.classes.Celulas.Celula_Jovem)
            {
                List<modelocrud> l = new List<modelocrud>();
                var listaCelula = business.classes.Abstrato.Celula.recuperarTodasCelulas()
                .OfType<business.classes.Abstrato.Celula>().ToList();
                var lista = new List<modelocrud>();
                foreach (var itemlista in listaCelula)
                {
                    lista.Add(itemlista.recuperar(itemlista.IdCelula)[0]);
                }

                foreach (var item in dtable.Select(""))
                {
                    l.Add(lista.OfType<business.classes.Abstrato.Celula>()
                        .First(i => i.IdCelula == int.Parse(item["IdCelula"].ToString())));
                }
                return l;
            }

           

            if (modelo is business.classes.Historico || modelo is business.classes.Reuniao ||
                modelo is business.classes.Chamada || modelo is business.classes.MudancaEstado ||
                modelo is business.classes.Endereco || modelo is business.classes.Telefone)
            {
                List<modelocrud> l = new List<modelocrud>();
                foreach (var item in dtable.Select(""))
                {
                    l.Add(modelo.recuperar(int.Parse(item["Id"].ToString()))[0]);
                }
                return l;
            }

            return null;
        }


        
    }
}
