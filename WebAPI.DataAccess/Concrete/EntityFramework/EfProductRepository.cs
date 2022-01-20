using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.DataAccess.Concrete.EntityFramework;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.EntityFramework.DataBase;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepository<Product, NothwindContext>,IProductRepository
    {

    }
}
