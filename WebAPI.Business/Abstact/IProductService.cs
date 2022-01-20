using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Business.Abstact
{
    public interface IProductService
    {
        void Insert(Product product);
        void Delete(Product product);
        void Update(Product product);

        List<Product> GetAll();
    }
}
