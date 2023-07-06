using foodbackend.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace foodbackend.Authentication
{
    public interface IAuthenticationManager
    {
        IDictionary<string, string> Authenticate(string customerName, string password);
    }
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly string tokenKey;
        public AuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public IDictionary<string, string> Authenticate(string CustName, string password)
        {
            foodyContext db = new foodyContext();
            Logindtl user = db.Logindtls.Where(log => log.CustName == CustName && log.CustPassword == password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, CustName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Dictionary<string, string>
            {
                { "Custid",user.Custid },
                { "CustName", user.CustName },
                { "CustPhone", user.CustPhone.ToString()},
                { "CustAddress", user.CustAddress },
                { "CustPassword", user.CustPassword },
                { "token",tokenHandler.WriteToken(token) }
            };
        }
    }
}
