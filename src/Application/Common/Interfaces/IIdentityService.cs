using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Models;
using System.Threading.Tasks;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
