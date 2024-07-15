using AutoMapper;
using DigitalMart.Application.Common.Exceptions;
using DigitalMart.Application.Repositories;
using DigitalMart.Domain.Entities;
using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Command.UpdateProduct
{
    public sealed class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product is null)
            {
                throw new NotFoundException("Product Not Found");
            }
            product.name = request.Name;
            product.category_name = request.CategoryName;
            product.description = request.Description;
            product.price = request.Price;
            product.image_url = request.ImageUrl;
            product.image_local_path = request.ImageLocalPath;
            product.modified_date = DateTime.UtcNow;

            var res = await _productRepository.Update(product);

            return _mapper.Map<UpdateProductResponse>(res);
        }
    }
}