using System.Security.Claims;

namespace EasySolutionHospital.Helper
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetFullName(this ClaimsPrincipal claimsPrincipal) =>
            claimsPrincipal.FindFirstValue<string>(ClaimTypes.Name);

        public static string GetUserRole(this ClaimsPrincipal claimsPrincipal) =>
           claimsPrincipal.FindFirstValue<string>(ClaimTypes.Role);

        public static string GetUserId(this ClaimsPrincipal claimsPrincipal) =>
          claimsPrincipal.FindFirstValue<string>(ClaimTypes.NameIdentifier);

        public static string GetUserAmount(this ClaimsPrincipal claimsPrincipal) =>
        claimsPrincipal.FindFirstValue<string>(ClaimTypes.SerialNumber);
    }

    public static class PrincipalExtensions
    {
        public static T FindFirstValue<T>(this ClaimsPrincipal principal, string claimType)
        {
            try
            {
                var claim = principal.FindFirst(claimType);
                return (T)Convert.ChangeType(claim.Value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
