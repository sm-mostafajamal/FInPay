using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FinPay.Application.Common.Interfaces.Services;
using FinPay.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace FinPay.Infrastructure.Services.Authentication;

public class JwtTokenService(IOptions<JwtSetting> jwtSetting) : IJwtTokenService
{
    private readonly JwtSetting _jwtSetting = jwtSetting.Value;
    public string GenerateToken(User user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var clams = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.FirstName.ToString()),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtSetting.Issuer.ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, _jwtSetting.Audience.ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, _jwtSetting.Expire.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UnixEpoch.ToString()),
        };

        var jwtSecurityToken = new JwtSecurityToken(   
            issuer: _jwtSetting.Issuer, 
            audience: _jwtSetting.Audience, 
            claims: clams, 
            expires: DateAndTime.Now.AddMinutes(_jwtSetting.Expire),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}