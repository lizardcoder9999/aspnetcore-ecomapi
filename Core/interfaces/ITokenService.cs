using Core.Models.Identity;

namespace Core.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
