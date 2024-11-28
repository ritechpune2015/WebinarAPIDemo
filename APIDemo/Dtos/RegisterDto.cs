using System.ComponentModel.DataAnnotations;

namespace APIDemo.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; }
        //public string UserName { get; set; }
        
        [EmailAddress]
        [Required]
        public string EmailID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Length Invalid For Address")]
        public string Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
    }
}
