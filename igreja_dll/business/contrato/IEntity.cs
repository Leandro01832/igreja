using database;
using System;
using System.Collections.Generic;

namespace business.contrato
{
   public interface IEntity<T> where T : class
    {
        void salvarEntity(T entity);
        void alterarEntity(T entity);
        void excluirEntity(T entity);
        modelocrud recuperarEntity(int id, T entity);
    }
}
