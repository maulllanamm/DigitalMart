using CleanArchitecture.Application.Common.Behaviors;
using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Application.Features.AuthFeatures.RegisterFeatures;
using CleanArchitecture.Application.Features.UserFeatures.Command.Create;
using CleanArchitecture.Application.Features.UserFeatures.Command.DeleteUser;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
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

                // Jika berhasil, kirim respon yang sesuai
                return Ok(isLogin);
            }
            catch (BadRequestException ex)
            {
                // Jika terjadi kesalahan validasi, kirim pesan kesalahan ke klien
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                // Kembalikan respons 500 public Server Error ke klien
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

    }
}