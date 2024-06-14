using AutoMapper;
using CleanArchitecture.Application.Features.PasswordHelperFeatures;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Command.Create
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly string _papper = "v81IKJ3ZBFgwc2AdnYeOLhUn9muUtIQ0AJKgfewu*!(24uyjfebweuy";
        private readonly int _iteration = 5;

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IPasswordHelper passwordHelper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var passwordSalt = _passwordHelper.GenerateSalt();
            var passwordHash = _passwordHelper.ComputeHash(request.Password, passwordSalt, _papper, _iteration);

            var user = _mapper.Map<User>(request);
            user.password_salt = passwordSalt;
            user.password_hash = passwordHash;

            var res = await _userRepository.Create(user);
            return _mapper.Map<CreateUserResponse>(res);
        }
    }
}
