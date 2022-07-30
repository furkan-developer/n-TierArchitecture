using WebAPI.Core.DataAccess.Concrete.EntityFramework;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.EntityFramework.DataBase;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepository<Category, NothwindContext>, ICategoryRepository
    {

    }
}
