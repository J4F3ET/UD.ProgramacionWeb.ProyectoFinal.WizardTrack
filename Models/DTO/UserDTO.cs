namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO
{
    public class UserDTO
    {
        public UserDTO(long id,string name,string email) { 
            Id = id;
            Name = name;
            Email = email;
        }
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
