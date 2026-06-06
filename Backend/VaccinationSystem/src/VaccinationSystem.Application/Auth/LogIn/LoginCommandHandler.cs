using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Auth.LogIn
{
    public class LoginCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return new LoginResponseDto("AccessTokenHere");
        }
    }
}
