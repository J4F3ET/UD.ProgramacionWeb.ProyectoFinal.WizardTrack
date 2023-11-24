using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.RestControllers
{
    [Route("Account/[controller]")]
    [ApiController]
    public class SesionRestController : ControllerBase
    {
        // POST Account/<SesionRestController>/singup
        [HttpPost("singup")]
        public async Task<UserDTO> Post([FromBody] SignUpServiceDTO value)
        {
            ServiceUsuario serviceUsuario = new();
            Seguridad seguridad = new();
            if (value == null) return null;
            Authentication authentication = new();
            try
            {
                UserWizardtrack userWizardtrack = await serviceUsuario.FindByEmail(value.email);
                if (userWizardtrack != null)
                    throw new Exception("Usuario ya registrado");

                await serviceUsuario.Save(value);
                userWizardtrack = await serviceUsuario.FindByEmail(value.email);

                if (userWizardtrack == null)
                    throw new ArgumentNullException("Error al encontrar usuario guardado");

                // Creando sesion de usuario
                UserDTO userDTO = new(userWizardtrack.Id, userWizardtrack.Name, userWizardtrack.Email);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(
                        authentication.GetClaimIdentity(userDTO)
                    )
                );
                return userDTO;
            }
            catch (Exception ex)
            {
                return new UserDTO(0, "Error al ejecutar la peticion", ex.Message);
            }
        }
        // POST Account/<SesionServiceController>/login
        [HttpPost("login")]
        public async Task<UserDTO> Post([FromBody] LoginServiceDTO value)
        {
            Authentication authentication = new();
            Seguridad seguridad = new();
            ServiceUsuario service = new();
            try
            {
                if (value == null)
                    throw new ArgumentNullException("Value es null");

                UserWizardtrack userWizardtrack = await service.FindByEmail(value.email)
                    ?? throw new ArgumentNullException("Usuario no existe");

                if (!seguridad.VerifyPassword(userWizardtrack.Password, userWizardtrack.Salt, value.password))
                    throw new Exception("Contraseña incorrecta");

                UserDTO userDTO = new(userWizardtrack.Id, userWizardtrack.Name, userWizardtrack.Email);

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(authentication.GetClaimIdentity(userDTO))
                    );
                return userDTO;
            }
            catch (Exception ex)
            {
                return new UserDTO(0, ex.Message, "");
            }
        }
        // POST Account/<SesionRestontroller>/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Post()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Index");
        }
    }
}