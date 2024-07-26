using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthResult> Register(string firstName, string lastName, string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
            return Errors.Users.DuplicateEmail;

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.AddUser(user);
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}