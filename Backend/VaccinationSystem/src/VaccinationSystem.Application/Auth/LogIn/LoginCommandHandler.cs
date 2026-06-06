using MediatR;
using Microsoft.AspNetCore.Identity;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Application.Auth.LogIn
{
    public class LoginCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator tokenGenerator,
        IPasswordHasher<User> passwordHasher) 
        : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByNameAsync(request.Name, cancellationToken);

            if (user == null)
                throw new UnauthorizedException("Nome de usuário ou senha estão incorretos.");

            PasswordVerificationResult result = 
                _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Nome de usuário ou senha estão incorretos.");

            return new LoginResponseDto(_tokenGenerator.GenerateToken(user));
        }
    }
}
