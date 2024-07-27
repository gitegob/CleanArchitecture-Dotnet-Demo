using BuberDinner.Api.Contracts.Auth;
using BuberDinner.Api.Dto.Auth;
using BuberDinner.Application.Authentication.Commands;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
[Tags("Auth")]
public class AuthController(
    ISender sender, IMapper mapper) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerResult = await sender.Send(mapper.Map<RegisterCommand>(request));
        return registerResult.MatchFirst(
            result => Ok(mapper.Map<AuthResponse>(result)),
            firstError => Problem(title: firstError.Code, detail: firstError.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request) 
    {
        var loginResult = await sender.Send(mapper.Map<LoginQuery>(request));
        return loginResult.MatchFirst(
            result => Ok(mapper.Map<AuthResponse>(result)),
            firstError => Problem(title: firstError.Code, detail: firstError.Description));
    }
}