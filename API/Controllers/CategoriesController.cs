using API.Infrastructure;
using BLL.DTO.Category;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<int> Create([FromBody] AddCategoryDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var Category = await _service.CreateAsync(dto);
            return Category.Id;
        }

        /// <summary>
        /// GET all Categorys
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ListCategoryDto>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<ListCategoryDto>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        //[AuthorizeRoles(RoleType.Admin)]
        [ProducesResponseType(204)]
        public async Task Edit(EditCategoryDto dto)
        {
            await _service.UpdateAsync(dto);
        }

        /// <summary>
        /// Delete Category
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
