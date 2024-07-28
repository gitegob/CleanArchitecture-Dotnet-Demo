using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}