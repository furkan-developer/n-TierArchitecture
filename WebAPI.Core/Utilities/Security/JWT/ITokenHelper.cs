using System.Collections.Generic;
using WebAPI.Core.Entities.Concrete;

namespace WebAPI.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
