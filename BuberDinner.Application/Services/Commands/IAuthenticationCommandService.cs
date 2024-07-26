using BuberDinner.Application.Dto;
using ErrorOr;

namespace BuberDinner.Application.Services.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthResult> Register(string firstName, string lastName, string email, string password);
}