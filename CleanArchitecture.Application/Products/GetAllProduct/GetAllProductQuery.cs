using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<ProductDto>>, IQuery
    {
        public GetAllProductQuery() { }
    }
}
