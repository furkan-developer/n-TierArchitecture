using System.Collections.Generic;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
using WebAPI.Entities;

namespace WebAPI.Business.Abstact
{
    public interface ICategoryService
    {
        IResult Insert(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<List<Category>> GetAll();
    }
}
