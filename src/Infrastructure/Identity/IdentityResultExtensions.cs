using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Clean_Architecture_Asp_Net_Core_Starter.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}