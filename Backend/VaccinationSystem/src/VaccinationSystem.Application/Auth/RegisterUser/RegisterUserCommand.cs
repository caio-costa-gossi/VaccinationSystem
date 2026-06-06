using MediatR;

namespace VaccinationSystem.Application.Auth.RegisterUser
{
    public record RegisterUserCommand(string Name, string Password) : IRequest;
}
