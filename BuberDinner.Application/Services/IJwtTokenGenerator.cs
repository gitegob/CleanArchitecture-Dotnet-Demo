using BuberDinner.Domain.Users.Entities;

namespace BuberDinner.Application.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}