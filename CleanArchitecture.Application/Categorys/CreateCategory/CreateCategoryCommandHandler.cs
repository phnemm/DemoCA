using AutoMapper;
using CleanArchitecture.Application.Category.CreateCategory;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Categorys.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _categoryRepository = CategoryRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                Name = request.Name,
                Description = request.Description
            };

            _categoryRepository.Add(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            var categorys = await _categoryRepository.FindAllAsync(cancellationToken);
            return categorys.MapToCategoryDtoList(_mapper);
        }
    }
}
