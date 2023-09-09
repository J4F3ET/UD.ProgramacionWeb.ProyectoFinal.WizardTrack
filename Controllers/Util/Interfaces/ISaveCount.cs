using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces
{
    public interface ISaveCount
    {
        Task<SaveCount> Save(SaveCount saveCount);
        Task<SaveCount> Update(SaveCount saveCount);
        Task<SaveCount> DeleteById(UserDTO user,long id);
        Task<SaveCount> FindById(UserDTO user,long id);
        Task<IEnumerable<SaveCount>> GetAll(UserDTO user);
    }
}
