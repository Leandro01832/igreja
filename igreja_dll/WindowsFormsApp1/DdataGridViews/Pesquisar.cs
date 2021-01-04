using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DdataGridViews
{
   public class Pesquisar : modelocrud, IPesquisar
    {
        public List<modelocrud> BuscarPorRestricao(modelocrud modelo, string tipo, string comando)
        {
            var comand = "";
            var innerjoin = "";
            DataTable dtable = new DataTable();

            var listaPessoa = business.classes.Abstrato.PessoaLgpd.recuperarTodos();
            var listaMinisterio = business.classes.Abstrato.Ministerio.recuperarTodosMinisterios();
            var listaCelula = business.classes.Abstrato.Celula.recuperarTodasCelulas();

            if (modelo is business.classes.Abstrato.Membro)
                innerjoin = " inner join Membro as MEM  on M.Id=MEM.Id inner join Pessoa as P on MEM.Id=P.Id";

           else if (modelo is business.classes.Abstrato.Pessoa)
                innerjoin = " inner join Pessoa as P on M.Id=P.Id";

            if (modelo != null)
                comand = $"select * from {modelo.GetType().Name} as M {innerjoin} ";

            if (modelo == null)
                comand = $"select * from {tipo} as M {innerjoin} ";

            if (comando != "")
                comand += $" where {comando} ";

            SqlCommand c = new SqlCommand(comand, bd.obterconexao());
            SqlDataAdapter objadp = new SqlDataAdapter(c);
            objadp.Fill(dtable);

            if (modelo == null && tipo == "Pessoa" ||
                modelo is business.classes.Pessoas.Visitante ||
                modelo is business.classes.Pessoas.Crianca ||
                modelo is business.classes.Pessoas.Membro_Aclamacao ||
                modelo is business.classes.Pessoas.Membro_Batismo ||
                modelo is business.classes.Pessoas.Membro_Reconciliacao ||
                modelo is business.classes.Pessoas.Membro_Transferencia)
            {
                List<modelocrud> l = new List<modelocrud>();
                foreach (var item in dtable.Select(""))
                {
                    l.Add(listaPessoa.First(i => i.Id == int.Parse(item["Id"].ToString())));
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
                foreach (var item in dtable.Select(""))
                {
                    l.Add(listaMinisterio.First(i => i.Id == int.Parse(item["Id"].ToString())));
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
                foreach (var item in dtable.Select(""))
                {
                    l.Add(listaCelula.First(i => i.Id == int.Parse(item["Id"].ToString())));
                }
                return l;
            }

            if ( modelo is business.classes.Chamada)
            {
                List<modelocrud> l = new List<modelocrud>();
                foreach (var item in dtable.Select(""))
                {
                    l.Add(new business.classes.Chamada().recuperar(int.Parse(item["Id"].ToString()))[0]);
                }
                return l;
            }

            if (modelo is business.classes.Reuniao)
            {
                List<modelocrud> l = new List<modelocrud>();
                foreach (var item in dtable.Select(""))
                {
                    l.Add(new business.classes.Reuniao().recuperar(int.Parse(item["Id"].ToString()))[0]);
                }
                return l;
            }

            if (modelo is business.classes.Historico)
            {
                List<modelocrud> l = new List<modelocrud>();
                foreach (var item in dtable.Select(""))
                {
                    l.Add(new business.classes.Historico().recuperar(int.Parse(item["Id"].ToString()))[0]);
                }
                return l;
            }

            return null;
        }


        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }       

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override List<modelocrud> recuperar(int? id)
        {
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }
    }
}
