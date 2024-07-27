using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<AuthResult>>;
    
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