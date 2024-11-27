using System.ComponentModel.DataAnnotations;

namespace APIDemo.Dtos
{
    public class UserDto
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
        [StringLength(10,MinimumLength =5,ErrorMessage ="Length Invalid Email ID")]
        public string Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
    }
}
