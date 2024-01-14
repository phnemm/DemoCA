using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers
{
    public static class VoucherDtoMappingExtensions
    {
        public static VoucherDto MapToVoucherDto(this Voucher projectFrom, IMapper mapper)
            => mapper.Map<VoucherDto>(projectFrom);

        public static List<VoucherDto> MapToVoucherDtoList(this IEnumerable<Voucher> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToVoucherDto(mapper)).ToList();
    }
}
