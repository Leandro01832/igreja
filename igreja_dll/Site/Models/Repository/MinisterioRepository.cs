
using System.Collections.Generic;
using System.Data.Entity;
using business.classes.Abstrato;
using System.Linq;
using RepositorioEF;
using business.classes;

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
            var condicao = contexto.ministerio.FirstOrDefault(m => m.Id == id);
            if (condicao != null)
            {
                var model = contexto.ministerio.First(m => m.Id == id);
                contexto.ministerio.Remove(model);
                contexto.DadoExcluido.Add(new DadoExcluido { Entidade = model.GetType().Name, IdDado = id });
                contexto.SaveChanges();
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
            return contexto.ministerio;
        }

        public void Update(Ministerio item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.DadoAlterado.Add(new DadoAlterado { Entidade = item.GetType().Name, IdDado = item.Id });
            contexto.SaveChanges();
        }

        public void Add(Ministerio item)
        {
            contexto.ministerio.Add(item);
            contexto.SaveChanges();
        }
        
    }
}