using BLL.DTO.Product;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService : IGenericService<Product, int, ListProductDto, AddProductDto, EditProductDto, GetProductDto>
    {
    }
}
