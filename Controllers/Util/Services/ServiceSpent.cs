using Microsoft.EntityFrameworkCore;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services
{
    public class ServiceSpent : ISpend
    {
        public async Task<Spent> DeleteById(long id, long userId)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var SaveCount = await context.Spents.FindAsync(id, userId) ?? throw new Exception();
                    context.Spents.Remove(SaveCount);
                    context.SaveChanges();
                    return SaveCount;

                }
            }
            catch (Exception) { return null; }
        }

        public async Task<Spent> FindById(long id, long userId)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Spents.FindAsync(id,userId);
                }
            }
            catch (Exception) { return null; }
        }

        public async Task<IEnumerable<Spent>> GetAll(UserDTO user)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Spents.Where(x => x.IdUser == user.Id).ToListAsync();
                }
            }
            catch (Exception) { return null; }
        }

        public async Task<Spent> Save(Spent spent)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    await context.Spents.AddAsync(spent);
                }
            }
            catch (Exception) { return null; }
            return spent;
        }

        public async Task<Spent> Update(Spent spent)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var spentData = await context.Spents.FindAsync(spent.Id) ?? throw new Exception();
                    spentData.Amount = spent.Amount;
                    spentData.Name = spent.Name;
                    spentData.SpentDate = spent.SpentDate;
                    spentData.Description = spent.Description;
                    await context.SaveChangesAsync();
                    return spentData;
                }
            }
            catch (Exception) { return null; }
        }
    }
}
