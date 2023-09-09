using System.Security.Cryptography;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Exceptions;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;
using UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models
{
    public class Seguridad
    {
        private const string privateKey = "[}Z>VTAbs+5mXE3gk@^m";
        private const string publicKey = "-NY/^9U/^G3([s77}pM}sC";
        public byte[] GetSecretKey() => Encoding.UTF8.GetBytes(privateKey + publicKey);
        public string GetPrivateKey() => privateKey;

        public string GeneratorToken(UserDTO user) {
            var token = JwtBuilder.Create().WithAlgorithm(new HMACSHA256Algorithm())
                        .WithSecret(GetSecretKey())
                        .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                        .AddClaim("id", user.Id)
                        .AddClaim("name", user.Name)
                        .AddClaim("email", user.Email)
                        .Encode();
            return token;
        }

        public UserDTO? VerifyToken(string token){
            var json = JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(GetSecretKey())
                    .MustVerifySignature()
                    .Decode<IDictionary<string, object>>(token);
            try
            {
                if (json == null) throw new ExceptionEmpyObject("token null");
                DateTimeOffset expClaimDateTime = DateTimeOffset.FromUnixTimeSeconds((long)json["exp"]);
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"); // Colombia Standard Time
                DateTime horaColombia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                if (expClaimDateTime < horaColombia) return null;

            }
            catch (ExceptionEmpyObject ex) {
                throw ex;
            }
            catch(Exception ex) {
                throw new Exception ("Fallo la verificacion del token, token no valido"+ex.Message,ex);
            }
            return new UserDTO((long)json["id"],(string)json["email"],(string)json["name"]);
        }

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
