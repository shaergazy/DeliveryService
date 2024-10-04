using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Models;
using Data.Repositories.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services.Implementations
{
    public class PaymentMethodService : GenericService<PaymentMethod, int, PaymentMethodDto, PaymentMethodDto, PaymentMethodDto, PaymentMethodDto>, IPaymentMethodService
    {
        private readonly ILogger<PaymentMethodService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<PaymentMethod, int> _unitOfWork;

        public PaymentMethodService(IMapper mapper, IUnitOfWork<PaymentMethod, int> unitOfWork, ILogger<PaymentMethodService> logger) : base(mapper, unitOfWork, logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
