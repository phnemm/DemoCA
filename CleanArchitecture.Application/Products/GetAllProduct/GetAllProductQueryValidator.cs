using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetAllProduct
{
    public class GetAllProductQueryValidator : AbstractValidator<GetAllProductQuery>
    {
        public GetAllProductQueryValidator() 
        {
            ConfigureValidationRules();
        }

        public void ConfigureValidationRules()
        {

        }
    }
}
