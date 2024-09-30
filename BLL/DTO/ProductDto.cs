using Microsoft.AspNetCore.Http;

namespace BLL.DTO
{
    public class AddProductDto : BaseProductDto
    {
        public IFormFile Image { get; set; }
    }

    public class EditProductDto : IdHasProductDto
    {
        public IFormFile Image { get; set; }
    }

    public class ListProductDto : IdHasProductDto
    {
        public string ImageUrl { get; set; } = "";
    }

    public class GetProductDto : IdHasProductDto
    {
        public string ImageUrl { get; set; } = "";
    }

    public class IdHasProductDto : BaseProductDto
    {
        public int Id { get; set; }
    }

    public class BaseProductDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
