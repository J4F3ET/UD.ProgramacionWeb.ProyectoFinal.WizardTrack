using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;

public partial class Debt
{
    public Debt(){}
    public Debt(long idUser, decimal amount, DateTime starDate, DateTime endDate, decimal interest, string? description, string name, byte installments)
    {
        IdUser = idUser;
        Amount = amount;
        StarDate = starDate;
        EndDate = endDate;
        Interest = interest;
        Description = description;
        Name = name;
        Installments = installments;
    }
    public long Id { get; set; }

    public long IdUser { get; set; }

    public decimal Amount { get; set; }

    public DateTime StarDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Interest { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public byte Installments { get; set; }

    public virtual UserWizardtrack IdUserNavigation { get; set; } = null!;
}
