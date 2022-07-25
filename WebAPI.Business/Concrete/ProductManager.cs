using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.Business.BusinessAspects.Autofac;
using WebAPI.Business.ValidationRules.FluentValidation;
using WebAPI.Core.Ascepts;
using WebAPI.Core.Ascepts.Autofac.Validation;
using WebAPI.Core.CrossCuttingConcerns.Validation.FluentValidation;
using WebAPI.Core.Utilities.Business;
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

        [SecuredOperation("admin", Priority = 1)]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_rp.GetAll(), "Ürünler listesi getirildi");

        }

        [SecuredOperation("admin", Priority = 1)]
        [ValidationAscept(typeof(ProductValidator), Priority = 2)]
        public IResult Insert(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameCorrect(product));
            if (result != null)
            {
                return result;
            }
            return new SuccessResult("Product nesnesi eklendi.");
        }

        public IResult Update(Product product)
        {
            _rp.Update(product);
            return new SuccessResult("Ürün güncelleme işlemi başarılı");
        }

        #region

        private IResult CheckIfProductNameCorrect(Product product)
        {
            bool result = _rp.GetAll(p => p.ProductName == product.ProductName).Any();
            if (result)
            {
                return new ErrorResult(product.ProductName + " bu isme ait ürün mevcuttur.");
            }
            return new SuccessResult("Ürün eklendi.");
        }

        #endregion
    }
}
