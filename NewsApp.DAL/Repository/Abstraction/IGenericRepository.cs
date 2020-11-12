using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DAL.Repository.Abstraction
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity getEntity(TEntity entity);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void setFavorite(TEntity entity);
        void addFavorite(TEntity entity);

    }
}
