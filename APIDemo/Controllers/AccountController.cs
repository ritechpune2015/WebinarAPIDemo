using APIDemo.Dtos;
using APIDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAuthRepo uauth;
        public AccountController(IUserAuthRepo auth)
        {
            this.uauth= auth;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto rec)
        {
            var res = await this.uauth.Register(rec);
            if (res.Succeeded)
            {
                return Ok(
                     new NewUserDto()
                     {
                         EmailID = rec.EmailID,
                         FullName = rec.FullName,
                         MobileNo = rec.MobileNo
                     }
                    );
            }
            else
            {
                return StatusCode(500, res.Errors);
            }
        }
    }
}
