using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces
{
    public interface IUser
    {
        Task<UserWizardtrack> Save(SignUpServiceDTO user);
        Task<UserWizardtrack> Update(UserWizardtrack user);
        Task<UserWizardtrack> Delete(UserWizardtrack user);
        Task<UserWizardtrack>? FindByEmail(string email);
    }
}
