using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Dto;

public record AuthResult(
    User User,
    string Token
);