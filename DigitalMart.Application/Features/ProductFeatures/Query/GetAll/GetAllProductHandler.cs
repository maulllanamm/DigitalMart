using AutoMapper;
using DigitalMart.Application.Repositories;
using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetAll
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request,
            CancellationToken cancellationToken)
        {
            var res = await _productRepository.GetAll();
            return _mapper.Map<List<GetAllProductResponse>>(res);
        }
    }
}