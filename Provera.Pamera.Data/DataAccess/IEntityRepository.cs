using Provera.Pamera.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Provera.Pamera.Data.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);

        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
