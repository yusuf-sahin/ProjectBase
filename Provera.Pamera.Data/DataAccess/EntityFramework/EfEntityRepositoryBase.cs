using Microsoft.EntityFrameworkCore;
using Provera.Pamera.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Provera.Pamera.Data.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public virtual async Task AddAsync(TEntity entity)
        {
            var context = new TContext();
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }



        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }


        public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().OrderBy(x => x.Id).ToListAsync() : await context.Set<TEntity>().Where(filter).OrderBy(x => x.Id).ToListAsync();
            }
        }

    }
}
