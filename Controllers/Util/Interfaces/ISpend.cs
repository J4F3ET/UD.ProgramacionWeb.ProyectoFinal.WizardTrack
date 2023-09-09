using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface ISpend
    {
        Task<Spent> SaveSpent(Spent spent);
        Task<Spent> GetSpentById(UserDTO user,long id);
        Task<List<Spent>> GetSpents(UserDTO user);
        Task<Spent> UpdateSpent(Spent spent);
        Task<Spent> DeleteSpentById(UserDTO user,long id);
    }
}
