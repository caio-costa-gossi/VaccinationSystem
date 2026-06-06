using MediatR;

namespace VaccinationSystem.Application.Auth.LogIn
{
    public record LoginCommand(string Name, string Password) : IRequest<LoginResponseDto>;
}
