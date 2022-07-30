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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _rp;

        public CategoryManager(ICategoryRepository rp)
        {
            _rp = rp;
        }

        public IResult Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _rp.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IResult Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
