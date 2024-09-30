using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Models;
using Data.Repositories.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services.Implementations
{
    public class ProductService : GenericService<Product, int, ListProductDto, AddProductDto, EditProductDto, GetProductDto>, IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Product, int> _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork<Product, int> unitOfWork, ILogger<ProductService> logger) : base(mapper, unitOfWork, logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<Product> BuildEntityForCreateAsync(AddProductDto dto)
        {
            // TODO Add all validations, if Image = null, then assign default image
            var product = _mapper.Map<Product>(dto);
            product.ImageUrl = await SaveFileAsync(dto.Image);
            return product;
        }

        public override async Task<Product> BuildEntityForUpdate(EditProductDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(dto.Id);

            if (product == null)
                throw new ArgumentException("Entity with such Id does not exist");
            return _mapper.Map<Product>(dto);
        }
    }
}
