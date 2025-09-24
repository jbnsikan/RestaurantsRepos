using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = (httpContextAccessor?.HttpContext?.User) ?? throw new InvalidOperationException("User context is not present");
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userid = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

            return new CurrentUser(userid, email, roles);
        }
    }

    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
