using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface IDebt
    {
        Task <Debt>? Save(Debt debt);
        Task <Debt>? Update(Debt debt);
        Task <Debt>? DeleteById(Debt debt);
        Task <Debt>? FindById(UserDTO user,long id);
        Task <IEnumerable<Debt>>? GetAll(UserDTO user);
    }
}
