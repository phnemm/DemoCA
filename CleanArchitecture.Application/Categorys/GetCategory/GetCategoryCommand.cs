using CleanArchitecture.Application.Categorys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Category.GetCategory
{
    public class GetCategoryCommand : IRequest<List<CategoryDto>>
    {

    }
}
