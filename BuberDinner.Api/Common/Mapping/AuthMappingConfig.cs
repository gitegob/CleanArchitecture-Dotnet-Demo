using BuberDinner.Api.Contracts.Auth;
using BuberDinner.Api.Dto.Auth;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Dto;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery >();
        config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest, src => src.User);
    }
}