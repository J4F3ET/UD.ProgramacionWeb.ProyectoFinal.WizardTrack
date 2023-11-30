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
        public Task<Income> Post([FromBody] Income income)
        {
            return serviceIncome.Save(income);
        }
        [HttpPost("All")]
        public Task<IEnumerable<Income>> GetAll([FromBody] UserDTO user)
        {
            return serviceIncome.GetAll(user);
        }
        // GET api/<IncomeRestController>/5
        [HttpGet("{id}/{idUser}")]
        public Task<Income> Get(long id,long idUser)
        {
            return serviceIncome.FindById(id, idUser);
        }
        // PUT api/<IncomeRestController>/5
        [HttpPut]
        public Task<Income> Put([FromBody]Income  income)
        {
            return serviceIncome.Update(income);
        }

        // DELETE api/<IncomeRestController>/5
        [HttpDelete("{id}/{idUser}")]
        public Task<Income> Delete(long id,long idUser)
        {
            return serviceIncome.DeleteById(id, idUser);
        }
    }
}
