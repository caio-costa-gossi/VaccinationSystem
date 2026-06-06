using MediatR;
using Microsoft.AspNetCore.Identity;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Application.Auth.RegisterUser
{
    public class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher<User> passwordHasher) 
        : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.UserNameExistsAsync(request.Name, cancellationToken))
                throw new ConflictException("Nome de usuário já existe.");

            User newUser = new()
            {
                Id = default,
                Name = request.Name,
                Password = string.Empty
            };

            newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);

            await _userRepository.AddAsync(newUser, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
