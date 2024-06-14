using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.UserFeatures.Command.Create;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<CreateResponse>> Create(CreateRequest request,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}