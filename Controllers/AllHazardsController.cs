using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.Services;

namespace rischy.chemical_handler.Controllers
{
    // Remove this in final iteration, won't be needed in final product
    [ApiController]
    [Route("/all-hazards")]
    public class AllHazardsController : Controller
    {
        private readonly ChemicalService _chemicalService;
        public AllHazardsController(ChemicalService chemicalService) => _chemicalService = chemicalService;
        
        [HttpGet(Name="GetAllHazards")]
        public async Task<List<ChemicalHazard>> GetAllHazards() => await _chemicalService.GetHazardAsync();
    }
}