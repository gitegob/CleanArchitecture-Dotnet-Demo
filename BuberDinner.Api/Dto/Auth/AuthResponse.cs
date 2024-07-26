using BuberDinner.Domain.Entities;

namespace BuberDinner.Api.Contracts.Auth;

public record AuthResponse(User User, string Token);