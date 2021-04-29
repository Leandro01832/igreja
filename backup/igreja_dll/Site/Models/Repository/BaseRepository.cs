using repositorioEF;
using RepositorioEF;
using System.Configuration;
using System.Data.Entity;

namespace Site.Models.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DB contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(DB contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}