using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores
{
    public class StoreDto : IMapFrom<Store>
    {
        public StoreDto()
        {
        }

        public Guid Id { get; set; }
        public string Address { get; set; }
        public int BranchNumber { get; set; }

        public static StoreDto Create(Guid id, string address, int branchNumber)
        {
            return new StoreDto
            {
                Id = id,
                Address = address,
                BranchNumber = branchNumber
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Store, StoreDto>();
        }
    }
}
