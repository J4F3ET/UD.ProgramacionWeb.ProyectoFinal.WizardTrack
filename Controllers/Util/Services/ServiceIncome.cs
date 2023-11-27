using Microsoft.EntityFrameworkCore;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Interfaces;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Util.Services
{
    public class ServiceIncome : IIncome
    {
        public async Task<Income> DeleteById(long id)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var ExistIcome = await context.Incomes.FindAsync(id)??throw new Exception();
                    context.Incomes.Remove(ExistIcome);
                    context.SaveChanges();
                    return ExistIcome;

                }
            }catch (Exception ex) { return null; }
        }

        public async Task<Income> FindById(long id)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Incomes.FindAsync(id);
                }
            }
            catch (Exception ex) { return null; }
        }

        public async Task<IEnumerable<Income>> GetAll(UserDTO user)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    return await context.Incomes.Where(x => x.IdUser == user.Id).ToListAsync();
                }
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Income> Save(Income income)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    await context.Incomes.AddAsync(income);
                }
            }
            catch (Exception ex) { return null; }
            return income;
        }

        public async Task<Income> Update(Income income)
        {
            try
            {
                using WizardtrackContext context = new();
                {
                    var  incomeData= await context.Incomes.FindAsync(income.Id) ?? throw new Exception();
                    incomeData.Description = income.Description;
                    incomeData.IncomeDate = income.IncomeDate;
                    incomeData.Frecuency = income.Frecuency;
                    incomeData.Amount = income.Amount;
                    incomeData.Name = income.Name;
                    await context.SaveChangesAsync();
                    return incomeData;
                }
            }
            catch (Exception ex) { return null; }
        }
    }
}
