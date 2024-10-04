using BLL.DTO;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IAddressService : IGenericService<Address, int, ListAddressDto, AddAddressDto, EditAddressDto, GetAddressDto>
    {
    }
}
