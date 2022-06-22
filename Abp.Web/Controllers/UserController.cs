using Abp.Applictaion.User;
using Abp.Applictaion.User.Dto;
using AspNetCore.Hashids.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
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
           return  await _userAppService.Get("23414", "123"); 
        }
        [HttpGet]
        [Route("{id:hashids}")] 
        public async Task<UserDto> GetUserById( [ModelBinder(typeof(HashidsModelBinder))] int id) 
        { 
            return  await _userAppService.GetUserById(id); 
        }
        
    }
}
