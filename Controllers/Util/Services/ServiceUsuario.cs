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

        public async Task<UserWizardtrack> Save(SignUpServiceDTO user)
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

        public  Task<UserWizardtrack> Update(UserWizardtrack user)
        {
            try
            {
                if (user != null)
                {
                    using WizardtrackContext context = new();
                    {
                        context.UserWizardtracks.Update(user);
                        context.SaveChanges();
                        return Task.FromResult(user);
                    }
                }
                else throw new ExceptionEmpyObject("usuario vacio");
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al ejecutar la sentecia", ex);
            }
        }

        public  Task<UserWizardtrack> Delete(UserWizardtrack user)
        {
            try
            {
                if (user != null)
                {
                    using WizardtrackContext context = new();
                    {
                        context.UserWizardtracks.Remove(user);
                        context.SaveChanges();
                        return Task.FromResult(user);
                    }
                }
                else throw new ExceptionEmpyObject("usuario vacio");
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al ejecutar la sentecia", ex);
            }
        }

        public async Task<UserWizardtrack> FindByEmail(string email)
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
