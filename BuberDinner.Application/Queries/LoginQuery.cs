using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Application.Services;
using ErrorOr;
using MediatR;
using Errors = BuberDinner.Domain.Errors.Errors;

namespace BuberDinner.Application.Authentication.Commands;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var user = userRepository.GetUserByEmail(query.Email);
        if (userRepository.GetUserByEmail(query.Email) is null) return Errors.Authentication.InvalidCredentials;
        // Check password
        if (user!.Password != query.Password) return Errors.Authentication.InvalidCredentials;
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}