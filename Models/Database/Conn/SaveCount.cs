using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;

public partial class SaveCount
{
    public SaveCount(){}
    public SaveCount(long idUser, decimal amount, DateTime starDate, DateTime endDate, string? description, string name)
    {
        IdUser = idUser;
        Amount = amount;
        StarDate = starDate;
        EndDate = endDate;
        Description = description;
        Name = name;
    }
    public long Id { get; set; }

    public long IdUser { get; set; }

    public decimal Amount { get; set; }

    public DateTime StarDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public virtual UserWizardtrack IdUserNavigation { get; set; } = null!;
}
