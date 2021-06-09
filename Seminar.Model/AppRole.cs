using Microsoft.AspNetCore.Identity;

namespace Seminar.Model
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}
