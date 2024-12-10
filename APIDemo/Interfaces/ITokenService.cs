using APIDemo.Models;

namespace APIDemo.Interfaces
{
    public interface ITokenService
    {
        string GenerateSigningToken(AppUser user);
    }
}
