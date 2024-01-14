using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.UpdateStore
{
    public class UpdateStoreCommand : IRequest<Store>, ICommand
    {
        public UpdateStoreCommand(Guid id, string address, int branchNumber)
        {
            Id = id;
            Address = address;
            BranchNumber = branchNumber;
        }

        public Guid Id { get; set; }
        public string Address { get; set; }
        public int BranchNumber { get; set; }
    }
}
