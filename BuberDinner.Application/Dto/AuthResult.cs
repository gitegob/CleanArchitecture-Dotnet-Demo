using BuberDinner.Domain.Users.Entities;

namespace BuberDinner.Application.Dto;

public record AuthResult(
    User User,
    string Token
);