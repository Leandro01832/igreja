using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using business.classes;
using RepositorioEF;

namespace Site.Models.Repository
{
    public interface IReuniaoRepository
    {
        IEnumerable<Reuniao> GetAll();
        Reuniao Get(int id);
        void Add(Reuniao item);
        void Update(Reuniao item);
        bool Delete(int id);
    }

    public class ReuniaoRepository : BaseRepository<Reuniao>, IReuniaoRepository
    {
        public ReuniaoRepository(DB contexto) : base(contexto)
        {
        }

        public bool Delete(int id)
        {
            var condicao = contexto.celula.FirstOrDefault(m => m.Id == id);
            if (condicao != null)
            {
                var model = contexto.celula.First(m => m.Id == id);
                contexto.celula.Remove(model);
                contexto.DadoExcluido.Add(new DadoExcluido { Entidade = model.GetType().Name, IdDado = id });
                contexto.SaveChanges();
                return true;
            }
            else return false;
        }

        public Reuniao Get(int id)
        {
            return contexto.reuniao.Find(id);
        }

        public IEnumerable<Reuniao> GetAll()
        {
            return contexto.reuniao.ToList();
        }

        public void Update(Reuniao item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.DadoAlterado.Add(new DadoAlterado { Entidade = item.GetType().Name, IdDado = item.Id });
            contexto.SaveChanges();
        }

        public void Add(Reuniao item)
        {
            contexto.reuniao.Add(item);
            contexto.SaveChanges();
        }
        
    }
}