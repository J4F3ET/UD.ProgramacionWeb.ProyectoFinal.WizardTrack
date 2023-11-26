using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataRestController : ControllerBase
    {
        // GET: api/<UserIndexController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserIndexController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserIndexController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserIndexController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserIndexController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
