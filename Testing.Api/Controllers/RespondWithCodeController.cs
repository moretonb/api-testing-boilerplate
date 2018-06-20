using Microsoft.AspNetCore.Mvc;
using Testing.Api.Attributes;
using Testing.Api.Models;

namespace Testing.Api.Controllers
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
