using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Application.Services;
using BuberDinner.Domain.Users.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Errors = BuberDinner.Domain.Common.Errors.Errors;

namespace BuberDinner.Application.Authentication.Commands;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<AuthResult>>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}

public class RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (userRepository.GetUserByEmail(request.Email) is not null)
            return Errors.Users.DuplicateEmail;

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
        userRepository.AddUser(user);
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}