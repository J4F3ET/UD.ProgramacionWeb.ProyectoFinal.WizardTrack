using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface IDebt
    {
        Task <Debt>? Save(Debt debt);
        Task <Debt>? Update(Debt debt);
        Task <Debt>? DeleteById(long id, long userId);
        Task <Debt>? FindById(long id, long userId);
        Task <IEnumerable<Debt>>? GetAll(UserDTO user);
    }
}
