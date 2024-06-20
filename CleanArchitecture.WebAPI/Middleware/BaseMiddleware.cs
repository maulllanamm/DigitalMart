using CleanArchitecture.Application.Features.AuthFeatures.PermittionFeatures;
using CleanArchitecture.Application.Helper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;

namespace CleanArchitecture.WebAPI.Middleware
{
    public class BaseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMediator _mediator;

        public BaseMiddleware(RequestDelegate next, IMediator mediator)
        {
            _next = next;
            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isPermitted = await _mediator.Send(new IsPermittedRequest(context));

            if (isPermitted)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
