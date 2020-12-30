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
    public interface ICelulaRepository
    {
        IEnumerable<Celula> GetAll();
        Celula Get(int id);
        void Add(Celula item);
        void Update(Celula item);
        void Delete(int id);
    }

    public class CelulaRepository : BaseRepository<Celula>, ICelulaRepository
    {
        public CelulaRepository(DB contexto) : base(contexto)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Celula Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celula> GetAll()
        {
            return contexto.celula;
        }

        public void Update(Celula item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Add(Celula item)
        {
            throw new NotImplementedException();
        }

        void ICelulaRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}