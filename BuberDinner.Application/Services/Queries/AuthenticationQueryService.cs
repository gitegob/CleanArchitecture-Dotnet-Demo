using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Dto;
using BuberDinner.Application.Repositories;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthResult> Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (_userRepository.GetUserByEmail(email) is null) return Errors.Authentication.InvalidCredentials;
        // Check password
        if (user!.Password != password) return Errors.Authentication.InvalidCredentials;
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}