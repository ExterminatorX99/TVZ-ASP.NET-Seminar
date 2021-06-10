using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Seminar.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IList<string> Roles { get; set; }

        public string RolesSeparated => string.Join(", ", Roles);

        public UserViewModel()
        {
        }

        public UserViewModel(string id, string userName, string email, string phoneNumber)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Roles = new List<string>();
        }
    }

    public static class UserViewExtensions
    {
        public static async Task<UserViewModel> ConvertToViewModel(this IdentityUser user, UserManager<IdentityUser> userManager) =>
            new(user.Id, user.UserName, user.Email, user.PhoneNumber)
            {
                Roles = await userManager.GetRolesAsync(user)
            };

        public static async Task<List<UserViewModel>> ConvertToViewModels(this List<IdentityUser> users, UserManager<IdentityUser> userManager)
        {
            List<UserViewModel> userViewModels = new();
            foreach (IdentityUser user in users)
                userViewModels.Add(await user.ConvertToViewModel(userManager));

            return userViewModels;
        }
    }
}
