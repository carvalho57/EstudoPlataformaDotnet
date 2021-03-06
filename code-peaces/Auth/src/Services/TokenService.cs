using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ApiAuth.Models;

namespace ApiAuth.Services
{
    public class TokenService
    {
        private readonly string _secret;
        private readonly string _expDate;

        public TokenService()
        {
            _secret = AuthSettings.Secret;
            _expDate = AuthSettings.ExpireDate;
        }

        public string GenerateToken(UserModel user)
        {
            
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescription = new SecurityTokenDescriptor() {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}

