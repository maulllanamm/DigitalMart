using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.UserFeatures.Command.Create;
using CleanArchitecture.Application.Common.Behaviors;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;

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

        [HttpGet]
        public async Task<ActionResult<GetAllUserResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var result = await _mediator.Send(new GetAllUserRequest(), cancellationToken);

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
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request,
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

        [HttpPut]
        public async Task<ActionResult<UpdateUserResponse>> Update(UpdateUserRequest request,
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
    }
}