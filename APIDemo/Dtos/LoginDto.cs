using System.ComponentModel.DataAnnotations;

namespace APIDemo.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
