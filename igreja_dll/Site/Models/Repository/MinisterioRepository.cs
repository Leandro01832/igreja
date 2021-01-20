using business.classes.Celula;
using repositorioEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using business.classes.Abstrato;
using System.Linq;
using System.Web;

namespace Site.Models.Repository
{
    public interface IMinisterioRepository
    {
        IEnumerable<Ministerio> GetAll();
        Ministerio Get(int id);
        void Add(Ministerio item);
        void Update(Ministerio item);
        bool Delete(int id);
    }

    public class MinisterioRepository : BaseRepository<Ministerio>, IMinisterioRepository
    {
        public MinisterioRepository(DB contexto) : base(contexto)
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

        public Ministerio Get(int id)
        {
            return contexto.ministerio.Find(id);
        }

        public IEnumerable<Ministerio> GetAll()
        {
            return contexto.ministerio.ToList();
        }

        public void Update(Ministerio item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Add(Ministerio item)
        {
            contexto.ministerio.Add(item);
            contexto.SaveChanges();
        }
        
    }
}