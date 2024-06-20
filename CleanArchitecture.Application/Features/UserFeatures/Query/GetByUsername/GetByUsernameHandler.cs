using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Query.GetByUsername
{
    public class GetByUsernameHandler : IRequestHandler<GetByUsernameRequest, GetByUsernameResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetByUsernameHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetByUsernameResponse> Handle(GetByUsernameRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsername(request.Username);
            if (user == null)
            {
                throw new NotFoundException($"User with username {request.Username} Not Found");
            }
            return _mapper.Map<GetByUsernameResponse>(user);
        }
    }
}
