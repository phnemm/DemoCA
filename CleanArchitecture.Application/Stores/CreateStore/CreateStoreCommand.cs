using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.CreateStore
{
    public class CreateStoreCommand : IRequest<List<StoreDto>>, ICommand
    {
        public CreateStoreCommand(string address, int branchNumber)
        {
            Address = address;
            BranchNumber = branchNumber;
        }

        public string Address { get; set; }
        public int BranchNumber { get; set; }
    }
}
