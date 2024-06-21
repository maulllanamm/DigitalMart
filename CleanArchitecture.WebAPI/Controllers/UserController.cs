using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Features.UserFeatures.Command.DeleteUser;
using CleanArchitecture.Application.Features.UserFeatures.Command.UpdateUser;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetAll;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetById;
using CleanArchitecture.Application.Features.UserFeatures.Query.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;

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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetByIdUserResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var result = await _mediator.Send(new GetByIdUserRequest(id), cancellationToken);

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
                // Jika id tidak ada
                return NotFound(new { errors = ex.Message });
            }
            catch (Exception ex)
            {
                // Kembalikan respons 500 public Server Error ke klien
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetByIdUserResponse>> GetByUsername(string username, CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var result = await _mediator.Send(new GetByUsernameRequest(username), cancellationToken);

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
                // Jika id tidak ada
                return NotFound(new { errors = ex.Message });
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

        [HttpDelete("id")]
        public async Task<ActionResult<DeleteUserRequest>> Delete(int id,
           CancellationToken cancellationToken)
        {
            try
            {
                // Lakukan validasi menggunakan MediatR dan Validators
                var result = await _mediator.Send(new DeleteUserRequest(id), cancellationToken);

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
    }
}