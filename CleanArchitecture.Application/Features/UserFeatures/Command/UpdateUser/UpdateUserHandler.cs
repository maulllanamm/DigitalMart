using AutoMapper;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = _mapper.Map<User>(request);

                var user = await _userRepository.GetById(request.id);
                user.username = newUser.username;
                user.email = newUser.email;
                user.full_name = newUser.full_name;
                user.phone_number = newUser.phone_number;
                user.address = newUser.address;

                var res = await _userRepository.Update(user);

                return _mapper.Map<UpdateUserResponse>(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
