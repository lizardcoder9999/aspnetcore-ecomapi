using System.Linq;
using System.Security.Claims;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace angularApiCore.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByEmailWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
