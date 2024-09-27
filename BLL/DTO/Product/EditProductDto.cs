using Microsoft.AspNetCore.Http;

namespace BLL.DTO.Product
{
    public class EditProductDto : IdHasProductDto
    {
        public IFormFile Image { get; set; }
    }
}
