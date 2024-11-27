using Microsoft.AspNetCore.Identity;

namespace APIDemo.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
    }
}
