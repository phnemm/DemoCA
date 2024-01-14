using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.DeleteStore
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, List<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public DeleteStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }


        public async Task<List<StoreDto>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.FindAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            if (store == null)
            {
                throw new NotFoundException($"Could not find Store '{request.Id}'");
            }

            _storeRepository.Remove(store);
            await _storeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var storelist = await _storeRepository.FindAllAsync(cancellationToken);
            return storelist.MapToStoreDtoList(_mapper);
        }
    }
}
