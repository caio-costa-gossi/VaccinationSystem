using MediatR;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Application.Auth.LogIn
{
    public class LoginCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator tokenGenerator) 
        : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return new LoginResponseDto(
                _tokenGenerator.GenerateToken(
                    new User { Id = Guid.NewGuid(), Name = "João", Password = "123" }));
        }
    }
}
