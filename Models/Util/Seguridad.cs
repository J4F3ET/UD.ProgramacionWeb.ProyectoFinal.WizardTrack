using System.Security.Cryptography;
using System.Text;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Exceptions;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models
{
    public class Seguridad
    {

        public (string hash, byte[]  salt) HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20); // Tamaño del hash

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return (Convert.ToBase64String(hashBytes), salt);
        }

        public bool VerifyPassword(string storedHash, byte[] storedSalt, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }
            return true;
        }

    }
}
