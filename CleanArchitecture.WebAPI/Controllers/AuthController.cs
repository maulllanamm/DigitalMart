using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Features.AuthFeatures.ForgotPasswordFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.RegisterFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.ResetPasswordFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.VerifyFeatures;
using CleanArchitecture.Application.Helper.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccessTokenHelper _accessTokenHelper;
        private readonly IRefreshTokenHelper _refreshTokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IMediator mediator, IAccessTokenHelper accessTokenHelper, IRefreshTokenHelper refreshTokenHelper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
        {
            _mediator = mediator;
            _accessTokenHelper = accessTokenHelper;
            _refreshTokenHelper = refreshTokenHelper;
            _httpContextAccessor = httpContextAccessor;
            _clientFactory = clientFactory;
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
            var accessToken = _accessTokenHelper.GenerateAccessToken(user.Username, user.Role.name);
            var refreshToken = _refreshTokenHelper.GenerateRefreshToken(user.Username, user.Role.name);
            _refreshTokenHelper.SetRefreshToken(refreshToken, user.Username);
            return Ok(accessToken);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Verify(string verifyToken ,CancellationToken cancellationToken)
        {
            var verify = await _mediator.Send(new VerifyRequest(verifyToken), cancellationToken);

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(verifyToken) as JwtSecurityToken;

            DateTime expires = securityToken.ValidTo;
            if (expires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }
            return Ok(verify);
        }

        [HttpPost]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            string[] errors;
            if (string.IsNullOrEmpty(refreshToken))
            {
                errors = new string[] { "Invalid token." };
                throw new BadRequestException(errors);
            }

            var principal = _accessTokenHelper.ValidateAccessToken(refreshToken);

            // Mendapatkan informasi user dari token
            var username = principal.FindFirstValue(ClaimTypes.Name);
            var roleName = principal.FindFirstValue(ClaimTypes.Role);
            _refreshTokenHelper.ValidateRefreshToken(username, refreshToken);

            var newAccessToken = _accessTokenHelper.GenerateAccessToken(username, roleName);
            var newRefreshToken = _refreshTokenHelper.GenerateRefreshToken(username, roleName);
            _refreshTokenHelper.SetRefreshToken(newRefreshToken, username);
            return Ok(newAccessToken);
        }

        [HttpPost]
        public async Task<ActionResult<string>> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            var forgotPassword = await _mediator.Send(new ForgotPasswordRequest(email), cancellationToken);
            return Ok(forgotPassword);
        }

        [HttpPost]
        public async Task<ActionResult<string>> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var resetPassword = await _mediator.Send(request, cancellationToken);
            return Ok(resetPassword);
        }
    }
}