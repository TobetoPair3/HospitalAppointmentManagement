using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserProfileManager : IUserProfileService
    {
        IUserProfileDal _userProfileDal;

        public UserProfileManager(IUserProfileDal userProfileDal)
        {
            _userProfileDal = userProfileDal;
        }

        public IResult ChangePassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetProfile(int userId)
        {
            return new SuccessDataResult<User>(_userProfileDal.Get(u=>u.Id == userId));
        }
        

        public IResult Update(User user)
        {
            _userProfileDal.Update(user);
            return new SuccessResult("User Updated");
        }
    }
}
