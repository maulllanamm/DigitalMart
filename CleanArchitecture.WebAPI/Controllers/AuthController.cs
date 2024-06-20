using CleanArchitecture.Application.Common.Exceptions;
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

        public AuthController(IMediator mediator, IAccessTokenHelper accessTokenHelper)
        {
            _mediator = mediator;
            _accessTokenHelper = accessTokenHelper;
        }


        [HttpPost]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request,
           CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var result = await _mediator.Send(request, cancellationToken);

                // Jika berhasil, kirim respon yang sesuai
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                // Jika terjadi kesalahan validasi, kirim pesan kesalahan ke klien
                return BadRequest(new { errors = ex.Errors });
            }
            catch (NotFoundException ex)
            {
                // Jika tidak ada
                return NotFound(new { errors = ex.Message });
            }
            catch (Exception ex)
            {
                // Kembalikan respons 500 public Server Error ke klien
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginRequest request,
           CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var isLogin = await _mediator.Send(request, cancellationToken);

                // Buat akses token untuk user
                var accessToken = _accessTokenHelper.GenerateAccessToken(request.Username);
                // Jika berhasil, kirim respon yang sesuai
                return Ok(accessToken);
            }
            catch (BadRequestException ex)
            {
                // Jika terjadi kesalahan validasi, kirim pesan kesalahan ke klien
                return BadRequest(new { errors = ex.Errors });
            }
            catch (NotFoundException ex)
            {
                // Jika tidak ada
                return NotFound(new { errors = ex.Message });
            }
            catch (Exception ex)
            {
                // Kembalikan respons 500 public Server Error ke klien
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

    }
}