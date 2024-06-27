using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserProfileService
    {
        IDataResult<User> GetProfile(int userId);
        IResult Update(User user);
        IResult ChangePassword(string oldPassword, string newPassword);
    }
}
