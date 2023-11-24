using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO
{
    public class Authentication
    {
        public ClaimsIdentity GetClaimIdentity(UserDTO user)
        {
            var claim = new List<Claim>{
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            return new (claim, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}