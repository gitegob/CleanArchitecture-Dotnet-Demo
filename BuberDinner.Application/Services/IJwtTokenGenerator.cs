using BuberDinner.Domain.Auth.Entities;

namespace BuberDinner.Application.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}