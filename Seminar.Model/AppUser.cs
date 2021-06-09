using Microsoft.AspNetCore.Identity;

namespace Seminar.Model
{
    public class AppUser : IdentityUser
    {
        public AccessLevel AccessLevel { get; set; }
    }

    public enum AccessLevel
    {
        Administrator,
        Writer,
        Editor,
        Reviewer,
        User,
        Guest
    }
}
