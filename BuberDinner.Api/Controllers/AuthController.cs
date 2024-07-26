using BuberDinner.Api.Contracts.Auth;
using BuberDinner.Api.Dto.Auth;
using BuberDinner.Application.Authentication.Commands;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
[Tags("Auth")]
public class AuthController(
    IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerCommand = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var registerResult = await mediator.Send(registerCommand);
        return registerResult.MatchFirst(
            result => Ok(new AuthResponse(result.User, result.Token)),
            firstError => Problem(title: firstError.Code, detail: firstError.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginCommand = new LoginCommand(request.Email, request.Password);
        var loginResult = await mediator.Send(loginCommand);
        return loginResult.MatchFirst(
            result => Ok(new AuthResponse(result.User, result.Token)),
            firstError => Problem(title: firstError.Code, detail: firstError.Description));
    }
}