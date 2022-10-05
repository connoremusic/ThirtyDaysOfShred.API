using Microsoft.AspNetCore.Mvc;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
