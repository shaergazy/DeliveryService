﻿using Microsoft.AspNetCore.Identity;

namespace DAL.Models.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public ICollection<UserRole> Roles { get; set; }
    }
}
