using System.Threading.Tasks;
using eShop.ClientApp.Models.User;
using Scheduler.MAUI.Models.User;

namespace Scheduler.MAUI.Services.Identity;

public interface IIdentityService
{
    Task<bool> SignInAsync();

    Task<bool> SignOutAsync();

    Task<UserInfo> GetUserInfoAsync();
}