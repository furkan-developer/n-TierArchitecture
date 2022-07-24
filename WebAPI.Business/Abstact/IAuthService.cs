using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Entities.Concrete;
using WebAPI.Core.Utilities.ResultStructure;
using WebAPI.Core.Utilities.ResultStructure.Abstact;
using WebAPI.Core.Utilities.Security.JWT;
using WebAPI.Entities.Dtos;

namespace WebAPI.Business.Abstact
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
