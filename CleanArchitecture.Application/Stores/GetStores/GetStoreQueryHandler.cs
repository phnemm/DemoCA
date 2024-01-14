using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Application.Stores.CreateStore;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.GetStores
{
    public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, List<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<List<StoreDto>> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {

            var stores = await _storeRepository.FindAllAsync(cancellationToken);
            return stores.MapToStoreDtoList(_mapper);
        }
    }
}
