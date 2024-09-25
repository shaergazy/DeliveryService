using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Common.Extensions;

namespace API.Infrastructure
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params RoleType[] allowedRoles)
        {
            Roles = string.Join(",", allowedRoles.Select(x => x.Description()));
        }
    }

}
