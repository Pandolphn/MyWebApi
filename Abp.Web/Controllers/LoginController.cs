using Abp.Applictaion.User;
using Abp.Applictaion.User.Dto;
using Microsoft.AspNetCore.Mvc;
using Utility.AOP;

namespace Abp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class LoginController
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            this._userAppService = userAppService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDto dto)
        {
            return null;
        }
    }
}
