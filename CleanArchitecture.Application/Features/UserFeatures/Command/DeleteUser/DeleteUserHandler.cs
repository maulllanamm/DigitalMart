using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Command.DeleteUser
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.id);
            if (user == null)
            {
                return false;
            }

            return await _userRepository.Delete(request.id);
        }
    }
}
