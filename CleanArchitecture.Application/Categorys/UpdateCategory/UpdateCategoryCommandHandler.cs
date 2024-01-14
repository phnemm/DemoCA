using CleanArchitecture.Application.Category.UpdateCategory;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CleanArchitecture.Application.Categorys.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Domain.Entities.Category>
    {
        private readonly ICategoryRepository _categoryRepository;


        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<Domain.Entities.Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            if (category == null)
            {
                throw new NotFoundException($"Could not find category '{request.Id}'");
            }

            category.Name = request.Name;
            category.Description = request.Description;

            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return category;
        }
    }
}
