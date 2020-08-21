using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Closetheworld.Auth0.Sample.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new OkObjectResult("OK");
        }
    }
}
