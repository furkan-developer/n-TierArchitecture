using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Entities.Abstract;

namespace WebAPI.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);

        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
    }
}
