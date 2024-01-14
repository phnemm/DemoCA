using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.GetVoucher
{
    public class GetVoucherQuerry : IRequest<List<VoucherDto>>, IQuery
    {

    }
}
