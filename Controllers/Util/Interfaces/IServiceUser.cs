using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces
{
    public interface IServiceUser
    {
        Task<UserWizardtrack> SaveUser(SignUpServiceDTO user);
        Task<UserWizardtrack> UpdateUser(UserWizardtrack user);
        Task<UserWizardtrack> DeleteUser(UserWizardtrack? user, string id);
        Task<UserWizardtrack>? SelectUser(string? name, string email);
    }
}
