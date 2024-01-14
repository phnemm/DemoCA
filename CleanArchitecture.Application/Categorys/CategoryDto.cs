using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CleanArchitecture.Application.Categorys
{
    public class CategoryDto : IMapFrom<Domain.Entities.Category>
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public static CategoryDto Create(String name, String description)
        {
            return new CategoryDto()
            {
                Name = name,
                Description = description
            };


        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>();
        }
    }
}
