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
        [HttpPost]
        public IEnumerable<Debt> Post([FromBody]UserDTO user)
        {
            return serviceDebt.GetAll(user).GetAwaiter().GetResult();
        }
        // GET api/<DebtRestController>/5
        [HttpGet("{id}")]
        public Debt Get(long id)
        {
            return serviceDebt.FindById(id).GetAwaiter().GetResult();
        }
        // PUT api/<DebtRestController>/5
        [HttpPut]
        public Debt Put([FromBody] Debt debt)
        {
           return serviceDebt.Update(debt).GetAwaiter().GetResult();
        }

        // DELETE api/<DebtRestController>/5
        [HttpDelete("{id}")]
        public Debt Delete(long id)
        {
            return serviceDebt.DeleteById(id).GetAwaiter().GetResult();
        }
    }
}
