using System.Security.Claims;

namespace StockMarket.Helpers.ClaimsExtension
{
    public static class ClaimExtension
    {
        public static String GetuserName(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        }
    }
}
