using APIDemo.Dtos;
using APIDemo.Models;

namespace APIDemo.Mappers
{
    public static class IdentityMapper
    {
        public static AppUser FromRegisterDtoToAppUser(this RegisterDto rec)
        {
            return new AppUser()
            {
                 Address = rec.Address,
                 Email=rec.EmailID,
                 FullName = rec.FullName,
                 MobileNo = rec.MobileNo,
                 UserName=rec.EmailID
            };
        }

    }
}
