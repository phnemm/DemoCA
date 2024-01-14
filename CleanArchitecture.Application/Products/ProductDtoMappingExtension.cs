﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products
{
    public static class ProductDtoMappingExtension
    {
        public static ProductDto MapToProductDto(this Domain.Entities.Product product, IMapper _mapper)
            => _mapper.Map<ProductDto>(product);
    }
}
