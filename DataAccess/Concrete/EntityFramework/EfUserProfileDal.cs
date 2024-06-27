using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserProfileDal : EfEntityRepositoryBase<User, AppManagementDBContext>, IUserProfileDal
    {
        
        public List<UserProfileDetailDto> GetUserProfileDetails()
        {
            using (AppManagementDBContext context = new AppManagementDBContext())
            {
                var result = from u in context.Users
                             select new UserProfileDetailDto
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Adress = u.Adress,
                                 Email = u.Email,
                                 Phone = u.Phone,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Status = u.Status
                             };
                return result.ToList();

            }
        }
    }
}
