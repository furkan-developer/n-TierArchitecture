using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.DataAccess.Abstract;
using WebAPI.Core.Entities.Abstract;

namespace WebAPI.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityEntry = context.Entry(entity);
                entityEntry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext context = new TContext())
            {
                return expression == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(expression).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(expression);
            }
        }

        public void Insert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var entityEntry = context.Entry(entity);
                entityEntry.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Update(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var entityEntry = context.Entry(entity);
                entityEntry.State = EntityState.Modified;
                context.SaveChanges();
            } 
        }
    }
}
