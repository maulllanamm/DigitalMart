using AutoMapper;
using DigitalMart.Application.Repositories;
using DigitalMart.Domain.Entities;
using MediatR;

namespace DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest,CreateProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        if (string.IsNullOrEmpty(product.image_url))
        {
            product.image_url = "https://placehold.co/600x400";
        }

        var create = await _productRepository.Create(product);
        return _mapper.Map<CreateProductResponse>(create);
    }
}