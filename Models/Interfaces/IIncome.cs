using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface IIncome
    {
        Task <Income> Save(Income income);
        Task <Income> Update(Income income);
        Task <Income> DeleteById(long id, long userId);
        Task <Income> FindById(long id, long userId);
        Task <IEnumerable<Income>> GetAll(UserDTO user);
    }
}
