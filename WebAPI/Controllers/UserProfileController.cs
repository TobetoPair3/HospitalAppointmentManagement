using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : Controller
    {
        IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_userProfileService.GetProfile(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var result = _userProfileService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
