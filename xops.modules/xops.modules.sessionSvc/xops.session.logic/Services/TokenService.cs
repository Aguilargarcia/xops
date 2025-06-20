using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using xops.session.core.Interfaces;
using xops.user.core.Entities;

namespace xops.session.logic.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;

    public TokenService()
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secreto, cambiar esto por otro strin"));
    }

    private IList<Claim> GetClaims(User user, IList<string> roles)
    {
        var claims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
             };

        if (!roles.IsNullOrEmpty())
        {
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
        }
        return claims;
    }


    public string CreateToken(User user, IList<string> roles)
    {
        var credentials = new SigningCredentials(_key, SecurityAlgorithms.Sha256);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(GetClaims(user, roles)),
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddDays(3),
            Issuer = "yo",
            SigningCredentials = credentials
        });

        return tokenHandler.WriteToken(token);
    }
}
