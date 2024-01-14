using CleanArchitecture.Application.Categorys;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Category.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Domain.Entities.Category>, ICommand
    {
        public UpdateCategoryCommand(Guid id, String name, String description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }
}
