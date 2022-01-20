using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities;

namespace WebAPI.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _rp;

        public ProductManager(IProductRepository rp)
        {
            _rp = rp;
        }

        public void Delete(Product product)
        {
            _rp.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _rp.GetAll();
        }

        public void Insert(Product product)
        {
            _rp.Insert(product);
        }

        public void Update(Product product)
        {
            _rp.Update(product);
        }
    }
}
