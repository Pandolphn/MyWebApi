using Microsoft.AspNetCore.Mvc;

namespace Abp.Web.Controllers
{   
    [ApiController]
    [Route("api/[controller]")] 
    public class HealthController: ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Content("OK");
        }

    }
}
