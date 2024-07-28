using BuberDinner.Domain.Auth.Entities;

namespace BuberDinner.Application.Dto;

public record AuthResult(
    User User,
    string Token
);