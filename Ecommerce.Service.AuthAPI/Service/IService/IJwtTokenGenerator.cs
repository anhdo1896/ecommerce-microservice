using Ecommerce.Service.AuthAPI.Models;
using System.Security.Claims;

namespace Ecommerce.Service.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipalFromExpriredToken(string token);

    }
}
