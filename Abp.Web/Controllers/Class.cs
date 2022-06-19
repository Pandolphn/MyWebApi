using Abp.Applictaion.User;
using Abp.Applictaion.User.Dto;
using Abp.Domian.UserInfo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility.AOP;

namespace Abp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
      [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class HealthController : ControllerBase
    {
        private IUserAppService  _userAppService;
        public HealthController(IUserAppService  userAppService)
        {
            this._userAppService = userAppService;
        }
        [HttpGet]
        public async Task<UserDto> Get()
        {
            throw new NotImplementedException();
            return await _userAppService.Get("23414", "123");
           
        }

        
    }
}
