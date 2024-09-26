using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RpgCalendar.Utilities;

public class UtillitiesTools
{
    public static string GenerateJwtToken(string content, DateTime? expiry = null)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Authentication ,content)
        };
        
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes( "rpgcalendar"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expiry ?? DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}