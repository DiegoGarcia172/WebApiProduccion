using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApiProduccion.Models;

namespace WebApiProduccion.Custom
{
    public class Utilidades
    {
        private readonly IConfiguration _configuration;
        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string encriptar(string texto)
        {
            using (SHA256 sha356HASH = SHA256.Create())
            {
                byte[] bytes = sha356HASH.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string generarJWT(Usuario modelo)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.ID.ToString()),
                new Claim(ClaimTypes.Email, modelo.email!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);

        }
    }
}
