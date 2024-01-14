using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.DeleteStore
{
    public class DeleteStoreCommand : IRequest<List<StoreDto>>, ICommand
    {
        public DeleteStoreCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
