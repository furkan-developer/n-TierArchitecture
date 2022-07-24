using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.Core.Entities.Concrete;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
using WebAPI.Core.Utilities.ResultStructure.Concrete;
using WebAPI.DataAccess.Abstract;

namespace WebAPI.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Add(User user)
        {
            _userDal.Insert(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u=>u.Email == email);
            if (result != null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }
    }
}
