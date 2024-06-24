using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.VerifyFeatures
{
    public sealed class VerifyHandler : IRequestHandler<VerifyRequest, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public VerifyHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(VerifyRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByVerifyToken(request.VerifyToken);
            if (user is null)
            {
                throw new NotFoundException("Invalid token");
            }
            user.verify_date = DateTime.UtcNow;
            await _userRepository.Update(user);
            return "User verified";
        }
    }
}
