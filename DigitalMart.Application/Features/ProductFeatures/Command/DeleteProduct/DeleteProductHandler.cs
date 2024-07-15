using DigitalMart.Application.Common.Exceptions;
using DigitalMart.Application.Repositories;
using MediatR;

namespace DigitalMart.Application.Features.ProductFeatures.Command.DeleteProduct
{
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.id);
            if (product is null)
            {
                throw new NotFoundException("Product Not Found");
            }

            return await _productRepository.Delete(request.id);
        }
    }
}