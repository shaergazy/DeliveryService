namespace BLL.DTO
{
    public class BaseAddressDto
    {
        public string UserId { get; set; }
        public string Street { get; set; } = "";
        public string? City { get; set; } = "";
        public string? PostalCode { get; set; } = "";
        public string? Country { get; set; } = "";
    }

    public class AddAddressDto : BaseAddressDto { }

    public class EditAddressDto : IdHasAddressDto { }

    public class GetAddressDto : IdHasAddressDto { }

    public class ListAddressDto : IdHasAddressDto { }

    public class IdHasAddressDto
    {
        public int Id { get; set; }
    }
}
