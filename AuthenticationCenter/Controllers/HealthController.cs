using Microsoft.AspNetCore.Mvc;

namespace AuthenticationCenter.Controllers
{   
    [ApiController]
    [Route("api/[controller]")] 
    public class HealthController: ControllerBase
    {[HttpGet]
        public ActionResult Get()
        {
            return Content("OK");
        }

    }
}
