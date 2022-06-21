using Abp.Applictaion.User;
using Abp.Applictaion.User.Dto;
using Abp.Domian.UserInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility.AOP;

namespace Abp.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
      [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class UsersController : ControllerBase
    {
        private IUserAppService  _userAppService;
        public UsersController(IUserAppService  userAppService)
        {
            this._userAppService = userAppService;
        }
        
        [HttpGet]
        public async Task<UserDto> Get()
        {
            
            return await _userAppService.Get("23414", "123");
           
        }

        
    }
}
