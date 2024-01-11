using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.UpdateVoucher
{
    public class UpdateVoucherCommandValidation : AbstractValidator<UpdateVoucherCommand>
    {
        public UpdateVoucherCommandValidation()
        {
            //RuleFor(v => v.Percent)

            RuleFor(v => v.Id).NotEmpty().WithMessage("id not null");
           
                
        }
    }
}
