using CleanArchitecture.Application.Features.UserFeatures.Command.DeleteUser;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetById;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetByUsername;
using CleanArchitecture.Application.Helper.Interface;
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
        private readonly ICacheHelper _cacheHelper;

        public UserController(IMediator mediator, ICacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetAllUserResponse>> GetAll(CancellationToken cancellationToken)
        {
            var cacheData = _cacheHelper.GetData<IEnumerable<GetAllUserResponse>>("users");
            if (cacheData != null && cacheData.Count() > 0)
            {
                return Ok(cacheData);
            }
            var result = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            var expireTime = DateTime.Now.AddMinutes(1);
            _cacheHelper.SetData<IEnumerable<GetAllUserResponse>>("users", result, expireTime);
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