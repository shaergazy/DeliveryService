using BLL.DTO;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService : IGenericService<Category, int, ListCategoryDto, AddCategoryDto, EditCategoryDto, GetCategoryDto>
    {
    }
}