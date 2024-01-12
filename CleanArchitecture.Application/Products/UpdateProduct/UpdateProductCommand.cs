using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>, ICommand
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Size { get; set; }
        public string? Color { get; set; }
        public decimal? Price { get; set; }
        public UpdateProductCommand(Guid id, string? name, decimal? size, string? color, decimal? price)
        {
            Id = id;
            Name = name;
            Size = size;
            Color = color;
            Price = price;
        }
    }
}
