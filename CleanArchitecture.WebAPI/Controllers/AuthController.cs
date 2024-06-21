using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.RegisterFeatures;
using CleanArchitecture.Application.Helper.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccessTokenHelper _accessTokenHelper;
        private readonly IRefreshTokenHelper _refreshTokenHelper;

        public AuthController(IMediator mediator, IAccessTokenHelper accessTokenHelper, IRefreshTokenHelper refreshTokenHelper)
        {
            _mediator = mediator;
            _accessTokenHelper = accessTokenHelper;
            _refreshTokenHelper = refreshTokenHelper;
        }


        [HttpPost]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginRequest request,
           CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(request, cancellationToken);
            var accessToken = _accessTokenHelper.GenerateAccessToken(user.Username, user.Role);
            var refreshToken = _refreshTokenHelper.GenerateRefreshToken(user.Username);
            _refreshTokenHelper.SetRefreshToken(refreshToken, user.Username);
            return Ok(accessToken);
        }

    }
}