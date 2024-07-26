using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands;

public record LoginCommand(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

public class LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginCommand, ErrorOr<AuthResult>>
{
    public async Task<ErrorOr<AuthResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserByEmail(command.Email);
        if (userRepository.GetUserByEmail(command.Email) is null) return Errors.Authentication.InvalidCredentials;
        // Check password
        if (user!.Password != command.Password) return Errors.Authentication.InvalidCredentials;
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}