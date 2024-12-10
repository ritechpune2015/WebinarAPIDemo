using APIDemo.Dtos;
using APIDemo.Interfaces;
using APIDemo.Mappers;
using APIDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace APIDemo.Repositories
{
    public class UserAuthRepo : IUserAuthRepo
    {
        private readonly ProductContext cntx;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenservice;
        public UserAuthRepo(ProductContext cntx,UserManager<AppUser> userManager,SignInManager<AppUser> signIn,ITokenService tokenService)
        {
            this.cntx= cntx;
            this.userManager= userManager;
            this.signInManager= signIn;
            this.tokenservice= tokenService;
        }

        public async Task<LoginResultDto> Login(LoginDto rec)
        {
           LoginResultDto logres = new LoginResultDto();
           var user = await this.userManager.Users.FirstOrDefaultAsync(p=>p.UserName==rec.EmailID);

            if (user == null)
            {
                logres.IsSuccess = false;
                logres.Message = "Invalid Email Id or Password!";
                return logres;
            }

            var res = await this.signInManager.CheckPasswordSignInAsync(user, rec.Password, false);

            if (!res.Succeeded)   {
                logres.IsSuccess = false;
                logres.Message = "Invalid Email ID or Password!";
            }
            else            {
                logres.IsSuccess = true;
                logres.Name = user.FullName;
                logres.Token = tokenservice.GenerateSigningToken(user);
            }
          return logres;
        }

        public  async Task<IdentityResult> Register(RegisterDto rec)
        {
            var model = rec.FromRegisterDtoToAppUser();
            var res = await this.userManager.CreateAsync(model, rec.Password);
            return res;
        }
    }
}
