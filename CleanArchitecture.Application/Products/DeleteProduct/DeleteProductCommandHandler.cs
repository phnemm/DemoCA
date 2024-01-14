using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<ProductDto> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var remove = await _productRepository.FindAsync(p => p.Id == command.Id, cancellationToken);
            if (remove == null)
                throw new NotFoundException($"Not found {command.Id}");
            _productRepository.Remove(remove);
            await _productRepository.UnitOfWork.SaveChangesAsync();
            return remove.MapToProductDto(_mapper);
        }
    }
}
