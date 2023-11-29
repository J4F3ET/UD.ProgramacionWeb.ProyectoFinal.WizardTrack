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
        [HttpPost("All")]
        public Task<IEnumerable<Spent>> GetAll([FromBody] UserDTO user)
        {
            return serviceSpent.GetAll(user);
        }
        [HttpPost]
        public Task<Spent> Post([FromBody] Spent spent)
        {
            return serviceSpent.Save(spent);
        }

        // GET api/<SpentRestController>/5
        [HttpGet("{id}/{idUser}")]
        public Task<Spent> Get(long id,long idUser)
        {
            return serviceSpent.FindById(id, idUser);
        }
        // PUT api/<SpentRestController>/5
        [HttpPut]
        public Task<Spent> Put([FromBody] Spent spent)
        {
            return serviceSpent.Update(spent);
        }

        // DELETE api/<SpentRestController>/5
        [HttpDelete("{id}/{idUser}")]
        public Task<Spent> Delete(long id, long idUser)
        {
            return serviceSpent.DeleteById(id,idUser);
        }
    }
}
