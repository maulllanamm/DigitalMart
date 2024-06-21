using CleanArchitecture.Application.Features.UserFeatures.Command.DeleteUser;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetById;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetAllUserResponse>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetByIdUserResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdUserRequest(id), cancellationToken);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetByIdUserResponse>> GetByUsername(string username, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetByUsernameRequest(username), cancellationToken);
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<UpdateUserResponse>> Update(UpdateUserRequest request,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<DeleteUserRequest>> Delete(int id,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteUserRequest(id), cancellationToken);
            return Ok(result);
        }
    }
}