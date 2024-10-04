using BLL.DTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    ///<summary>
    /// Applications controller
    ///</summary>
    /// <response code="400">Error in model data</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="500">Uncatched, unknown error</response>
    /// <response code="403">Access denied</response>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressesController(IAddressService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add Address
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<int> Create([FromBody] AddAddressDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var Address = await _service.CreateAsync(dto);
            return Address.Id;
        }

        /// <summary>
        /// GET all Addresss
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ListAddressDto>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<ListAddressDto>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Edit Address
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(204)]
        public async Task Edit(EditAddressDto dto)
        {
            await _service.UpdateAsync(dto);
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(204)]
        public async Task DeleteById(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
