using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveCountRestController : ControllerBase
    {
        private static readonly ServiceSaveCount serviceSaveCount = new();
        // POST: api/<SaveCountRestController>
        [HttpPost("All")]
        public Task<IEnumerable<SaveCount>> GetAll([FromBody] UserDTO user)
        {
            return serviceSaveCount.GetAll(user);
        }
        [HttpPost]
        public Task<SaveCount> Post(SaveCount saveCount)
        {
            return serviceSaveCount.Save(saveCount);
        }

        // GET api/<SaveCountRestController>/5
        [HttpGet("{id}/{idUser}")]
        public Task<SaveCount> Get(long id,long idUser)
        {
            return serviceSaveCount.FindById(id, idUser);
        }
        // PUT api/<SaveCountRestController>/5
        [HttpPut]
        public Task<SaveCount> Put([FromBody] SaveCount saveCount)
        {
            return serviceSaveCount.Update(saveCount);
        }

        // DELETE api/<SaveCountRestController>/5
        [HttpDelete("{id}/{idUser}")]
        public Task<SaveCount> Delete(long id,long idUser)
        {
            return serviceSaveCount.DeleteById(id, idUser);
        }
    }
}
