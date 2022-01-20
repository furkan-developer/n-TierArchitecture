using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
using WebAPI.Entities;

namespace WebAPI.Business.Abstact
{
    public interface IProductService
    {
        IResult Insert(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        IDataResult<List<Product>> GetAll();
    }
}
