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
using WebAPI.Core.Utilities.Security.Hashing;
using WebAPI.Core.Utilities.Security.JWT;
using WebAPI.Entities.Dtos;

namespace WebAPI.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var result = _userService.Add(user);
            if(result.Process == true)
                return new SuccessDataResult<User>(user, "User registered");
            else 
                return new ErrorDataResult<User>("User could not register");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("User not found");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Password error");
            }

            return new SuccessDataResult<User>(userToCheck, "Success login");
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Process == false)
            {
                return new ErrorResult("User already exists");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);

            if (accessToken == null)
                return new ErrorDataResult<AccessToken>("Access token not create");

            return new SuccessDataResult<AccessToken>(accessToken, "Access token created successfully");
        }
    }
}
