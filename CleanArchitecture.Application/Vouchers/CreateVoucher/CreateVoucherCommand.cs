using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.CreateVoucher
{
    public class CreateVoucherCommand : IRequest<Guid>, ICommand
    {
        public CreateVoucherCommand(float percent, int quantity)
        {

            Percent = percent;
            Quantity = quantity;
        }


        public float Percent { get; set; }
        public int Quantity { get; set; }

    }
}
