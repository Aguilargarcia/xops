using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using xops.user.core.Entities;
using xops.user.core.Interfaces;

namespace xops.user.businesslayer.Services;

public class TokenService: ITokenService
{

    private readonly SymmetricSecurityKey _key;
    private readonly IConfiguration _configuration;

    public TokenService( IConfiguration configuration)
    {
        _configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["token:key"]));
    }

    private List<Claim> GetClaims(User user, IList<string> roles) {
        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name,user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        if (roles != null && roles.Count > 0)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

        }

        return claims;
    }

    public string CreateToken(User user, IList<string> roles)
    {
        List<Claim> claims = this.GetClaims(user, roles);

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials,
            Issuer = "yo",
            Expires = DateTime.Now.AddDays(2)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        return tokenHandler.WriteToken(token);




    }

}
