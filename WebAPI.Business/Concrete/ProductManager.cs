using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
using WebAPI.Core.Utilities.ResultStructure.Concrete;
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

        public IResult Delete(Product product)
        {
            _rp.Delete(product);
            return new SuccessResult("Ürün silme işlemi başarılı");
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_rp.GetAll(), "Ürünler listesi getirildi");

        }

        public IResult Insert(Product product)
        {
            _rp.Insert(product);
            return new ErrorResult("Product nesnesi eklendi.");
        }

        public IResult Update(Product product)
        {
            _rp.Update(product);
            return new SuccessResult("Ürün güncelleme işlemi başarılı");
        }
    }
}
