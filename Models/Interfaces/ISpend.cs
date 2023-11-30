using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface ISpend
    {
        Task<Spent> Save(Spent spent);
        Task<Spent> Update(Spent spent);
        Task<Spent> DeleteById(long id,long userId);
        Task<Spent> FindById(long id, long userId);
        Task<IEnumerable<Spent>> GetAll(UserDTO user);
    }
}
