using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpentRestController : ControllerBase
    {
        private static readonly ServiceSpent serviceSpent = new();
        // POST: api/<SpentRestController>
        [HttpPost]
        public IEnumerable<Spent> Post([FromBody] UserDTO user)
        {
            return serviceSpent.GetAll(user).GetAwaiter().GetResult();
        }

        // GET api/<SpentRestController>/5
        [HttpGet("{id}")]
        public Spent Get(long id)
        {
            return serviceSpent.FindById(id).GetAwaiter().GetResult();
        }
        // PUT api/<SpentRestController>/5
        [HttpPut]
        public Spent Put([FromBody] Spent spent)
        {
            return serviceSpent.Update(spent).GetAwaiter().GetResult();
        }

        // DELETE api/<SpentRestController>/5
        [HttpDelete("{id}")]
        public Spent Delete(int id)
        {
            return serviceSpent.DeleteById(id).GetAwaiter().GetResult();
        }
    }
}
