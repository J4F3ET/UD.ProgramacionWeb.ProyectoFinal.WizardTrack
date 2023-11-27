using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtRestController : ControllerBase
    {
        private static readonly ServiceDebt serviceDebt = new();
        [HttpPost("All")]
        public Task<IEnumerable<Debt>> GetAll([FromBody]UserDTO user)
        {
            return serviceDebt.GetAll(user);
        }
        [HttpPost]
        public Task<Debt>Post([FromBody] Debt debt)
        {
            return serviceDebt.Save(debt);
        }
        // GET api/<DebtRestController>/5
        [HttpGet("{id}")]
        public Task<Debt> Get(long id)
        {
            return serviceDebt.FindById(id);
        }
        // PUT api/<DebtRestController>/5
        [HttpPut]
        public Task<Debt> Put([FromBody] Debt debt)
        {
           return serviceDebt.Update(debt);
        }

        // DELETE api/<DebtRestController>/5
        [HttpDelete("{id}")]
        public Task<Debt> Delete(long id)
        {
            return serviceDebt.DeleteById(id);
        }
    }
}
