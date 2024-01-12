using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products
{
    public class ProductDto : IMapFrom<Domain.Entities.Product>
    {
        public ProductDto() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color {  get; set; }
        public decimal Price { get; set; }

        public ProductDto(Guid id, string name, string size, string color, decimal price)
        {
            Id = id;
            Name = name;
            Size = size;
            Color = color;
            Price = price;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>();
        }
    }
}
