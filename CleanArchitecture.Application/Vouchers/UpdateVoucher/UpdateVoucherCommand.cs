using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.UpdateVoucher
{
    public class UpdateVoucherCommand : IRequest<VoucherDto>,ICommand
    {
        public UpdateVoucherCommand(Guid id, float percent, int quantity)
        {
            Id = id;
            Percent = percent;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public float Percent { get; set; }
        public int Quantity { get; set; }
    }
}
