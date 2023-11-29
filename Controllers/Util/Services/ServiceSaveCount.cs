using Microsoft.EntityFrameworkCore;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services
{
    public class ServiceSaveCount : ISaveCount
    {
        public async Task<SaveCount> DeleteById(long id, long userId)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var SaveCount = await context.SaveCounts.FindAsync(id, userId) ?? throw new Exception();
                    context.SaveCounts.Remove(SaveCount);
                    context.SaveChanges();
                    return SaveCount;

                }
            }
            catch (Exception) { return null; }
        }

        public async Task<SaveCount> FindById(long id, long userId)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.SaveCounts.FindAsync(id, userId);
                }
            }
            catch (Exception) { return null; }
        }

        public async Task<IEnumerable<SaveCount>> GetAll(UserDTO user)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.SaveCounts.Where(x => x.IdUser == user.Id).ToListAsync();
                }
            }
            catch (Exception) { return null; }
        }

        public async Task<SaveCount> Save(SaveCount saveCount)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    await context.SaveCounts.AddAsync(saveCount);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception) { return null; }
            return saveCount;
        }

        public async Task<SaveCount> Update(SaveCount saveCount)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var saveCountData = await context.SaveCounts.FindAsync(saveCount.Id,saveCount.IdUser) ?? throw new Exception();
                    saveCountData.Amount = saveCount.Amount;
                    saveCountData.Name = saveCount.Name;
                    saveCountData.StarDate = saveCount.StarDate;
                    saveCountData.EndDate = saveCount.EndDate;
                    saveCountData.Description = saveCount.Description;
                    await context.SaveChangesAsync();
                    return saveCountData;
                }
            }
            catch (Exception) { return null; }
        }
    }
}
