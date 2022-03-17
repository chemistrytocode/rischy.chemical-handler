using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.Services;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    [Route("/hazard")]
    public class HazardController : Controller
    {
        private readonly ChemicalService _chemicalService;

        // Constructor
        public HazardController(ChemicalService chemicalService) => _chemicalService = chemicalService;
        
        [HttpGet(Name = "GetAllHazards")]
        public async Task<List<HazardChemical>> GetHazards() => await _chemicalService.GetHazardAsync();

        
        [HttpPost(Name = "AddChemicals")]
        public string Post()
        {
            return "Adding Chemical data";
        }
    }
}