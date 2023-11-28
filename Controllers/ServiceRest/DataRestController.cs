using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Map;
using System.Collections.ObjectModel;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services;
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
        private static readonly ServiceSaveCount serviceSaveCount = new();
        private static readonly ServiceUsuario serviceUsuario = new();
        // GET: api/<UserIndexController>
        [HttpPost]
        public async Task<Dictionary<string, List<object>>> Post([FromBody] UserDTO user)
        {
            List<Debt> debts = (await serviceDebt.GetAll(user)).ToList();
            List<Income> incomes = (await serviceIncome.GetAll(user)).ToList();
            List<Spent> spents = (await serviceSpent.GetAll(user)).ToList();
            List<SaveCount> saveCounts = (await serviceSaveCount.GetAll(user)).ToList();
            var result = new Dictionary<string, List<object>>
            {
                { "debts", debts.Cast<object>().ToList() },
                { "incomes", incomes.Cast<object>().ToList() },
                { "spents", spents.Cast<object>().ToList() },
                { "saveCounts", saveCounts.Cast<object>().ToList() }
            };
            return result;
        }
        [HttpPost("user")]
        public UserDTO Get([FromBody] long id) {
            return serviceUsuario.FindById(id);
        }
    }
}
