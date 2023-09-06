using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.DTO;

public partial class Income
{
    public long Id { get; set; }

    public long IdUser { get; set; }

    public decimal Amount { get; set; }

    public byte Frecuency { get; set; }

    public DateTime IncomeDate { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public virtual UserWizardtrack IdUserNavigation { get; set; } = null!;
}
