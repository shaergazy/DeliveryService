using API.Infrastructure;
using BLL.DTO.Product;
using BLL.Services.Interfaces;
using Common.Enums;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<int> Create(AddProductDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var Product = await _service.CreateAsync(dto);
            return Product.Id;
        }

        /// <summary>
        /// GET all Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ListProductDto>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<ListProductDto>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(204)]
        public async Task Edit([FromForm] EditProductDto dto)
        {
            await _service.UpdateAsync(dto);
        }

        /// <summary>
        /// Delete Product
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
