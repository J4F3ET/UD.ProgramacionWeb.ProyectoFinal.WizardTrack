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
        [HttpPost]
        public IEnumerable<SaveCount> Post([FromBody] UserDTO user)
        {
            return serviceSaveCount.GetAll(user).GetAwaiter().GetResult();
        }

        // GET api/<SaveCountRestController>/5
        [HttpGet("{id}")]
        public SaveCount Get(long id)
        {
            return serviceSaveCount.FindById(id).GetAwaiter().GetResult();
        }
        // PUT api/<SaveCountRestController>/5
        [HttpPut]
        public SaveCount Put([FromBody] SaveCount saveCount)
        {
            return serviceSaveCount.Update(saveCount).GetAwaiter().GetResult();
        }

        // DELETE api/<SaveCountRestController>/5
        [HttpDelete("{id}")]
        public SaveCount Delete(long id)
        {
            return serviceSaveCount.DeleteById(id).GetAwaiter().GetResult();
        }
    }
}
