using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Store>
    {
        private readonly IStoreRepository _storeRepository;


        public UpdateStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }


        public async Task<Store> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.FindAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            if (store == null)
            {
                throw new NotFoundException($"Could not find Store '{request.Id}'");
            }

            store.Address = request.Address;
            store.BranchNumber = request.BranchNumber;

            _storeRepository.Update(store);
            await _storeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return store;
        }
    }
}
