using CleanArchitecture.Application.Vouchers.CreateVoucher;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.CreateVoucher
{
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, Guid>
    {
        private readonly IVoucherRepository _voucherRepository;


        public CreateVoucherCommandHandler(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }


        public async Task<Guid> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            var voucher = new Voucher
            {
               
               Percent=request.Percent,
               Quantity=request.Quantity,
            };

            _voucherRepository.Add(voucher);//đổ xuống data
            await _voucherRepository.UnitOfWork.SaveChangesAsync(cancellationToken);// save lại
            return voucher.Id;
        }
    }
}
