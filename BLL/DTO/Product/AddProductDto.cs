using Microsoft.AspNetCore.Http;

namespace BLL.DTO.Product
{
    public class AddProductDto : BaseProductDto
    {
        public IFormFile Image { get; set; }
    }
}
