using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.DataAccess.Abstract;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Abstract
{
    public interface IProductRepository:IEntityRepository<Product>
    {
    }
}
