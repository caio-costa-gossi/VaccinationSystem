using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Auth.RegisterUser
{
    public class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
