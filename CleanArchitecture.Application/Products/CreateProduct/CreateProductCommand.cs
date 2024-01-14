using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid> ,ICommand
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; } 

        public CreateProductCommand(string name, decimal size, string color, decimal price)
        {
            Name = name;
            Size = size;
            Color = color;
            Price = price;
        }
    }
}
