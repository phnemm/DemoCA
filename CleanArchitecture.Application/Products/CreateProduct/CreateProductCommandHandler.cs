using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name,
                Color = command.Color,
                Size = command.Size,
                Price = command.Price,
            };

            var check = await _productRepository.IsUniqueName(product.Name, cancellationToken);
            if (check)
                throw new Exception("Name must be unique");

            _productRepository.Add(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();
            return product.Id;
        }
    }
}
