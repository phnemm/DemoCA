using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(p => p.Id == command.Id, cancellationToken);
            if (product == null)
                throw new NotFoundException($"Not found {command.Id}");
            product.Name = command.Name ?? product.Name;
            product.Size = command.Size ?? product.Size;
            product.Color = command.Color ?? product.Color;
            product.Price = command.Price ?? product.Price;
            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();
            return product.MapToProductDto(_mapper);
        }
    }
}
