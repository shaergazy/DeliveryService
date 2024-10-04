using BLL.DTO;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IPaymentMethodService : IGenericService<PaymentMethod, int, PaymentMethodDto, PaymentMethodDto, PaymentMethodDto, PaymentMethodDto>
    {
    }
}
