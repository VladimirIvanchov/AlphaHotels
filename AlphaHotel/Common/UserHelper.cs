using System;
using System.Security.Claims;

namespace AlphaHotel.Common
{
    public class UserHelper : IUserHelper
    {
        public string GetId(ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier);

            return userId?.Value;
        }
    }
}
