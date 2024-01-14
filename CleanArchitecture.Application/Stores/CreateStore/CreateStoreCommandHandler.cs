using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.CreateStore
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, List<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }


        public async Task<List<StoreDto>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store
            {
                Address = request.Address,
                BranchNumber = request.BranchNumber,
            };

            _storeRepository.Add(store);
            await _storeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var stores = await _storeRepository.FindAllAsync(cancellationToken);
            return stores.MapToStoreDtoList(_mapper);
        }
    }
}
