using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataRestController : ControllerBase
    {
        private static readonly ServiceDebt serviceDebt = new();
        private static readonly ServiceIncome serviceIncome = new();
        private static readonly ServiceSpent serviceSpent = new();
        // GET: api/<UserIndexController>
        [HttpPost]
        public async Task<IEnumerable<List<object>>> Post([FromBody] UserDTO user)
        {
            List<Debt> debts = (await serviceDebt.GetAll(user)).ToList();
            List<Income> incomes = (await serviceIncome.GetAll(user)).ToList();
            List<Spent> spents = (await serviceSpent.GetAll(user)).ToList();
            var result = new List<List<object>> { debts.Cast<object>().ToList(), incomes.Cast<object>().ToList(), spents.Cast<object>().ToList() };
            return result;
        }
    }
}
