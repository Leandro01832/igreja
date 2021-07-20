using business.classes.Celula;
using repositorioEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using business.classes.Abstrato;
using System.Linq;
using System.Web;
using RepositorioEF;

namespace Site.Models.Repository
{
    public interface ICelulaRepository
    {
        IEnumerable<Celula> GetAll();
        Celula Get(int id);
        void Add(Celula item);
        void Update(Celula item);
        bool Delete(int id);
    }

    public class CelulaRepository : BaseRepository<Celula>, ICelulaRepository
    {
        public CelulaRepository(DB contexto) : base(contexto)
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

        public Celula Get(int id)
        {
            return contexto.celula.Find(id);
        }

        public IEnumerable<Celula> GetAll()
        {
            return contexto.celula.ToList();
        }

        public void Update(Celula item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Add(Celula item)
        {
            contexto.celula.Add(item);
            contexto.SaveChanges();
        }
        
    }
}