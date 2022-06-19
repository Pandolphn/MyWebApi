using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Utility.AOP;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class HealthController: ControllerBase
    {
        [HttpGet]
       public IActionResult Get() {
            return Content("OK");
        }
    }
}
