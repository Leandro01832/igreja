using database;
using RepositorioEF;
using System.Data.Entity;

namespace Site.Models.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DB contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(DB contexto)
        {
            modelocrud.EntityCrud = true;
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}