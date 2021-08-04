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
                contexto.celula.Remove(contexto.celula.First(m => m.Id == id));
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
            contexto.SaveChanges();
        }

        public void Add(Reuniao item)
        {
            contexto.reuniao.Add(item);
            contexto.SaveChanges();
        }
        
    }
}