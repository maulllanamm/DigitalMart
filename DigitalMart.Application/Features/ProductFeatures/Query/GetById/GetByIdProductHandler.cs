using AutoMapper;
using DigitalMart.Application.Common.Exceptions;
using DigitalMart.Application.Repositories;
using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetById
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _productRepository.GetById(request.Id);
            if (user == null)
            {
                throw new NotFoundException("Product Not Found");
            }

            return _mapper.Map<GetByIdProductResponse>(user);
        }
    }
}