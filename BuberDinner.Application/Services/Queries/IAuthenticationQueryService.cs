using BuberDinner.Application.Dto;
using ErrorOr;

namespace BuberDinner.Application.Services.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthResult> Login(string email, string password);
}