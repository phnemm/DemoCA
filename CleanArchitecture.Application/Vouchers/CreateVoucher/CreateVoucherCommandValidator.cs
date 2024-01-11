using CleanArchitecture.Application.Authenticate.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vouchers.CreateVoucher
{
    public class CreateVoucherCommandValidator : AbstractValidator<CreateVoucherCommand>
    {
        public CreateVoucherCommandValidator()
        {
            //RuleFor(v => v.Percent)
               

            //RuleFor(v => v.password)
            //    .NotEmpty().WithMessage("Password is required")
            //    .MaximumLength(50).WithMessage("Password must not exceed 50 characters.");
        }
    }
}
