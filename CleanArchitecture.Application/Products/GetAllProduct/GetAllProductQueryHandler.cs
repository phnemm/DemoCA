using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var list = await _productRepository.FindAllAsync(cancellationToken);
            if (list == null)
                throw new NotFoundException($"Not found {list}");
            List<ProductDto> result = new List<ProductDto>();
            foreach (var item in list)
            {
                var add = item.MapToProductDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
