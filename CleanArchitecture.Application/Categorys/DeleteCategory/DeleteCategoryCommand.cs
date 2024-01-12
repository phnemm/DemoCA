using CleanArchitecture.Application.Categorys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CleanArchitecture.Application.Category.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<List<CategoryDto>>, Common.Interfaces.ICommand

    {
        public Guid Id { get; set; }
        public DeleteCategoryCommand(Guid id) 
        { 
            Id = id;
        }
    }
}
