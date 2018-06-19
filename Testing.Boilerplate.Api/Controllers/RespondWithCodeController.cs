using Microsoft.AspNetCore.Mvc;
using Testing.Boilerplate.Api.Attributes;
using Testing.Boilerplate.Api.Models;

namespace Testing.Boilerplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespondWithCodeController : ControllerBase
    {
        [HttpPost]
        [MetricName("respondwithcode")]
        public ActionResult Post([FromBody] RespondWithCodeRequest request)
        {
            return StatusCode(request.ResponseCode, new { Name = "Badger" });
        }
    }
}
