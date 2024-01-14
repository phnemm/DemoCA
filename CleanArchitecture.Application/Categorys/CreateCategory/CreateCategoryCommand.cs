using CleanArchitecture.Application.Categorys;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CleanArchitecture.Application.Category.CreateCategory
{
    public class CreateCategoryCommand : IRequest<List<CategoryDto>>, Common.Interfaces.ICommand

    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
