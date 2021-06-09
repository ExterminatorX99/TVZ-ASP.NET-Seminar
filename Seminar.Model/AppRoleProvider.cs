using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Seminar.Model
{
    public class AppRoleManager : RoleManager<AppUser>
    {
        public AppRoleManager(IRoleStore<AppUser> store, IEnumerable<IRoleValidator<AppUser>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<AppUser>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
