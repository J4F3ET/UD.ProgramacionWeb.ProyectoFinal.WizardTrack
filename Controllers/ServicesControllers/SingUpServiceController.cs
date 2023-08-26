using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingUpServiceController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        public SignUpServiceDTO Post([FromBody] SignUpServiceDTO value)
        {
            return value;
        }
    }
}
