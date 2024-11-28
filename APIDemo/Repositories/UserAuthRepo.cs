using APIDemo.Dtos;
using APIDemo.Interfaces;
using APIDemo.Mappers;
using APIDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIDemo.Repositories
{
    public class UserAuthRepo : IUserAuthRepo
    {
        private readonly ProductContext cntx;
        private readonly UserManager<AppUser> userManager;
        public UserAuthRepo(ProductContext cntx,UserManager<AppUser> userManager)
        {
            this.cntx= cntx;
            this.userManager= userManager;
        }
        public  async Task<IdentityResult> Register(RegisterDto rec)
        {
            var model = rec.FromRegisterDtoToAppUser();
            var res = await this.userManager.CreateAsync(model, rec.Password);
            return res;
        }
    }
}
