using Microsoft.AspNetCore.Mvc;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    [Route("/liveness")]
    public class HealthCheckController : Controller
    {
        [HttpGet(Name = "Liveness")]
        public string Liveness()
        {
            return "The rishy.chemical-handler is ready to go!";
        }
    }
}