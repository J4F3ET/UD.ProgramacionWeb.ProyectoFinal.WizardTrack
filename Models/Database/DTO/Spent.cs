using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.DTO;

public partial class Spent
{
    public long Id { get; set; }

    public long IdUser { get; set; }

    public decimal Amount { get; set; }

    public long Count { get; set; }

    public DateTime SpentDate { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public virtual UserWizardtrack IdUserNavigation { get; set; } = null!;
}
