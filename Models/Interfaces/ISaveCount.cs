using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface ISaveCount
    {
        Task<SaveCount> Save(SaveCount saveCount);
        Task<SaveCount> Update(SaveCount saveCount);
        Task<SaveCount> DeleteById(long id);
        Task<SaveCount> FindById(long id);
        Task<IEnumerable<SaveCount>> GetAll(UserDTO user);
    }
}
