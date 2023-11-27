using Microsoft.AspNetCore.Mvc;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeRestController : ControllerBase
    {
        private static readonly ServiceIncome serviceIncome = new();
        // POST: api/<IncomeRestController>
        [HttpPost]
        public IEnumerable<Income> Get([FromBody] UserDTO user)
        {
            return serviceIncome.GetAll(user).GetAwaiter().GetResult();
        }

        // GET api/<IncomeRestController>/5
        [HttpGet("{id}")]
        public Income Get(long id)
        {
            return serviceIncome.FindById(id).GetAwaiter().GetResult();
        }
        // PUT api/<IncomeRestController>/5
        [HttpPut]
        public Income Put([FromBody]Income  income)
        {
            return serviceIncome.Update(income).GetAwaiter().GetResult();
        }

        // DELETE api/<IncomeRestController>/5
        [HttpDelete("{id}")]
        public Income Delete(long id)
        {
            return serviceIncome.DeleteById(id).GetAwaiter().GetResult();
        }
    }
}
