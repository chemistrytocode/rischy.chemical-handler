using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    [Route("/liveness")]
    public class HealthCheckController : Controller
    {
        // GET
        [HttpGet(Name = "Liveness")]
        public string Get()
        {
            return "The rishy.chemical-handler is ready to go!";
        }
    }
}