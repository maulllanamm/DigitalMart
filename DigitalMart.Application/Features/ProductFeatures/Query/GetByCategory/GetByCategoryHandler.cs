using AutoMapper;
using DigitalMart.Application.Common.Exceptions;
using DigitalMart.Application.Features.AuthFeatures.LoginFeatures;
using DigitalMart.Application.Repositories;
using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetByCategory
{
    public class GetByCategoryHandler : IRequestHandler<GetByCategoryRequest, List<GetByCategoryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByCategoryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetByCategoryResponse>> Handle(GetByCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByCategory(request.CategoryName);
            if (products == null)
            {
                throw new NotFoundException($"Product with category {request.CategoryName} Not Found");
            }

            return _mapper.Map<List<GetByCategoryResponse>>(products);
        }
    }
}