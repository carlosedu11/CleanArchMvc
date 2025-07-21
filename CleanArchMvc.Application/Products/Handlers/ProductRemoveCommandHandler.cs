using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRespository _productRespository;
        public ProductRemoveCommandHandler(IProductRespository productRespository)
        {
            _productRespository = productRespository ??
                throw new ArgumentNullException(nameof(productRespository));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRespository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                var result = await _productRespository.RemoveAsync(product);
                return result;
            }
        }
    }
}
