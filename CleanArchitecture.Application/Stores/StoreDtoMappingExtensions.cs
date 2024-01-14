using AutoMapper;
using CleanArchitecture.Application.Stores;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders
{
    public static class StoreDtoMappingExtensions
    {
        public static StoreDto MapToStoreDto(this Store projectFrom, IMapper mapper)
            => mapper.Map<StoreDto>(projectFrom);

        public static List<StoreDto> MapToStoreDtoList(this IEnumerable<Store> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToStoreDto(mapper)).ToList();
    }
}
