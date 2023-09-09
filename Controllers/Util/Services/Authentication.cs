using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO
{
    public class Authentication
    {
        private Seguridad seguridad = new();
        public ClaimsIdentity GetClaimsIdentity(UserDTO user)
        {
            var token = seguridad.GeneratorToken(user);
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Authentication, token)
            };
            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public ClaimsIdentity GetClaimsIdentity(UserDTO user, string token)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Authentication, token)
            };
            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}