
namespace PIHCM.Gen.Controllers
{
    [Route("api/[controller]")]
    public class GenTableController : BaseController
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Success();
        }
    }
}
