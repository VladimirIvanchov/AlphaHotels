using System.Security.Claims;

namespace AlphaHotel.Common
{
    public interface IUserHelper
    {
        string GetId(ClaimsPrincipal user);
    }
}
