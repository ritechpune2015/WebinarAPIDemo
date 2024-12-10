using APIDemo.Dtos;
using APIDemo.Interfaces;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAuthRepo uauth;
        private readonly ITokenService tokenService;
        
        public AccountController(IUserAuthRepo auth,ITokenService token)
        {
            this.uauth= auth;
            this.tokenService= token;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto rec)
        {
            if (rec == null)
                return BadRequest("Invalid Email ID or Password!");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var res = await this.uauth.Login(rec);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            else
            {
                return Unauthorized("Invalid Email Id or Password!");
            }
        }
    }
}
