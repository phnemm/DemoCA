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
            var check = await _productRepository.IsUniqueName(command.Name, cancellationToken);
                if (check)
                    throw new Exception("Name must be unique");
            product.Name = command.Name;
            product.Size = command.Size;
            product.Color = command.Color;
            product.Price = command.Price;


            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();
            return product.MapToProductDto(_mapper);
        }
    }
}
