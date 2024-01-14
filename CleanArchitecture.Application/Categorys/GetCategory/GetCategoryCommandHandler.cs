using AutoMapper;
using CleanArchitecture.Application.Category.GetCategory;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Categorys.GetCategory
{
    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {

            var stores = await _categoryRepository.FindAllAsync(cancellationToken);
            return stores.MapToCategoryDtoList(_mapper);
        }
    }
}
