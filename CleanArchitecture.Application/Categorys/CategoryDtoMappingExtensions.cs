using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CleanArchitecture.Application.Categorys
{
    public static class CategoryDtoMappingExtensions
    {
        public static CategoryDto MapToCategoryDto(this Domain.Entities.Category projectFrom, IMapper mapper)
        => mapper.Map<CategoryDto>(projectFrom);

        public static List<CategoryDto> MapToCategoryDtoList(this IEnumerable<Domain.Entities.Category> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToCategoryDto(mapper)).ToList();
    }
}
