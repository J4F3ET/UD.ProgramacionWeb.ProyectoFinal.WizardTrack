using Microsoft.EntityFrameworkCore;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services
{
    public class ServiceDebt :IDebt
    {
        public async Task<Debt>?Save(Debt debt)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    await context.Debts.AddAsync(debt);
                }
            }
            catch (Exception){ 
  
                return null;
            }
            return debt;
        }

        public async Task<Debt>? Update(Debt debt)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var newDebt = await context.Debts.FindAsync(debt.Id) ?? throw new Exception();
                    newDebt.EndDate = debt.EndDate;
                    newDebt.Amount = debt.Amount;
                    newDebt.Interest = debt.Interest;
                    newDebt.Installments  = debt.Installments;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception) { return null; }
            return debt;
        }

        public async Task<Debt>? DeleteById(long id, long userId)
        {
            try
            { 
                using WizardtrackContext context = new();
                {
                    var existDebt = await context.Debts.FindAsync(id,userId) ?? throw new Exception();
                    context.Debts.Remove(existDebt);
                    context.SaveChanges();
                    return existDebt;
                }
            }catch (Exception) { return null; }
            
        }

        public async Task<Debt>? FindById(long id, long userId)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Debts.FindAsync(id, userId) ?? throw new Exception();
                }
            }
            catch (Exception) { return null; }
        }

        public async Task<IEnumerable<Debt>> GetAll(UserDTO user)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Debts.Where(x => x.IdUser == user.Id).ToListAsync();
                }
            }catch (Exception) { return null; }
        }
    }
}
