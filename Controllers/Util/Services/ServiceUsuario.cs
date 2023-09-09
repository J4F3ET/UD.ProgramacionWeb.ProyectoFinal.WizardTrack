using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Exceptions;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO.ServicesHTTP;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Services
{
    public class ServiceUsuario: IUser
    {
        private readonly Seguridad seguridad = new();

        public async Task<UserWizardtrack> SaveUser(SignUpServiceDTO user)
        {
            try
            {
                (string hash, byte[] salt) = seguridad.HashPassword(user.password);
                if (user != null)
                {
                    using WizardtrackContext context = new();
                    {
                        UserWizardtrack newUser = new(user.name, user.email, hash, salt);
                        context.UserWizardtracks.Add(newUser);
                        await context.SaveChangesAsync();
                        return newUser;
                    }
                }
                else throw new ExceptionEmpyObject("usuario vacio");

            }
            catch (ExceptionEmpyObject ex)
            {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception("Fallo al ejecutar la sentecia", ex);
            }
        }

        public Task<UserWizardtrack> UpdateUser(UserWizardtrack user)
        {
            throw new NotImplementedException();
        }

        public Task<UserWizardtrack> DeleteUser(UserWizardtrack? user, string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserWizardtrack>? SelectUser(string email)
        {
            try {
                UserWizardtrack user = null;
                using WizardtrackContext context = new();
                {
                    user = await context.UserWizardtracks.FirstOrDefaultAsync(u => u.Email == email);
                    return user;
                }
            }
            catch (Exception ex) {
                throw new Exception("Fallo la consulta",ex);
            }
        }
    }
}
