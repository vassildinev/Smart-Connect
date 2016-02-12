using Microsoft.AspNet.Identity;
using SmartConnect.Data.Models;

namespace SmartConnect.Services.Identity.Contracts
{
    public interface IIdentityService
    {
        IdentityResult AddToRole(string userId, string roleName);

        IdentityResult CreateUser(User user, string password);
    }
}
