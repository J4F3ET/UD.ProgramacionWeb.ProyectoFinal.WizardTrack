using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;

public partial class Spent
{
    public Spent(){}
    public Spent(long idUser, decimal amount, long count, DateTime spentDate, string? description, string name)
    {
        IdUser = idUser;
        Amount = amount;
        Count = count;
        SpentDate = spentDate;
        Description = description;
        Name = name;
    }
    public long Id { get; set; }

    public long IdUser { get; set; }

    public decimal Amount { get; set; }

    public long Count { get; set; }

    public DateTime SpentDate { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public virtual UserWizardtrack IdUserNavigation { get; set; } = null!;
}
