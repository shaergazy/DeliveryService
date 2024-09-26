using AutoMapper;
using BLL.DTO.Category;
using BLL.Services.Interfaces;
using DAL.Models;
using Data.Repositories.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services.Implementations
{
    public class CategoryService : GenericService<Category, int, ListCategoryDto, AddCategoryDto, EditCategoryDto, GetCategoryDto>, ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Category, int> _unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork<Category, int> unitOfWork, ILogger<CategoryService> logger) : base(mapper, unitOfWork, logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
