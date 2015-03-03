using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sof.Data
{
    public partial interface IRepository<TEntity, in TKey> where TEntity : IEntity
    {
        TEntity FindById(TKey id);
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
