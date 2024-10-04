using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Models;
using Data.Repositories.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services.Implementations
{
    public class AddressService : GenericService<Address, int, ListAddressDto, AddAddressDto, EditAddressDto, GetAddressDto>, IAddressService
    {
        private readonly ILogger<AddressService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Address, int> _unitOfWork;

        public AddressService(IMapper mapper, IUnitOfWork<Address, int> unitOfWork, ILogger<AddressService> logger) : base(mapper, unitOfWork, logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
