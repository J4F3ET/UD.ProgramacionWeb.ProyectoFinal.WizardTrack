using System;
using System.Collections.Generic;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;

public partial class UserWizardtrack
{
    public UserWizardtrack(){}
    public UserWizardtrack(string name,string email,string password, byte[]? salt)
    {
        Name = name;
        Email = email;
        Password = password;
        Salt = salt;
    }
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? Salt { get; set; }

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();

    public virtual ICollection<SaveCount> SaveCounts { get; set; } = new List<SaveCount>();

    public virtual ICollection<Spent> Spents { get; set; } = new List<Spent>();
}
