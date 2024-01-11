using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.UpdateVoucher
{
    public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand,VoucherDto>
    {
        private readonly IVoucherRepository _voucherRepository;

        private readonly IMapper _mapper;

        public UpdateVoucherCommandHandler(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper = mapper;
        }

        public async Task<VoucherDto> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
        {
            var voucher= await _voucherRepository.FindByIdsAsync(request.Id, cancellationToken);
            if (voucher == null)
            {
                throw new Exception("could'n find id "+ request.Id);
            }
            voucher.Percent = request.Percent;
            voucher.Quantity= request.Quantity;
            _voucherRepository.Update(voucher);
            await _voucherRepository.UnitOfWork.SaveChangesAsync(cancellationToken);// save lại
            return voucher.MapToVoucherDto(_mapper);
        }
    }
}
