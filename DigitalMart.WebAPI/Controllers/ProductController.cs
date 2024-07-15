using DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;
using DigitalMart.Application.Features.UserFeatures.Query.GetAll;
using DigitalMart.Application.Features.UserFeatures.Query.GetByCategory;
using DigitalMart.Application.Features.UserFeatures.Query.GetById;
using DigitalMart.Application.Features.UserFeatures.Query.GetByUsername;
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
        
        [HttpGet]
        public async Task<ActionResult<GetAllProductResponse>> GetAll(CancellationToken cancellationToken)
        {
            var cacheData = _cacheHelper.GetData<IEnumerable<GetAllProductResponse>>("users");
            if (cacheData != null && cacheData.Count() > 0)
            {
                return Ok(cacheData);
            }
            var result = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
            var expireTime = DateTime.Now.AddMinutes(1);
            _cacheHelper.SetData<IEnumerable<GetAllProductResponse>>("users", result, expireTime);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<GetByIdProductResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdProductRequest(id), cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetByCategoryResponse>>> GetByCategory(string category, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetByCategoryRequest(category), cancellationToken);
            return Ok(result);
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