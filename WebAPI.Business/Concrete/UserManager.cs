using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Business.Abstact;
using WebAPI.Core.Entities.Concrete;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
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
            return new DataResult<List<OperationClaim>>(_userDal.GetClaims(user),true);
        }

        public IResult Add(User user)
        {
            return new Result(true);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new DataResult<User>(_userDal.Get(u=>u.Email == email),true);
        }
    }
}
