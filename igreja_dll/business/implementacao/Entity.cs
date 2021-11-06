using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using business.contrato;
using business.database;
using database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.implementacao
{
    public class Entity : IEntity<modelocrud>
    {
        public Entity()
        {
            bd = new IgrejaDB();
        }

        static IgrejaDB bd;

        public void alterarEntity(modelocrud model)
        {
            bd.Entry(model).State = EntityState.Modified;
            bd.SaveChanges();
        }

        public void excluirEntity(modelocrud entity)
        {
            if(entity.GetType().IsSubclassOf(typeof(Pessoa)))      bd.pessoas.Remove((Pessoa)entity);
            if(entity.GetType().IsSubclassOf(typeof(Ministerio)))  bd.ministerio.Remove((Ministerio)entity);
            if(entity.GetType().IsSubclassOf(typeof(Celula)))      bd.celula.Remove((Celula)entity);
            if(entity.GetType() == typeof(Reuniao))                bd.reuniao.Remove((Reuniao)entity);
            if(entity.GetType() == typeof(MudancaEstado))          bd.MudancaEstado.Remove((MudancaEstado)entity);
            if(entity.GetType() == typeof(ReuniaoPessoa))          bd.ReuniaoPessoa.Remove((ReuniaoPessoa)entity);
            if(entity.GetType() == typeof(PessoaMinisterio))       bd.PessoaMinisterio.Remove((PessoaMinisterio)entity);
            if(entity.GetType() == typeof(MinisterioCelula))       bd.MinisterioCelula.Remove((MinisterioCelula)entity);
            if(entity.GetType() == typeof(Historico))              bd.historico.Remove((Historico)entity);
        }

        public modelocrud recuperarEntity(int id, modelocrud entity)
        {
            if(entity.GetType().IsSubclassOf(typeof(Pessoa)))     return  bd.pessoas.FirstOrDefault(i => i.Id == id);
            if(entity.GetType().IsSubclassOf(typeof(Ministerio))) return  bd.ministerio.FirstOrDefault(i => i.Id == id);
            if(entity.GetType().IsSubclassOf(typeof(Celula)))     return  bd.celula.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(Reuniao))               return  bd.reuniao.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(MudancaEstado))         return  bd.MudancaEstado.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(ReuniaoPessoa))         return  bd.ReuniaoPessoa.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(PessoaMinisterio))      return  bd.PessoaMinisterio.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(MinisterioCelula))      return  bd.MinisterioCelula.FirstOrDefault(i => i.Id == id);
            if(entity.GetType() == typeof(Historico))             return  bd.historico.FirstOrDefault(i => i.Id == id);

            return null;
        }

        public static Task<List<modelocrud>> recuperarEntity(Type type)
        {
            if (type == (typeof(Pessoa)))         return bd.pessoas.Include(p => p.Celula).Cast<modelocrud>().ToListAsync();
            if (type == (typeof(Ministerio)))     return bd.ministerio.Cast<modelocrud>().ToListAsync();
            if (type == (typeof(Celula)))         return bd.celula.Include(c => c.EnderecoCelula).Cast<modelocrud>().ToListAsync();
            if (type == typeof(Reuniao))          return bd.reuniao.Cast<modelocrud>().ToListAsync();
            if (type == typeof(MudancaEstado))    return bd.MudancaEstado.Cast<modelocrud>().ToListAsync();
            if (type == typeof(ReuniaoPessoa))    return bd.ReuniaoPessoa.Cast<modelocrud>().ToListAsync();
            if (type == typeof(PessoaMinisterio)) return bd.PessoaMinisterio.Cast<modelocrud>().ToListAsync();
            if (type == typeof(MinisterioCelula)) return bd.MinisterioCelula.Cast<modelocrud>().ToListAsync();
            if (type == typeof(Historico))        return bd.historico.Cast<modelocrud>().ToListAsync();

            return null;
        }

        public void salvarEntity(modelocrud model)
        {
            if(model.GetType().IsSubclassOf(typeof(Pessoa)))       bd.pessoas.Add((Pessoa)model);
            if(model.GetType().IsSubclassOf(typeof(Ministerio)))   bd.ministerio.Add((Ministerio)model);
            if(model.GetType().IsSubclassOf(typeof(Celula)))       bd.celula.Add((Celula)model);
            if(model.GetType() == typeof(Reuniao))                 bd.reuniao.Add((Reuniao)model);
            if(model.GetType() == typeof(MudancaEstado))           bd.MudancaEstado.Add((MudancaEstado)model);
            if(model.GetType() == typeof(ReuniaoPessoa))           bd.ReuniaoPessoa.Add((ReuniaoPessoa)model);
            if(model.GetType() == typeof(PessoaMinisterio))        bd.PessoaMinisterio.Add((PessoaMinisterio)model);
            if(model.GetType() == typeof(MinisterioCelula))        bd.MinisterioCelula.Add((MinisterioCelula)model);
            if(model.GetType() == typeof(Historico))               bd.historico.Add((Historico)model);
        }
    }
}
