using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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
    public class SingUpServiceController : ControllerBase
    {
        ServiceUsuario serviceUsuario = new();
        Seguridad seguridad = new();
        // POST Account/SingUpService
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] SignUpServiceDTO value)
        {
            if (value == null) return null;
            Authentication authentication = new();
            try {
                UserWizardtrack userWizardtrack = await serviceUsuario.SelectUser(value.name, value.email);

                if(userWizardtrack != null)
                    throw new Exception("Usuario ya registrado");

                await serviceUsuario.SaveUser(value);
                userWizardtrack = await serviceUsuario.SelectUser(value.name, value.email);

                if(userWizardtrack == null)
                    throw new ArgumentNullException("Error al encontrar usuario guardado");

                // Creando sesion de usuario
                UserDTO userDTO = new(userWizardtrack.Id, userWizardtrack.Name, userWizardtrack.Email);
                var token = seguridad.GeneratorToken(userDTO);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(
                        authentication.GetClaimsIdentity(userDTO,token)
                    )
                );
                return userDTO;
            }
            catch (Exception ex) {
                return new UserDTO(0,"Error al ejecutar la peticion",ex.Message);
            }
        }
    }
}
