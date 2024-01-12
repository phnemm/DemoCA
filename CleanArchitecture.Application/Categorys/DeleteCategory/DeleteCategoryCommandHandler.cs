using AutoMapper;
using CleanArchitecture.Application.Category.DeleteCategory;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Categorys.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            if (category == null)
            {
                throw new NotFoundException($"Could not find category '{request.Id}'");
            }

            _categoryRepository.Remove(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var categorylist = await _categoryRepository.FindAllAsync(cancellationToken);
            return categorylist.MapToCategoryDtoList(_mapper);
        }
    }
}
