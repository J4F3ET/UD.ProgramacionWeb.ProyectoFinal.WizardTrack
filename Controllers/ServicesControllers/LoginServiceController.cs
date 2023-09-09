using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServicesControllers
{
    [Route("Account/[controller]")]
    [ApiController]
    public class LoginServiceController : ControllerBase
    {
        // GET: Account/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET Account/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST Account/LoginService
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] LoginServiceDTO value)
        {
            Authentication authentication = new();
            Seguridad seguridad = new();
            ServiceUsuario service = new();
            try {
                if (value == null) 
                    throw new ArgumentNullException("Value es null");

                UserWizardtrack userWizardtrack = await service.SelectUser(null, value.email)
                    ?? throw new ArgumentNullException("Usuario no existe");

                if (!seguridad.VerifyPassword(userWizardtrack.Password, userWizardtrack.Salt, value.password)) 
                    throw new Exception("Contraseña incorrecta");

                UserDTO userDTO = new(userWizardtrack.Id, userWizardtrack.Name, userWizardtrack.Email);

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(authentication.GetClaimsIdentity(userDTO))
                    );
                return userDTO;
            }
            catch(Exception ex){ 
                return new UserDTO(0,ex.Message,"");
            }
        }

    }
}
