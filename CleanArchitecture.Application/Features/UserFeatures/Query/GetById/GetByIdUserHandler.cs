using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Query.GetById
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserRequest, GetByIdUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetByIdUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetById(request.id);
                if (user == null)
                {
                    throw new NotFoundException("User Not Found");
                }
                return _mapper.Map<GetByIdUserResponse>(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
