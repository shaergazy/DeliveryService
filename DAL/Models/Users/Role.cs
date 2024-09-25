using Microsoft.AspNetCore.Identity;

namespace DAL.Models.Users
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> Users {  get; set; }
    }
}
