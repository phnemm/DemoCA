using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers
{
    public class VoucherDto : IMapFrom<Voucher>
    {
        public VoucherDto()
        {
        }

        public Guid Id { get; set; }

        public float Percent { get; set; }
        public int Quantity { get; set; }

        public static VoucherDto Create(Guid id, float percent, int quantity)
        {
            return new VoucherDto
            {
                Id = id,
                Percent = percent,
                Quantity = quantity
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Voucher, VoucherDto>();
        }
    }
}
