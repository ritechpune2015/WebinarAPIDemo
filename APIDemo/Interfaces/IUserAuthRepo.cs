using APIDemo.Dtos;
using Microsoft.AspNetCore.Identity;

namespace APIDemo.Interfaces
{
    public interface IUserAuthRepo
    {
        Task<IdentityResult> Register(RegisterDto rec);
    }
}
