using System.Text;
using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Domain.Entities;
using BuberDinner.Infrastructure.Config;
using Microsoft.Extensions.Options;

namespace BuberDinner.Infrastructure.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var emailBytes = Encoding.UTF8.GetBytes(user.Email + _jwtSettings.Secret);
        return Convert.ToBase64String(emailBytes);
    }
}