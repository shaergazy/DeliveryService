using BLL.DTO;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService : IGenericService<Product, int, ListProductDto, AddProductDto, EditProductDto, GetProductDto>
    {
    }
}
