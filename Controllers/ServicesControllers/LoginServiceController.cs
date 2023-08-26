using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginServiceController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public LoginServiceDTO Post([FromBody] LoginServiceDTO value)
        {
            return value;
        }

    }
}
