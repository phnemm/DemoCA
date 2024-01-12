using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>, IQuery
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
