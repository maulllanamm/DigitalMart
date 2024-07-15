using DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;
using DigitalMart.Application.Helper.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMart.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheHelper _cacheHelper;

        public ProductController(IMediator mediator, ICacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }
      
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}