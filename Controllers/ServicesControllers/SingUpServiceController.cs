using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingUpServiceController : ControllerBase
    {
        ServiceUsuario serviceUsuario = new();
        Seguridad seguridad = new();
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<UserDTO>? Post([FromBody] SignUpServiceDTO value)
        {
            try {
                if (value == null) return null;
                UserWizardtrack? userWizardtrack = await serviceUsuario.SelectUser(value.name, value.email);
                if(userWizardtrack != null) return new UserDTO(0,"Usuario ya existe",value.name+" "+value.email);
                await serviceUsuario.SaveUser(value);
                userWizardtrack = await serviceUsuario.SelectUser(value.name, value.email);
                if(userWizardtrack == null) return new UserDTO(0, "Error al ejecutar la peticion", "");
                var token = seguridad.GeneratorToken(userWizardtrack);
                Response.Cookies.Append("CookieToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true, // Ajusta según tu configuración de HTTPS
                    Expires = DateTime.Now.AddMinutes(60)
                });
                return new UserDTO(userWizardtrack.Id, userWizardtrack.Name, userWizardtrack.Email);
            }
            catch (Exception ex) {
                return new UserDTO(0,"Error al ejecutar la peticion",ex.Message);
            }
        }
    }
}
