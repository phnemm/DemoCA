
using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.GetVoucher
{
    public class GetVoucherQuerryHandler : IRequestHandler<GetVoucherQuerry, List<VoucherDto>>
    {
        private readonly IVoucherRepository _voucherRepository;

        private readonly IMapper _mapper;

        public GetVoucherQuerryHandler(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper = mapper;
        }

        public async Task<List<VoucherDto>> Handle(GetVoucherQuerry request, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepository.GetAllAsync(cancellationToken);
            return voucher.MapToVoucherDtoList(_mapper);
        }
    }
}
