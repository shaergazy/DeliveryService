namespace BLL.DTO
{
    public class AddCategoryDto : BaseCategoryDto
    {
    }

    public class EditCategoryDto : IdHasCategoryDto
    {
    }

    public class GetCategoryDto : IdHasCategoryDto
    {
    }

    public class ListCategoryDto : IdHasCategoryDto
    {
    }

    public class BaseCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class IdHasCategoryDto : BaseCategoryDto
    {
        public int Id { get; set; }
    }
}
